using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs.Inputs
{
    public class ComboBoxInput : BaseInput
    {
        public Dictionary<string,string> Values { get; set; }

        public ComboBoxInput() : base(BoFormItemTypes.it_COMBO_BOX, BoDataType.dt_SHORT_TEXT)
        {
            DataLength = 254;
        }
        public ComboBoxInput(Dictionary<string, string> List) : base(BoFormItemTypes.it_COMBO_BOX,BoDataType.dt_SHORT_TEXT)
        {
            this.Values = List;
            DataLength = 254;
        }

        public IInput SetValidValues(Dictionary<string,string> List)
        {
            this.Values = List;
            return this;
        }
    }
}
