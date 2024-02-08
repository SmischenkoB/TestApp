using BusinessLogic.Models;
using BusinessLogic.Transformers;
using DBLayer.Models;
namespace BusinessLogicUnitTests.Transformers
{
    public class AirportTransformerTest
    {
        [Fact]
        public async void TransformAirportEntityFromDb()
        {
            Airport airport = new Airport() { AirportId = 7, IATACode = "LGW", Country = new Country() { Id = 7, Name = "London" }, AirportType = new AirportType() { Id = 7, Name = "Arrival Only" } };

            var res = await AirportTransformer.TransformAirportEntityFromDb(airport);

            Assert.NotNull(res);
            Assert.Equal(airport.AirportId, res.AirportId);
            Assert.Equal(airport.IATACode, res.IATACode);
            Assert.Equal(airport.Country.Name, res.CountryName);
            Assert.Equal(airport.AirportType.Name, res.Type);
        }

        [Fact]
        public async void TransformAirportEntityToDb()
        {
            AirportFEModel airport = new AirportFEModel() { AirportId = 7, IATACode = "LDN", CountryName = "UK", Type = "Arrival Only" };

            var res = await AirportTransformer.TransformAirportEntityToDb(airport);

            Assert.NotNull(res);
            Assert.Equal(airport.IATACode, res.IATACode);
            Assert.Equal(airport.AirportId, res.AirportId);
            Assert.Equal(7, res.AirportTypeId);
        }
    }
}