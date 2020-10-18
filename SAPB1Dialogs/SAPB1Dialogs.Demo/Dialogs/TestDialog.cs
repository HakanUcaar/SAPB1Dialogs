using SAPB1Dialogs.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs.Demo.Dialogs
{
    public class TestDialog : AbstractInputDialog
    {
        public TestDialog()
        {
            NewInput<ShortEditTextInput>()
                .SetLabelCaption("Input Value1")
                .SetDataLength(250);

            NewInput<ShortEditTextInput>()
                .SetLabelCaption("Input Value2")
                .SetDataLength(250);
        }
    }
}
