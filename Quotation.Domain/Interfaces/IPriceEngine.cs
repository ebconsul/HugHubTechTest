using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Domain.Interfaces
{
    public interface IPriceEngine
    {
        Task<PriceResponse> GetPrice(PriceRequest request);
    }
}
