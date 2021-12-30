using LinkConverter.Tests.Models;
using System.Collections.Generic;

using Xunit;
using Shouldly;

namespace LinkConverter.Tests.Tests.DeepLinkToWebUrl
{
    [Collection("Startup collection")]
    public class ProductDetailTests
    {
        private StartupFixture Fixture { get; }

        public ProductDetailTests(StartupFixture fixture)
        {
            Fixture = fixture;
        }

        #region Success
        [Theory]
        [MemberData(nameof(Content_Success_Data))]
        public void Content_Boutique_Merchant_Success(ConvertModel model)
        {
            var weburl = Fixture.linkConverterService.DeepLinkToWebUrl(model.RequestUrl);
            weburl.ShouldBe(model.ResponseUrl);
        }

        public static IEnumerable<object[]> Content_Success_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("DeepLinkToWebUrl.TestData.Content_Success_Data.json");


        #endregion

        #region Fail
        [Theory]
        [MemberData(nameof(Content_Fail_Data))]
        public void Content_Boutique_Merchant_Fail(ConvertModel model)
        {
            var weburl = Fixture.linkConverterService.DeepLinkToWebUrl(model.RequestUrl);
            weburl.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Content_Fail_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("DeepLinkToWebUrl.TestData.Content_Fail_Data.json");

        #endregion

        #region Throw
        /// <summary>
        /// Gönderilen Id bilgilerinin sıfır olması durumunda hata fırlatma kontorlü
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(Content_Throw_Data))]
        public void Content_Throw(ConvertModel model)
        {
            var weburl = Should.Throw<Domain.Exception.BadRequestException>(() => Fixture.linkConverterService.DeepLinkToWebUrl(model.RequestUrl));
            weburl.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Content_Throw_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("DeepLinkToWebUrl.TestData.Content_Throw_Data.json");
        #endregion
    }
}
