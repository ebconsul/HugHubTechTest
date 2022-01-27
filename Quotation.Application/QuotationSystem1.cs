using Microsoft.Extensions.Options;
using Quotation.Domain.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace Quotation.Application
{
    public class QuotationSystem1 : IQuotationService
    {
        public QuotationSystem1()
        {

        }

        public Task<dynamic> GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            dynamic response = new ExpandoObject();

            if (request.RiskData.DOB != null)
            {
                //var response = _someExternalService.PostHttpRequest(requestData);                
                response.Price = 123.45M;
                response.IsSuccess = true;
                response.Name = "Test Name";
                response.Tax = 123.45M * 0.12M; 
            }

            return response;
        }
    }
}
