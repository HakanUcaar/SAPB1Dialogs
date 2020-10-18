using SAPbouiCOM;
using System.Collections.Generic;

namespace SAPB1Dialogs.Inputs
{
    public interface IInput
    {
        BoFormItemTypes ItemType { get; set; }
        BoDataType DataType { get; set; }
        int DataLength { get; set; }
        string LabelCaption { get; set; }
        object DefaultValue { get; set; }

        IInput SetDataType(BoDataType DataType);
        IInput SetDataLength(int DataLength);
        IInput SetDefaultValue(object DefaultValue);
        IInput SetItemType(BoFormItemTypes ItemType);
        IInput SetLabelCaption(string LabelCaption);
    }
}
