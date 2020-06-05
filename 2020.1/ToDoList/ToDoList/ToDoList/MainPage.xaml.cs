using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Model;
using Xamarin.Forms;

namespace ToDoList
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Simular os dados
            Database.activities.Add(new Activity("Atividade 1"));
            Database.activities.Add(new Activity("Atividade 2"));
            Database.activities.Add(new Activity("Atividade 3"));
            Database.activities.Add(new Activity("Atividade 4"));

            lstActivities.ItemsSource = Database.activities;

            Title = "TODO List";
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entActivityName.Text))
            {
                DisplayAlert("Erro", "O campo atividade é requerido", "OK");
            }
            else
            {
                Activity activity = new Activity(entActivityName.Text);
                
                Database.activities.Add(activity);

                DisplayAlert("Cadastro", "Atividade cadastrada com sucesso!", "OK");

                entActivityName.Text = "";
            }
        }

        private async void lstActivities_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Activity activitySelected = (Activity)e.SelectedItem;

            Details detailsPage = new Details(activitySelected);

            await Navigation.PushAsync(detailsPage);
        }
    }
}
