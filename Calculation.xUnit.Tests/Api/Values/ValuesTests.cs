using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calculation.Api.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Calculation.xUnit.Tests.Api.Values
{
    [Collection("Api")]
    public class ValuesTests 
    {
        private readonly HttpClient _client;

        public ValuesTests(ApiTestFixture fixture)
        {
            _client = fixture.Client;
        }

        // There are two examples how to write API tests
        // You have an API with 3 endpoints: api/values/sum , api/values/multiply , api/values/divide
        // I've already covered api/values/sum endpoint
        // Your task is cover other mathematical operations with tests
        [Fact]
        public async Task Should_return_valid_sum_of_two_numbers()
        {
            var value1 = 2;
            var value2 = 3;

            var request = new SumValueRequest // There are another corresponding models  
            {
                Value1 = value1,
                Value2 = value2
            };
            
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/values/sum", requestContent);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ValueResponse>(responseContent);

            decimal expected = value1 + value2;
            obj.Result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2,3)]
        [InlineData(4,5)]
        [InlineData(1,3)]
        public async Task Should_return_valid_sum_of_two_numbers_based_on_test_cases(int value1, int value2)
        {
            var request = new SumValueRequest
            {
                Value1 = value1,
                Value2 = value2
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/values/sum", requestContent);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ValueResponse>(responseContent);

            decimal expected = value1 + value2;
            obj.Result.Should().Be(expected);
        }
    }
}
