namespace servicesFactory.Services.Soap.Crcind
{
    public class GetByNameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DOB {  get; set; }
        public string? SSN { get; set; }
    }
}
