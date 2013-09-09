using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public abstract class HonbuAutomation: AutomationBase
    {
        public HonbuAutomation()
        {
            this.CriteriaSettings = new List<Action>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Action> CriteriaSettings { get; set; }
        protected abstract void Query();

    }
}
