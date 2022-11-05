using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SharedSingleton
{
    public class Consumer : BackgroundService
    {
        private readonly ILogger<Consumer> _logger;
        private readonly ISharedData _sharedData;

        public Consumer(ILogger<Consumer> logger, ISharedData sharedData)
        {
            _logger = logger;
            _sharedData = sharedData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string s;
            while (!stoppingToken.IsCancellationRequested)
            {   
                s = _sharedData.Dequque();
                _logger.LogInformation("Consumer running at: {time}, got {value}", DateTimeOffset.Now, 
                    s != null? s : "no value");
                await Task.Delay(50, stoppingToken);
            }
        }
    }
}
