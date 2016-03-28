using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiginIn.TriggerJob
{
    public class GlobalScheduler
    {
        private GlobalScheduler() { }
        private static IScheduler scheduler;

        public static IScheduler Scheduler
        {
            get
            {
                if(scheduler==null)
                {
                    SetScheduler();
                }
                return scheduler;
            }
        }
        private static void SetScheduler()
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            scheduler.Start();
        }
    }
}
