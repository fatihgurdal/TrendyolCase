using LinkConverter.Tests.Models;

using Shouldly;

using System.Collections.Generic;

using Xunit;
namespace LinkConverter.Tests.Tests.WebUrlToDeepLink
{
    [Collection("Startup collection")]
    public class HomeTest
    {
        private StartupFixture Fixture { get; }

        public HomeTest(StartupFixture fixture)
        {
            Fixture = fixture;
        }

        #region Success
        [Theory]
        [MemberData(nameof(Home_Success_Data))]
        public void Home_Success(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldBe(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Home_Success_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Home_Success_Data.json");



        #endregion

        #region Fail

        [Theory]
        [MemberData(nameof(Home_Success_Fail_Data))]
        public void Home_Success_Fail(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Home_Success_Fail_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Home_Success_Fail.json");

        #endregion
    }
}
