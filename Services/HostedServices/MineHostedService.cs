using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ST = System.Threading;

namespace Services.Blockchains
{
    public class MineHostedService : IHostedService, IDisposable
    {
        private ST.Timer _timer;
        public Task StartAsync(ST.CancellationToken cancellationToken)
        {
            Console.WriteLine("Initializing Mine Hosted Service");
            long unixTimeSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            //Console.WriteLine(unixTimeSeconds);
            int timeLeft = 60 - (int)unixTimeSeconds%60;
            //Console.WriteLine("Waiting (" + timeLeft + " + 60) seconds to start mining");
            //Console.WriteLine("60 seconds left");
            _timer = new ST.Timer(InitMiningCycle, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }
        public Task StopAsync(ST.CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void InitMiningCycle(object o)
        {
            long unixTimeSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            //Console.WriteLine("Sending best proof of work to network..." + unixTimeSeconds);
            //Console.WriteLine("Sending post request to Controller to begin mining...");
            // var httpResponse = new HttpClient().GetAsync("https://localhost:5001/blockchain/mine");
            // TODO: some kind of verification
        }
    }
}