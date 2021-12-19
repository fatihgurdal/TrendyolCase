using LinkConverter.Tests.Models;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace LinkConverter.Tests.Tests.WebUrlToDeepLink
{
    [Collection("Startup collection")]
    public class SearchTests
    {
        private StartupFixture Fixture { get; }

        public SearchTests(StartupFixture fixture)
        {
            Fixture = fixture;
        }

        #region Success
        [Theory]
        [MemberData(nameof(Search_Success_Data))]
        public void Search_Success(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldBe(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Search_Success_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Search_Success_Data.json");



        #endregion

        #region Fail
        
        [Theory]
        [MemberData(nameof(Search_Success_Fail_Data))]
        public void Search_Success_Fail(ConvertModel model)
        {
            var deepLink = Fixture.linkConverterService.WebUrlToDeepLink(model.RequestUrl);
            deepLink.ShouldNotBeNull(model.ResponseUrl);
        }
        public static IEnumerable<object[]> Search_Success_Fail_Data()
            => Helper.TestDataReaderHelper.GetAppsettingsTestData<ConvertModel>("WebUrlToDeepLink.TestData.Search_Success_Fail.json");

        #endregion
    }
}
