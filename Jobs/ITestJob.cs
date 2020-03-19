using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.Tier
{
    public interface ITestJob
    {
        Task Fire(int id);
        void EnqueueJobs();
    }
}
