using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : TabbedPage
    {
        string name;
        public Calculator(string username)
        {
            InitializeComponent();
            procent.Text = $"0%";
            usd.Text = "90p";
            eur.Text = "100p";
            this.name = username;
            UserNameT.Title = $"Кредитный калькулятор{name}a";
        }
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            procent.Text = $"{value}%";
            Insert();
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Insert();
        }

        private void OnTextChangedSum(object sender, TextChangedEventArgs e)
        {
            Insert();
        }

        private void OnTextChangedSrock(object sender, TextChangedEventArgs e)
        {
            Insert();
        }

        private void Insert()
        {
            if (SrockEntry.Text != "" && SumEntry.Text != "" && picker.SelectedIndex != -1)
            {
                int sumKred = int.Parse(SumEntry.Text);
                double srock = int.Parse(SrockEntry.Text);

                double i = (slider.Value / 100) / 12;

                if (srock > 0)
                {
                    double A = sumKred * ((i * Math.Pow((1 + i), srock)) / (Math.Pow((1 + i), srock) - 1));

                    double totalPayment = A * srock;
                    double overpayment = totalPayment - sumKred;

                    ObsPlat.Text = totalPayment.ToString("F2");
                    EzPlat.Text = A.ToString("F2");
                    Pereplata.Text = overpayment.ToString("F2");
                }
            }
        }
    }
}