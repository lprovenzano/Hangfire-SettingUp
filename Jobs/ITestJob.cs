using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire_SettingUp
{
    public interface ITestJob
    {
        Task Fire(int id);
        void EnqueueJobs();
    }
}
