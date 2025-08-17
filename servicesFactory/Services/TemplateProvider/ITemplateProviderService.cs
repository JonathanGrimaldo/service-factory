using static servicesFactory.Common.Enums.Enums;

namespace servicesFactory.Services.TemplateProvider
{
    public interface ITemplateProviderService
    {
        string GetTemplate(string name, ServiceType serviceType);
    }
}
