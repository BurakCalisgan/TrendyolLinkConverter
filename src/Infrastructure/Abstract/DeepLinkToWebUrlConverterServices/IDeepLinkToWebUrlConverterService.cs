namespace Infrastructure.Abstract.DeepLinkToWebUrlConverterServices
{
    public interface IDeepLinkToWebUrlConverterService
    {
        string Convert(string deeplink);

        bool CanConvert(string deeplink);
    }
}
