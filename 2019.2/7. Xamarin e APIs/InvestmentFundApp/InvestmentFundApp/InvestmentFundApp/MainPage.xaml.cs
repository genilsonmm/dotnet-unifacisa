using InvestmentFundApp.Model;
using InvestmentFundApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InvestmentFundApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Fund> funds;
        private FundService fundService;

        public MainPage()
        {
            InitializeComponent();

            //Remover navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            fundService = new FundService();
            funds = new ObservableCollection<Fund>();

            lstFunds.ItemsSource = funds;

            GetAllFunds();
        }

        private async void GetAllFunds()
        {
            try
            {
                var response = await fundService.GetAll();
                funds.Clear();
                foreach (var item in PreperFunds(response))
                {
                   funds.Add(item);
                }
            }
            catch
            {
                await DisplayAlert("Cadastro de ativos", "Falha de conexão", "Ok");
            }
        }

        private List<Fund> PreperFunds(List<Fund> response)
        {
            List<Fund> groupFunds = new List<Fund>();

            foreach (var item in response)
            {
                Fund currentFund = groupFunds.Where(f => f.Name.Equals(item.Name)).FirstOrDefault();
                if (currentFund != null)
                {
                    currentFund.Quantity += item.Quantity;
                    currentFund.Price += item.Price;
                }
                else
                {
                    groupFunds.Add(item);
                }
            }

            return groupFunds;
        }

        private async void LstFunds_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Fund selectedFund = (Fund)e.SelectedItem;
            await Navigation.PushAsync(new Details(selectedFund.Name));
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Fund newFund = new Fund();
                newFund.Name = entFund.Text;
                newFund.Quantity = int.Parse(entQuantity.Text);
                newFund.Price = double.Parse(entPrice.Text);

                //funds.Add(newFund);
                await fundService.Post(newFund);

                await DisplayAlert("Cadastro de ativos", "Novo ativo cadastrado com sucesso!", "Ok");

                GetAllFunds();
                ClearForm();
            }
            catch
            {
                await DisplayAlert("Cadastro de ativos", "Ocorreu um erro ao cadastrar novo ativo!", "Ok");
            }
        }

        private void ClearForm()
        {
            entPrice.Text = "";
            entQuantity.Text = "";
            entFund.Text = "";
        }
    }
}
