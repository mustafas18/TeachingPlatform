using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using Xunit.Abstractions;

namespace FunctionalTest.ControllerApi
{
    public class CourseControllerTest : IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _outputHelper;

        public CourseControllerTest(CustomWebApplicationFactory<WebMarker> factory,
            ITestOutputHelper outputHelper) {
            _httpClient = factory.CreateClient();
            _outputHelper = outputHelper;
        }
        [Fact]
        public async Task Returns_CourseList()
        {
            var response = await _httpClient.GetAsync("/api/projects");
            var stringResponse = await response.Content.ReadAsStringAsync();
            _outputHelper.WriteLine(stringResponse);
            var result = System.Text.Json.JsonSerializer.Deserialize<Course>(stringResponse);

            Assert.NotNull(result);
        }

    }
}
