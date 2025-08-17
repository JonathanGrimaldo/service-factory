using servicesFactory.Templates.SOAP;
using System.Reflection;
using static servicesFactory.Common.Enums.Enums;

namespace servicesFactory.Services.TemplateProvider
{
    public class TemplateProviderService : ITemplateProviderService
    {
        public string GetTemplate(string templateName, ServiceType serviceType)
        {
            try
            {
                Type templateClassType = GetTemplateClass(serviceType);

                // 2. Usar reflexión para encontrar la propiedad estática.
                PropertyInfo? templateProperty = templateClassType.GetProperty(templateName, BindingFlags.Public | BindingFlags.Static);

                if (templateProperty == null)
                {
                    throw new ArgumentException($"La plantilla '{templateName}' no se encontró en la clase '{templateClassType.Name}'.");
                }

                // 3. Obtener el valor de la propiedad.
                return (string)templateProperty.GetValue(null); // 'null' porque es una propiedad estática.
            }
            catch
            {
                throw;
            }
        }

        private Type GetTemplateClass(ServiceType serviceType)
        {
            try
            {
                switch (serviceType)
                {
                    case ServiceType.SOAP:
                        return typeof(SoapTemplates);
                    case ServiceType.GraphQL:
                        return null;
                    default:
                        throw new ArgumentException("Tipo de servicio no válido."); ;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
