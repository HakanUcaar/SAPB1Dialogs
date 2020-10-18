using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SAPB1Dialogs.Demo.Dialogs;

namespace SAPB1Dialogs.Demo
{
    [FormAttribute("SAPB1Dialogs.Demo.Form2", "Form2.b1f")]
    class Form2 : UserFormBase
    {
        public Form2()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
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

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            TestDialog2 Dialog = new TestDialog2();

            Dialog.DoOk(o =>
            {
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
