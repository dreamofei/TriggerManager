using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiginIn.TriggerJob
{
    public static class CommonUtil
    {
        public static JobDelegate JobHandle;
        public static Trigger BuildTrigger(string cronExpression, string triggerName)
        {
            CronTrigger trigger = new CronTrigger();
            trigger.CronExpressionString = cronExpression; //ctrigger.CronExpressionString = "0/2 * * * * ?";
            trigger.Name = triggerName;
            trigger.Group = Keys.TRIGGERGROUP;

            trigger.JobName = Keys.JOBNAME;
            trigger.JobGroup = Keys.JOBGROUP;

            return trigger;
        }
        public static Trigger BuildTrigger(DateTime time, string triggerName)
        {
            StringBuilder sb = new StringBuilder()
            .Append(time.Second)
            .Append(" ")
            .Append(time.Minute)
            .Append(" ")
            .Append(time.Hour)
            .Append(" ")
            .Append("*")
            .Append(" ")
            .Append("*")
            .Append(" ")
            .Append("?");

            CronTrigger trigger = new CronTrigger();

            trigger.CronExpressionString = sb.ToString(); //ctrigger.CronExpressionString = "0/2 * * * * ?";
            trigger.Name = triggerName;
            trigger.Group = Keys.TRIGGERGROUP;

            trigger.JobName = Keys.JOBNAME;
            trigger.JobGroup = Keys.JOBGROUP;

            return trigger;
        }
        public static JobDetail BuildJob()
        {
            JobDetail job = new JobDetail(Keys.JOBNAME, Keys.JOBGROUP, typeof(TriggerManager));
            job.Durable = true;
            return job;
        }
    }
}
