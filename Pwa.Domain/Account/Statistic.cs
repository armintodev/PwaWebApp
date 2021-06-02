using Pwa.Domain.Aggregates;
using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Account
{
    public class Statistic : BaseEntity, IStatisticAggregate
    {
        public int DeveloperId { get; private set; }
        public string IpAddress { get; private set; }
        public string Path { get; private set; }
        public string Browser { get; private set; }
        public string Device { get; private set; }
        public string Os { get; private set; }
        public string Version { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Developer Developer { get; private set; }

        protected Statistic()
        {

        }

        public Statistic(string ipAddress, string path, string browser, string device, string os, string version, int developerId)
        {
            IpAddress = ipAddress;
            Path = path;
            Browser = browser;
            Device = device;
            Os = os;
            Version = version;
            CreationDate = DateTime.Now;
            DeveloperId = developerId;
        }
    }
}
