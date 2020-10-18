using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;
using SAPB1Dialogs.Demo.Dialogs;

namespace SAPB1Dialogs.Demo
{
    [FormAttribute("SAPB1Dialogs.Demo.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_5").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.StaticText StaticText1;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            TestDialog Dialog = new TestDialog();

            Dialog.DoOk(o =>
            {
                (this.UIAPIRawForm.Items.Item("Item_2").Specific as SAPbouiCOM.EditText).Value = (o.RawForm.Items.Item("Input1").Specific as SAPbouiCOM.EditText).Value;
                (this.UIAPIRawForm.Items.Item("Item_1").Specific as SAPbouiCOM.EditText).Value = (o.RawForm.Items.Item("Input2").Specific as SAPbouiCOM.EditText).Value;
                o.RawForm.Close();
            });

            Dialog.DoCancel(o =>
            {
                o.RawForm.Close();
            });

            Dialog.ShowModal();

        }
    }
}