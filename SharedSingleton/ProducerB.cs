using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SharedSingleton
{
    public class ProducerB : BackgroundService
    {
        private readonly ILogger<ProducerB> _logger;
        private readonly ISharedData _sharedData;

        public ProducerB(ILogger<ProducerB> logger, ISharedData sharedData)
        {
            _logger = logger;
            _sharedData = sharedData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string s = System.IO.Path.GetRandomFileName();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker B running at: {time}, adding {value}", DateTimeOffset.Now, s);
                _sharedData.Enquque(s);
                await Task.Delay(new Random().Next(1000, 2000), stoppingToken);
            }
        }
    }
}
