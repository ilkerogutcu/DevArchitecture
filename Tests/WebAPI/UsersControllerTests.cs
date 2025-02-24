﻿


namespace Tests.WebAPI
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using FluentAssertions;
    using global:: Core.CrossCuttingConcerns.Caching;
    using global::Core.CrossCuttingConcerns.Caching.Microsoft;
    using NUnit.Framework;
    using Tests.Helpers;
    using Tests.Helpers.Token;

    [TestFixture]
    public class UsersControllerTests : BaseIntegrationTest
	{
		[Test]
		public async Task GetAll()
		{
			const string authenticationScheme = "Bearer";
			const string requestUri = "api/users/getall";

			// Arrange
			var token = MockJwtTokens.GenerateJwtToken(ClaimsData.GetClaims());
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
			var cache = new MemoryCacheManager();

			cache.Add($"{CacheKeys.UserIdForClaim}=1", new List<string>() { "GetUsersQuery" });

			// Act
			var response = await HttpClient.GetAsync(requestUri);

			// Assert
			response.StatusCode.Should()?.Be(HttpStatusCode.OK);
		}
	}
}
