namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;

    public interface ICityService
    {
        City CreateCity(string name, string postCode);
    }
}
