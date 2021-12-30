using LinkConverter.Domain.Extensions;

using System.Linq;

namespace LinkConverter.Domain.Abstract
{
    /// <summary>
    /// chain of responsibility design pattern uygulanmıştır. Link çeviri işlerinde if ve case durumlarını azaltmak ve başta SOLID'in Open/Closed prensibine uymak için eklenmiştir. Her çeviri türü LinkConverter'ı miras alarak çeviri adımları oluşturulur. Bu adımların her biri business logic ile çeviri yapabiliyorsa yapması yapamıyorsa kendisinden görevini sonraki adıma yönlendirmesi hedeflenmiştir.
    /// </summary>
    public abstract class LinkConverter
    {
        protected readonly LinkConverter NextHandler;

        public LinkConverter(LinkConverter nextHandler)
        {
            this.NextHandler = nextHandler;
        }

        public abstract string ConvertUrl(string url);

        protected virtual string GetUrlValueWithRegex(string url, string pattern, string regexGroupName)
        {
            var matchs = url.GetRegexMatch(pattern);
            if (matchs.Any())
            {
                return matchs.First().Groups[regexGroupName].Value;
            }
            else return default;
        }
    }
}
