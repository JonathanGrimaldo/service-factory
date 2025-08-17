
namespace servicesFactory.Templates.SOAP
{
    public static partial class SoapTemplates
    {
        public static string GetByNameTemplate
        {
            get
            {
                return $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                               xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <GetByName xmlns=""http://tempuri.org"">
                            <name>nameToSearch</name>
                        </GetByName>
                    </soap:Body>
                </soap:Envelope>";
            }

        }
    }
}
