using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs
{
    public static class Utils
    {
        public static T ItemCast<T>(this SAPbouiCOM.Item Item) where T : class
        {
            return (T)Item.Specific;
        }
    }
}
