﻿using Pwa.Domain.Base;
using System;
using System.Collections.Generic;

namespace Pwa.Domain.Account
{
    public class Statistic : BaseEntity
    {
        public string Browser { get; private set; }
        public string Device { get; private set; }
        public string Os { get; private set; }
        public string Version { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ICollection<Developer> Developers { get; private set; }

        protected Statistic()
        {

        }

        public Statistic(string browser, string device, string os, string version)
        {
            Browser = browser;
            Device = device;
            Os = os;
            Version = version;
            CreationDate = DateTime.Now;
            Developers = new List<Developer>();
        }
    }
}