namespace LinkConverter.Service.Converters
{
    internal class HomeWebUrlConverter : Domain.Abstract.LinkConverter
    {
        /// <summary>
        /// Araya farklı link türleri eklenebilmesi için son adımıda zincire dahil edildi.
        /// </summary>
        /// <param name="nextHandler"></param>
        public HomeWebUrlConverter(Domain.Abstract.LinkConverter nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            return $"{Domain.Constant.UrlConsts.DeepLinkPrefix}Page=Home";
        }
    }
}
