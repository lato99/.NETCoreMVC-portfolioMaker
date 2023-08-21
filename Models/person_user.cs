using System;
namespace PortfolioMakerApp.Models
{
	public class person_user
	{
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public string martialStatus { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }


}

