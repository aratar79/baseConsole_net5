using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models.DTOS;
using Services.Interfaces;
using System;

namespace Services
{
    public class MainService
    {
        private readonly IConfiguration _config;
        private readonly IModelService _modelService;
        private readonly ILogger<MainService> _logger;
        public MainService
        (
            ILogger<MainService> logger,
            IConfiguration config,
            IModelService modelService
        )
        {
            _logger = logger;
            _config = config;
            _modelService = modelService;
        }
        public void Run()
        {
            var result = _modelService.GetModelDemo(1);

            _logger.LogInformation("MainService................................run!");
            _logger.LogInformation("");
            _logger.LogInformation(_config.GetValue<string>("TestString") + "\n");
            _logger.LogInformation("Start CRUD demo operations\n");

            var model = new ModelDemoDTO
            {
                NameModel = "Create on run",
                Description = "This object is created on run program"
            };

            _logger.LogInformation("Demo CREATE: add model in to database");
            if (_modelService.CreateModelDemo(model))
                _logger.LogInformation("model created!\n");

            _logger.LogInformation("Demo READ: get model with id = 1:");
            _logger.LogInformation($"name: {result.NameModel}");
            _logger.LogInformation($"description: {result.Description}\n");

            var modelUpdate = new ModelDemoDTO
            {
                Id = 4,
                NameModel = "Update on run",
                Description = "This object is Update on run program"
            };
            _logger.LogInformation("Demo UPDATE: update model in database");
            if (_modelService.UpdateModelDemo(modelUpdate))
                _logger.LogInformation("model update!\n");
                
            var lastmodel = _modelService.GetLastModelDemo();
            
            _logger.LogInformation($"Demo DELETE: delete model num {lastmodel.ToString()} in database");
                if (_modelService.DeleteModelDemo(lastmodel))
                _logger.LogInformation("model deleted!\n");

            Console.ReadKey();

        }
    }
}