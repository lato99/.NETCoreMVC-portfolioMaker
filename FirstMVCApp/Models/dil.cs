using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PortfolioMakerApp.Models
{
    public class dil
    {
        public int Id { get; set; }
        public string dilIsmi { get; set; }
        public string genelDilDerecesi { get; set; }
        public string okumaDerecesi { get; set; }
        public string dinlemeDerecesi { get; set; }
        public string konusmaDerecesi { get; set; }
        public string yazmaDerecesi { get; set; }






        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}

