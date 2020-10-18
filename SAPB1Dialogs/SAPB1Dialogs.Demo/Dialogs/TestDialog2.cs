using SAPB1Dialogs.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPB1Dialogs.Demo.Dialogs
{
    public class TestDialog2 : AbstractInputDialog
    {
        public TestDialog2()
        {
            NewInput<ShortEditTextInput>()
                .SetLabelCaption("Input Value1")
                .SetDataLength(250);

            NewInput<PriceEditTextInput>()
                .SetLabelCaption("Input Value2")
                .SetDataLength(25);

            var Values = new Dictionary<string, string>()
            {
                {"1", "Tedarikciye Ciro" },
                {"2", "Bankaya Çıkış/Ibraz"},
                {"3", "Kırdırmaya Çıkış"},
                {"4", "Müşteriye İade"},
                {"5", "Bankada Karşılıksız Müşteriye İade"},
                {"6", "Ciro İptal"},
                {"7", "Cirodan Karşılıksıza İade"},
                {"8", "Bankada Tahsil Edildi"},
                {"9", "Ödeme(Kırdırma)"},
                {"10", "Bankadan İade"},
                {"11", "Bankadan Karşılıksıza İade"},
                {"12", "Kırdırım İptal"},
                {"13", "Kırdırım Karşılıksız"},
                {"14", "Tahsile Verilenin Geri Alınması"},
                { "15", "Elden Tahsil Edilme"},
            };

            NewInput<ComboBoxInput>()
                .SetValidValues(Values)
                .SetLabelCaption("Input Value3")
                .SetDataLength(50);

            NewInput<DateEditTextInput>()
                .SetLabelCaption("Input Value4")
                .SetDataLength(250);

            NewInput<QuantityEditTextInput>()
                .SetLabelCaption("Input Value5")
                .SetDataLength(25);
        }
    }
}
