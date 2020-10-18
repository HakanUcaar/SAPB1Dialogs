using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM;

namespace SAPB1Dialogs.Inputs
{
    public abstract class BaseInput : IInput
    {
        public int DataLength { get; set; } = 10;
        public BoDataType DataType { get; set; }
        public object DefaultValue { get; set; }
        public BoFormItemTypes ItemType { get; set; }
        public string LabelCaption { get; set; }

        public BaseInput()
        {

        }
        public BaseInput(BoFormItemTypes ItemType,BoDataType DataType)
        {
            this.ItemType = ItemType;
            this.DataType = DataType;
        }

        public IInput SetDataType(BoDataType DataType)
        {
            this.DataType = DataType;
            return this;
        }
        public IInput SetDataLength(int DataLength)
        {
            this.DataLength = DataLength;
            return this;
        }
        public IInput SetDefaultValue(object DefaultValue)
        {
            this.DefaultValue = DefaultValue;
            return this;
        }
        public IInput SetItemType(BoFormItemTypes ItemType)
        {
            this.ItemType = ItemType;
            return this;
        }
        public IInput SetLabelCaption(string LabelCaption)
        {
            this.LabelCaption = LabelCaption;
            return this;
        }
    }
}
