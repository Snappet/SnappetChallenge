namespace SnappetChallenge.IntegrationTests
{
    using System;
    using System.Threading.Tasks;

    using SnappetChallenge.WebApi.Models;

    using Xunit;

    public class ClassResultControllerTests : WebApiTests
    {
        private readonly string routeTemplate = "api/classresult/from/{0}/to/{1}";

        private readonly DateTime utmostDateFrom = DateTime.SpecifyKind(new DateTime(2015, 03, 24), DateTimeKind.Utc);
        private readonly DateTime utmostDateTo = DateTime.SpecifyKind(new DateTime(2015, 03, 24, 11, 30, 00), DateTimeKind.Utc);

        [Fact]
        public async Task SimpleGettingData()
        {
            var route = string.Format(this.routeTemplate, this.utmostDateFrom.ToString("O"), this.utmostDateTo.ToString("O"));

            var response = await this.client.GetAsync(route);
        }
    }
}
