using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Servieces
{
    public class ClouldMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public ClouldMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_configuration["mailSettings:mailFromAddress"]} to {_configuration["mailSettings:mailToAddress"]}, with ClouldMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
