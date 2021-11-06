// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
// using System;

// namespace baseConsole_net5
// {
//     public class Main
//     {
//         private readonly ILogger<Main> _logger;
//         private readonly IConfiguration _config;

//         public Main(ILogger<Main> logger, IConfiguration config)
//         {
//             _logger = logger;
//             _config = config;
//         }

//         public void Run()
//         {
//             _logger.LogInformation("MainService................................run!");
//             _logger.LogInformation("");
//             _logger.LogInformation(_config.GetValue<string>("TestString"));
//             Console.ReadKey();
//         }

//     }
// }