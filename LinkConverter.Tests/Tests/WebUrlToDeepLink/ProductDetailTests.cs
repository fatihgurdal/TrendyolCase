using LinkConverter.Tests.Models;
using System.Collections.Generic;

using Xunit;
using Shouldly;

namespace LinkConverter.Tests.Tests.WebUrlToDeepLink
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
        /// <summary>
        /// Başarılı çeviri kontrolleri
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(Content_Boutique_Merchant_Success_Data))]
        [MemberData(nameof(Content_Success_Data))]
        public void Content_Boutique_Merchant_Success(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldBe(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Content_Boutique_Merchant_Success_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Content_Boutique_Merchant_Success_Data.json");

        public static IEnumerable<object[]> Content_Success_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Content_Success_Data.json");


        #endregion

        #region Fail
        /// <summary>
        /// Çevrilen linklerin yanlış veriler ile karşılaştırıp ters işlem dorğrulaması
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(Content_Boutique_Merchant_Fail_Data))]
        [MemberData(nameof(Content_Fail_Data))]
        public void Content_Boutique_Merchant_Fail(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Content_Boutique_Merchant_Fail_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Content_Boutique_Merchant_Fail_Data.json");
        public static IEnumerable<object[]> Content_Fail_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Content_Fail_Data.json");

        #endregion

        #region Throw
        /// <summary>
        /// Gönderilen Id bilgilerinin sıfır olması durumunda hata fırlatma kontorlü
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(Content_Boutique_Merchant_Throw_Data))]
        public void Content_Boutique_Merchant_Throw(ConvertModel model)
        {
            var deepLink = Should.Throw<Domain.Exception.BadRequestException>(() => Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl));
            deepLink.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Content_Boutique_Merchant_Throw_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Content_Boutique_Merchant_Throw_Data.json");
        #endregion

    }
}
