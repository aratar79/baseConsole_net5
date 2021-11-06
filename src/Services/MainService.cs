using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Services
{
    public class MainService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MainService> _logger;
        public MainService(ILogger<MainService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public void Run()
        {
            _logger.LogInformation("MainService................................run!");
            _logger.LogInformation("");
            _logger.LogInformation(_config.GetValue<string>("TestString\n"));
            

        }
    }
}