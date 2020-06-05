using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public Details(Activity activity)
        {
            InitializeComponent();

            lblName.Text = activity.Name;
            lblDate.Text = activity.Date.ToString();

            Title = "Detalhes da ação";
        }

        private async void btnPrevious_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}