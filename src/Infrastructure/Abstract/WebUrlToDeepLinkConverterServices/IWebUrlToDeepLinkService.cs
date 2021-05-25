namespace Infrastructure.Abstract.WebUrlToDeepLinkConverterServices
{
    public interface IWebUrlToDeepLinkService
    {
        string WebUrlToDeepLink(string url);
    }
}
