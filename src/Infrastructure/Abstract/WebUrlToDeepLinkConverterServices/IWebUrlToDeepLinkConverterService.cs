namespace Infrastructure.Abstract.WebUrlToDeepLinkConverterServices
{
    public interface IWebUrlToDeepLinkConverterService
    {
        string Convert(string url);

        bool CanConvert(string url);
    }
}
