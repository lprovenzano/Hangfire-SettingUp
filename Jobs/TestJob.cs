using Hangfire;
using System;
using System.Threading.Tasks;

namespace Hangfire_SettingUp
{
    public class TestJob : ITestJob
    {
        public async Task Fire(int idJob)
        {
            Console.WriteLine("Fired!");
            Console.WriteLine($"IDJob: {idJob}");

            var message = await DoSomething();

            Console.WriteLine(message);
        }

        public void EnqueueJobs()
        {
            RecurringJob.AddOrUpdate("jobNew1-id", () => Fire(11), Cron.Minutely);
            RecurringJob.AddOrUpdate("jobNew2-id", () => Fire(22), Cron.Minutely);
            RecurringJob.AddOrUpdate("jobNew3-id", () => Fire(33), Cron.Minutely);
        }

        private async Task<string> DoSomething()
        {
            int miliseconds = 200;
            await Task.Delay(miliseconds);

            return $"Done after {miliseconds} miliseconds.";

        }

    }
}
