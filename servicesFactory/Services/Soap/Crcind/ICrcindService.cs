namespace servicesFactory.Services.Soap.Crcind
{
    public interface ICrcindService
    {
        Task<List<GetByNameDto>> GetByName(string name);
    }
}
