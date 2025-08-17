namespace servicesFactory.Utils
{
    public static class TemplateUtils
    {
        public static string ReplacePlaceholders(string template, Dictionary<string, string> parametersToReplace)
        {
            string replacedTemplate = template;

            foreach (var param in parametersToReplace)
            {
                string placeholder = $"{{{param.Key}}}";
                replacedTemplate = replacedTemplate.Replace(param.Key, param.Value);
            }

            return replacedTemplate;
        }
    }
}
