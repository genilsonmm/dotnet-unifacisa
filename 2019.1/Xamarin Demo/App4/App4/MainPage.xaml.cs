using App4.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public string Message { get; }

        private ObservableCollection<User> users = new ObservableCollection<User>();
        private JsonSerializer _serializer = new JsonSerializer();

        public MainPage()
        {
            //http://www.macoratti.net/17/02/xamand_rhttpc1.htm
            
            InitializeComponent();

            Title = "Principal";
            lblMessage.Text = "Olá Xamarin Forms";

            InicializeList();
        }

        private async void InicializeList()
        {
            List<User> users = await Get();
            lstItens.ItemsSource = users;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Dialog", "Olá botão sem bind", "Ok");

            users.Add(new User() { Login = entCurso.Text });
            entCurso.Text = "";
            entCurso.Focus();
        }

        private async void LstItens_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User user = e.SelectedItem as User;

            //DisplayAlert("Dialog", p.Name, "Ok");


            await Navigation.PushAsync(new Page1());
        }

        private async Task<List<User>> Get()
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://api.github.com/users");
                var uri = "https://api.github.com/users";

                // GitHub API versioning
                client.DefaultRequestHeaders.Add("Accept",
                    "application/vnd.github.v3+json");
                // GitHub requires a user-agent
                client.DefaultRequestHeaders.Add("User-Agent",
                    "HttpClientFactory-Sample");

                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<List<User>>(result);
            }
        }
    }
}
