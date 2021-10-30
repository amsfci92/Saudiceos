﻿using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Jobsj
{
    public class RemoveAdsAfterJob : IJob 
    {

        public async Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string jobSays = dataMap.GetString("jobSays");
            float myFloatValue = dataMap.GetFloat("myFloatValue");


            await Console.Error.WriteLineAsync("Instance " + key + " of DumbJob says: " + jobSays + ", and val is: " + myFloatValue);
        }
    }

}
