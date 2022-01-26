using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PriceResponse
    {
        public decimal Tax { get; set; }

        public string InsurerName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
