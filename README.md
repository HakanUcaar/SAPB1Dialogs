# SAPB1Dialogs
SAP Business One dilog form oluşturma kütüphanesi

## Örnek Dialog Oluşturma Kodu
```CSharp
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
```

## Kullanım Kodu
```CSharp
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
```

![SAPB1Dialogs1.gif](https://github.com/HakanUcaar/SAPB1Dialogs/blob/main/imgs/SAPB1Dialogs1.gif)

## Daha Farklı Veri Girişleri için Örnek Dialog Kodu
```CSharp
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
```
## Kullanım Kodu
```CSharp
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
```
![SAPB1Dialogs2.gif](https://github.com/HakanUcaar/SAPB1Dialogs/blob/main/imgs/SAPB1Dialogs2.gif)
