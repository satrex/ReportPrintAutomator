using FNF.WindowController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public static class WindowExpander
    {
        public static void DoAfterActivated(this Window target, Action action)
        {
            int minute = 60 * 1000;
            target = target.WaitForActive(2 * minute);

            if (target == null)
            {
                throw new ApplicationException(string.Format(@"{0}を待ちましたが、アクティブになりませんでした。", target.Text));
            }

            if (action != null)
                action.Invoke();
        }
    }
}
