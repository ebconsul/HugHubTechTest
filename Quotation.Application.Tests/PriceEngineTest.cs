using FluentAssertions;
using NSubstitute;
using Quotation.Domain;
using Quotation.Domain.Exceptions;
using Quotation.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Quotation.Application.Tests
{
    public class PriceEngineTest
    {
        private IPriceEngine priceEngine;

        public PriceEngineTest()
        {
            var quotationServices = Substitute.For<IEnumerable<IQuotationService>>();
            priceEngine = new PriceEngine(quotationServices);
        }

        [Fact]
        public async Task GetPrice_ThrowsException_WhenInvalidRequest_RiskDataNull()
        {
            //arrange
            var request = new PriceRequest();

            //act
            var response = await priceEngine.GetPrice(request);

            //assert
            response.ErrorMessage.Should().Be("Risk Data is missing");
            response.Price.Should().Be(-1);

        }
    }
}
