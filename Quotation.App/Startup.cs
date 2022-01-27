using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quotation.Domain.Interfaces;

namespace Quotation.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterAllTypes<IQuotationService>(new[] {typeof(Startup).Assembly});
        }
    }
}
