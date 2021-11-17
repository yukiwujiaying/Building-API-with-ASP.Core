namespace CityInfo.API.Servieces
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}