namespace TradingCompany.BL.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string username, string password);
        int GetId(string login);
    }
}
