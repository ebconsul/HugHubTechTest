using Quotation.Domain.Enumerations;
using Quotation.Domain.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace Quotation.Application
{
    public class QuotationSystem2 : IQuotationService
    {
        public QuotationSystem2()
        {
        }

        public Task<dynamic> GetPrice(dynamic request)
        {
            dynamic response = new ExpandoObject();

            if (request.RiskData.Make == MakeEnum.ExampleMake1 || 
                request.RiskData.Make == MakeEnum.ExampleMake2 ||
                request.RiskData.Make == MakeEnum.ExampleMake3)
            {
                //makes a call to an external service - SNIP
                //var response = _someExternalService.PostHttpRequest(requestData);
                response.Price = 234.56M;
                response.HasPrice = true;
                response.Name = "qewtrywrh";
                response.Tax = 234.56M * 0.12M;
            }

            return response;
        }
    }
}
