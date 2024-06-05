﻿namespace SmallFactory.Models
{
    public class JobSchedule(Type jobType, string cronExpression)
    {
        public Type JobType { get; } = jobType;
        public string CronExpression { get; } = cronExpression;
    }
}
