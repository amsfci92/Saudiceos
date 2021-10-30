using OperationManager.Jobs;
using OperationManager.Jobsj;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager
{
    public class JobScheduler
    {
        public static async Task Start()
        {  
            // get a scheduler
            IScheduler sched = await StdSchedulerFactory.GetDefaultScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<RemoveAdsAfterJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(40)
                    .RepeatForever())
            .Build();

            await sched.ScheduleJob(job, trigger);
        }
    }
}
