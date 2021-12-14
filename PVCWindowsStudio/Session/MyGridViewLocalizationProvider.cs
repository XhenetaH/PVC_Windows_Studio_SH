using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.Session
{
    public class MyGridViewLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch(id)
            {
                case RadGridStringId.SearchRowTextBoxNullText: return "Kërko Këtu...";
                case RadGridStringId.SearchRowMenuItemAllColumns: return "Të gjitha";
                case RadGridStringId.SearchRowMatchCase: return "Kërko sipas madhësisë së shkronjave";
                case RadGridStringId.SearchRowChooseColumns: return "Kërko në kolona";
                case RadGridStringId.SearchRowSearchFromCurrentPosition: return "Kërko nga pozicioni aktual";
                case RadGridStringId.GroupingPanelHeader: return "Grupo sipas: ";
                case RadGridStringId.GroupingPanelDefaultMessage: return "Tërhiqni një kolonë këtu për të grupuar sipas kësaj kolone.";
                case RadGridStringId.PagingPanelPagesLabel:return "Faqja";
                case RadGridStringId.PagingPanelOfPagesLabel:return "nga";
            }
            return base.GetLocalizedString(id);
        }
    }
}
