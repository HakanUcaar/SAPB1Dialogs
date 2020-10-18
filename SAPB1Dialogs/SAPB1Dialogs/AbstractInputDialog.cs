using SAPB1Dialogs.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs
{
    public abstract class AbstractInputDialog : IInputDialog
    {
        public SAPbouiCOM.Application SAPMainApp = null;

        private SAPbouiCOM.FormCreationParams formDefinition = null;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button ButonOk;
        private SAPbouiCOM.Button ButonCancel;
        private Action<IInputDialog> OkAction;
        private Action<IInputDialog> CancelAction;

        public List<IInput> Inputs { get; set; }
        public int InputCount { get; set; }
        public SAPbouiCOM.Form RawForm { get { return oForm; } }

        public AbstractInputDialog()
        {
            if (SAPMainApp == null)
            {
                var SboGuiApi = new SAPbouiCOM.SboGuiApi();
                var sConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";
                SboGuiApi.Connect(sConnectionString);
                SAPMainApp = SboGuiApi.GetApplication(-1);
            }

            Inputs = new List<IInput>();
            formDefinition = ((SAPbouiCOM.FormCreationParams)(SAPMainApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));

            formDefinition.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Fixed;
            formDefinition.FormType = "TextInputDialog";
            formDefinition.UniqueID = "TextInputDialogModal";
            formDefinition.Modality = SAPbouiCOM.BoFormModality.fm_Modal;
        }

        protected void AddInput(IInput Input)
        {
            Inputs.Add(Input);
        }
        public T NewInput<T>(T Input) where T : IInput
        {
            AddInput(Input);
            return Input;
        }
        public T NewInput<T>(params object[] args) where T : IInput
        {
            IInput oNew = Activator.CreateInstance(typeof(T), args) as IInput;
            AddInput(oNew);
            return (T)oNew;
        }

        public void DoOk(Action<IInputDialog> Act)
        {
            OkAction = Act;
        }
        public void DoCancel(Action<IInputDialog> Act)
        {
            CancelAction = Act;
        }

        public void ShowModal()
        {
            SAPbouiCOM.Item oItem = null;
            SAPbouiCOM.UserDataSource oDS = null; 

            oForm = SAPMainApp.Forms.AddEx(formDefinition);
            //oForm.Title = "Lütfen bilgi girin";

            //  Create the form GUI elements
            oForm.AutoManaged = true;
            oForm.SupportedModes = 0;

            oItem = oForm.Items.Add("TabControl", SAPbouiCOM.BoFormItemTypes.it_FOLDER);
            oItem.Top = 10;
            oItem.Width = 250;
            oItem.Left = 9;
            oItem.Height = 100;

            int CurrentIndex = -1;
            for (int i = 1; i <= Inputs.Count; i++)
            {
                CurrentIndex = i - 1;
                oDS = oForm.DataSources.UserDataSources.Add("UD"+i.ToString(), Inputs[CurrentIndex].DataType, Inputs[CurrentIndex].DataLength);

                oItem = oForm.Items.Add("InputL" + i.ToString(), SAPbouiCOM.BoFormItemTypes.it_STATIC);
                oItem.ItemCast<SAPbouiCOM.StaticText>().Caption = Inputs[CurrentIndex].LabelCaption != null ? Inputs[CurrentIndex].LabelCaption :  i.ToString() + ". değerin bilgileri giriniz";
                oItem.Top =  (i * 17);
                oItem.Width = 80;
                oItem.Left = 10;

                oItem = oForm.Items.Add("Input" + i.ToString(), Inputs[CurrentIndex].ItemType);
                oItem.Top =  (i * 17);
                oItem.Width = 150;
                oItem.Left = 100;

                switch (oItem.Type)
                {
                    case SAPbouiCOM.BoFormItemTypes.it_BUTTON:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_STATIC:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_EDIT:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_FOLDER:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_RECTANGLE:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX:
                        {
                            var Combo = (oItem.Specific as SAPbouiCOM.ComboBox);
                            Combo.Item.DisplayDesc = true;
                            Combo.ExpandType = SAPbouiCOM.BoExpandType.et_DescriptionOnly;

                            foreach (var item in (Inputs[CurrentIndex] as ComboBoxInput).Values)
                            {
                                Combo.ValidValues.Add(item.Key, item.Value);
                            }                            
                        }
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_PICTURE:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_EXTEDIT:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_CHECK_BOX:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_OPTION_BUTTON:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_MATRIX:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_GRID:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_PANE_COMBO_BOX:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_ACTIVE_X:
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_BUTTON_COMBO:
                        {

                        }
                        break;
                    case SAPbouiCOM.BoFormItemTypes.it_WEB_BROWSER:
                        break;
                    default:
                        break;
                }

                PropertyDescriptorCollection propsB = TypeDescriptor.GetProperties(oItem.Specific);

                if(propsB.Contains(propsB.Find("DataBind", true)))
                {
                    var GetMemberValue = oItem.Specific.GetType().InvokeMember("DataBind", BindingFlags.GetProperty, null, oItem.Specific, new object[] { });
                    Type DataBindType = Type.GetTypeFromCLSID(new Guid("D63C347F-9710-420F-854D-7C3112DC9D1D"));
                    DataBindType.InvokeMember("SetBound", BindingFlags.InvokeMethod, null, GetMemberValue, new object[] { true, "", "UD" + i.ToString() });
                }
            }

            ButonOk = oForm.Items.Add("OK", SAPbouiCOM.BoFormItemTypes.it_BUTTON).ItemCast<SAPbouiCOM.Button>();
            ButonOk.Caption = "Tamam";
            ButonOk.Item.Top = oItem.Top + 20;
            ButonOk.Item.Left = 10;

            ButonOk.ClickBefore += ButonOk_ClickBefore;

            ButonCancel = oForm.Items.Add("CANCEL", SAPbouiCOM.BoFormItemTypes.it_BUTTON).ItemCast<SAPbouiCOM.Button>();
            ButonCancel.Caption = "İptal";
            ButonCancel.Item.Top = oItem.Top + 20;
            ButonCancel.Item.Left = ButonOk.Item.Left + ButonOk.Item.Width + 5;

            ButonCancel.ClickBefore += ButonCancel_ClickBefore;

            oForm.Height = ButonOk.Item.Top + 75 ;
            oForm.Width = 288;

            oForm.Visible = true;
        }
        private void ButonOk_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            OkAction(this);
        }
        private void ButonCancel_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            CancelAction(this);
        }

    }
}
