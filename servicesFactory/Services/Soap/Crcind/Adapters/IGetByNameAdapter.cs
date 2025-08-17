namespace servicesFactory.Services.Soap.Crcind.Adapters
{
    public interface IGetByNameAdapter
    {
        List<GetByNameDto> Adapt(string xmlResponse);
    }
}
