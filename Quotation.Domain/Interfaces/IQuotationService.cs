using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Domain.Interfaces
{
    public interface IQuotationService
    {
        Task<dynamic> GetPrice(dynamic request);
    }
}
