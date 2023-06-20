namespace PerfectPay;

public partial class MainPage : ContentPage
{
    decimal bill;
    int tip;
    int noPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    private void txt_bill_Completed(object sender, EventArgs e)
    {
        bill = decimal.Parse(txt_bill.Text);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        var totalTip = (bill * tip) / 100;
        var tipByPerson = totalTip / noPersons;
        label_tipByPerson.Text = $"{tipByPerson:C}";

        var subtotal = bill / noPersons;
        label_subtotal.Text = $"{subtotal:C}";

        var totalByPerson = (bill + totalTip) / noPersons;
        label_Total.Text = $"{totalByPerson:C}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percent = int.Parse(btn.Text.Replace(" %", ""));
            slider_tip.Value = percent;
        }
    }

    private void slider_tip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)slider_tip.Value;
        label_tip.Text = $"Tip: {tip} %";
        CalculateTotal();
    }

    private void btn_minus_Clicked(object sender, EventArgs e)
    {
        if (noPersons > 1)
        {
            noPersons--;
            label_noPersons.Text = noPersons.ToString();
            CalculateTotal();
        }
    }

    private void btn_plus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        label_noPersons.Text = noPersons.ToString();
        CalculateTotal();
    }
}

