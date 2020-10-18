using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs
{
    public interface IInputDialog
    {
        int InputCount { get; set; }
        SAPbouiCOM.Form RawForm { get; }
        void ShowModal();        
        void DoOk(Action<IInputDialog> Act);
        void DoCancel(Action<IInputDialog> Act);
        
    }
}
