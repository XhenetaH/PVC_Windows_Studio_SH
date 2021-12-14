using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.Session
{
    public class MyMessageBoxLocalizationProvider : RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.YesButton:return "Po";
                case RadMessageStringID.NoButton:return "Jo";
            }
            return base.GetLocalizedString(id);
        }
    }
}
