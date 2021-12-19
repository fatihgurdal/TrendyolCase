namespace LinkConverter.Service.Converters
{
    internal class HomeDeepLinkConverter : Domain.Abstract.LinkConverter
    {
        /// <summary>
        /// Araya farklı link türleri eklenebilmesi için son adımıda zincire dahil edildi.
        /// </summary>
        /// <param name="nextHandler"></param>
        public HomeDeepLinkConverter(Domain.Abstract.LinkConverter nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            return Domain.Constant.UrlConsts.WebDomain;
        }
    }
}
