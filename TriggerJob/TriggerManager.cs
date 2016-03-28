using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiginIn.TriggerJob
{
    public delegate void JobDelegate();
    public class TriggerManager:IJob
    {
        /// <summary>
        /// 无参代理
        /// </summary>
        //public delegate void JobDelegate();
        /// <summary>
        /// 构造实例时，给JobHandle赋值
        /// </summary>
        public JobDelegate JobHandle;
        private void InitTrigger()
        {
            GlobalScheduler.Scheduler.AddJob(CommonUtil.BuildJob(), false);
        }
        /// <summary>
        /// 实现IJob，调用代理方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(JobExecutionContext context)
        {
            JobHandle();
        }
        public TriggerManager() { this.JobHandle = CommonUtil.JobHandle; }

        /// <summary>
        /// 构造函数，传入一个无参代理方法，该方法就是你要定时执行的任务
        /// </summary>
        /// <param name="job">定时执行的任务</param>
        public TriggerManager(JobDelegate job)
        {
            this.JobHandle = job;
            CommonUtil.JobHandle = job;

            this.InitTrigger();
        }
        /// <summary>
        /// 添加一个触发器
        /// </summary>
        /// <param name="cronExpression"></param>
        /// <param name="triggerName"></param>
        public void AddTrigger(string cronExpression, string triggerName)
        {
            Trigger trigger = CommonUtil.BuildTrigger(cronExpression, triggerName);
            GlobalScheduler.Scheduler.ScheduleJob(trigger);
        }
        public void AddTrigger(DateTime time, string triggerName)
        {
            Trigger trigger = CommonUtil.BuildTrigger(time, triggerName);
            GlobalScheduler.Scheduler.ScheduleJob(trigger);
        }
        /// <summary>
        /// 删除一个触发器
        /// </summary>
        /// <param name="triggerName"></param>
        public void RemoveTrigger(string triggerName)
        {
            GlobalScheduler.Scheduler.UnscheduleJob(triggerName, Keys.TRIGGERGROUP);
        }
    }
}
