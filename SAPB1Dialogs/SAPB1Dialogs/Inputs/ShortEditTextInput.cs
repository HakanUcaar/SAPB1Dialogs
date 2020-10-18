using SAPbouiCOM;

namespace SAPB1Dialogs.Inputs
{
    public class ShortEditTextInput : BaseInput
    {
        public ShortEditTextInput() : base(BoFormItemTypes.it_EDIT,BoDataType.dt_SHORT_TEXT)
        {
            DataLength = 254;
        }
    }
}
