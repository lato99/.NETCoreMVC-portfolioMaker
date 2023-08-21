using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace PortfolioMakerApp.Models
{
    public class person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Other service configurations...

            // Add the authorization services
            services.AddAuthorization();

            // Additional service configurations...
        }
    }
}

