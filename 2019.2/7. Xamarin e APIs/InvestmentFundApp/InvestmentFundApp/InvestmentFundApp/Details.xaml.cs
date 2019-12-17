using InvestmentFundApp.Model;
using InvestmentFundApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InvestmentFundApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public ObservableCollection<Fund> fundsHistory;
        private string name;

        public Details(string name)
        {
            InitializeComponent();

            //Remover navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            this.name = name;
            fundsHistory = new ObservableCollection<Fund>();

            lstHistory.ItemsSource = fundsHistory;
            ShowData();
        }

        private async void ShowData()
        {
            lblFundName.Text = this.name;
            double totalValue = 0;

            FundService fundService = new FundService();
            var response = await fundService.GetByName(name);

            fundsHistory.Clear();

            foreach (var item in response)
            {
                totalValue += item.Price;
                fundsHistory.Add(item);
            }

            lblTotal.Text = $"R$ {totalValue}"; 
        }

        private async void BtnPrevious_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}