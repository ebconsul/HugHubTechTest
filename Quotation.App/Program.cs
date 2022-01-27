using Quotation.Application;
using Quotation.Domain;
using Quotation.Domain.Interfaces;

namespace Quotation.App
{
    class Program
    {
        private IPriceEngine _priceEngine;

        public Program(IPriceEngine priceEngine)
        {
            _priceEngine = priceEngine;
        }
        static void Main(string[] args)
        {
            //SNIP - collect input (risk data from the user)

            var request = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };

            decimal tax = 0;
            string insurer = "";
            string error = "";

            var response = _priceEngine.GetPrice(request).Wait();

            if (response.Price == -1)
            {
                Console.WriteLine(String.Format("There was an error - {0}", error));
            }
            else
            {
                Console.WriteLine(String.Format("You price is {0}, from insurer: {1}. This includes tax of {2}", response.Price, insurer, tax));
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
