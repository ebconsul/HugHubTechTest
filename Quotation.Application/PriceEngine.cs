using Quotation.Domain;
using Quotation.Domain.Exceptions;
using Quotation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Quotation.Application
{
    public class PriceEngine : IPriceEngine
    {
        private readonly IEnumerable<IQuotationService> _quotationServices;

        public PriceEngine(IEnumerable<IQuotationService> quotationServices)
        {
            _quotationServices = quotationServices;
        }

        //pass request with risk data with details of a gadget, return the best price retrieved from 3 external quotation engines
        public async Task<PriceResponse> GetPrice(PriceRequest request)
        {            
            var response = new PriceResponse();

            try
            {
                //validation
                this.ValidateRequest(request);

                dynamic serviceRequest = new ExpandoObject();
                serviceRequest.FirstName = serviceRequest.RiskData.FirstName;
                serviceRequest.Surname = serviceRequest.RiskData.LastName;
                serviceRequest.DOB = serviceRequest.RiskData.DOB;
                serviceRequest.Make = serviceRequest.RiskData.Make;
                serviceRequest.Amount = serviceRequest.RiskData.Value;

                response.Price = Decimal.MaxValue;

                foreach (var service in _quotationServices)
                {
                    var serviceResponse = await service.GetPrice(serviceRequest);

                    if (serviceResponse.Price < response.Price)
                    {
                        response.Price = serviceResponse.Price;
                        response.InsurerName = serviceResponse.InsurerName;
                        response.Tax = serviceResponse.Tax;
                    }
                }
                
                if (response.Price == decimal.MaxValue)
                {
                    response.Price = -1;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Price = -1;
            }

            return response;
        }

        private void ValidateRequest(PriceRequest request)
        {
            if (request.RiskData == null)
            {
                throw new ValidationException("Risk Data is missing");
            }

            if (String.IsNullOrEmpty(request.RiskData.FirstName))
            {
                throw new ValidationException("First name is required");
            }

            if (String.IsNullOrEmpty(request.RiskData.LastName))
            {
                throw new ValidationException("Surname is required");
            }

            if (request.RiskData.Value == 0)
            {
                throw new ValidationException("Value is required");
            }
        }
    }
}
