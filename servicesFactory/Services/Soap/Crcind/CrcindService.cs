using Microsoft.Extensions.Configuration;
using servicesFactory.Services.Soap.Crcind.Adapters;
using servicesFactory.Services.TemplateProvider;
using servicesFactory.Utils;
using System.Text;
using static servicesFactory.Common.Enums.Enums;

namespace servicesFactory.Services.Soap.Crcind
{
    // SOAP demo service available here: https://www.crcind.com/csp/samples/SOAP.Demo.cls
    public class CrcindService : ICrcindService
    {
		private readonly HttpClient _httpClient;
		private readonly ITemplateProviderService _templateProviderService;
		private readonly IGetByNameAdapter _getByNameAdapter;
        private readonly IConfiguration _configuration;

        public CrcindService(
			HttpClient httpClient, 
			ITemplateProviderService templateProviderService, 
			IGetByNameAdapter getByNameAdapter,
            IConfiguration configuration) 
		{
			_httpClient = httpClient;
            _templateProviderService = templateProviderService;
			_getByNameAdapter = getByNameAdapter;
			_configuration = configuration;
        }

        public async Task<List<GetByNameDto>> GetByName(string name)
        {
			try
			{
				string? template = _templateProviderService.GetTemplate("GetByNameTemplate", ServiceType.SOAP);

				Dictionary<string, string> dictionary = new()
				{
					{ "nameToSearch", name.Trim().ToLower() },
				};	

				string requestBody = TemplateUtils.ReplacePlaceholders(template, dictionary);

                var request = new HttpRequestMessage(HttpMethod.Post, _configuration["CrcindSettings:BaseUrl"]);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "text/xml");

                // Add SOAPAction important
                request.Headers.Add("SOAPAction", "http://tempuri.org/GetByName");
                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();
                string xmlResponse = await response.Content.ReadAsStringAsync();

                return _getByNameAdapter.Adapt(xmlResponse);
            }
			catch
			{
				throw;
			}
        }
    }
}
