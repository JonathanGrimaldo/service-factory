using System.Xml.Linq;

namespace servicesFactory.Services.Soap.Crcind.Adapters
{
    public class GetByNameAdapter : IGetByNameAdapter
    {
        public List<GetByNameDto> Adapt(string xmlResponse)
        {
            var resultList = new List<GetByNameDto>();

            // LINQ to XML to process response
            XNamespace diffgr = "urn:schemas-microsoft-com:xml-diffgram-v1";
            XDocument doc = XDocument.Parse(xmlResponse);

            var sqlElements = doc.Descendants(diffgr + "diffgram")
                                 .Descendants("SQL");
                               //.FirstOrDefault();

            foreach (var sqlElement in sqlElements)
            {
                var dto = new GetByNameDto
                {
                    Id = int.Parse(sqlElement.Element("ID")?.Value ?? "0"),
                    Name = sqlElement.Element("Name")?.Value,
                    DOB = DateTime.Parse(sqlElement.Element("DOB")?.Value ?? DateTime.MinValue.ToString()),
                    SSN = sqlElement.Element("SSN")?.Value
                };

                resultList.Add(dto);
            }

            return resultList;
        }
    }
}
