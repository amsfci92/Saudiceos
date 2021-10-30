using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Jobs
{
    public interface IJob
    {
        Task Execute(IJobExecutionContext context);
    }
}
