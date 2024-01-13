using Microsoft.Maui.Controls;
using PetAdoptM.Models;

namespace PetAdoptM
{
    public partial class TipuriPage : ContentPage
    {
        Animale a;

        public TipuriPage(Animale ani)
        {
            InitializeComponent();
            LoadTipuri();
            a = ani;
            BindingContext = a;
        }

        private async void LoadTipuri()
        {
            var tipuriList = await App.Database.GetTipAsync();
            if (tipuriList != null && tipuriList.Any())
            {
                listView.ItemsSource = tipuriList;
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            
            await App.Database.SaveAnimaleAsync(a);
            listView.ItemsSource = await App.Database.GetTipAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            
            await App.Database.DeleteAnimaleAsync(a);
            listView.ItemsSource = await App.Database.GetTipAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTipAsync(a.ID);
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            Tipuri selectedTipuri = (Tipuri)listView.SelectedItem;

            if (selectedTipuri != null)
            {
                var animale = (Animale)BindingContext;
                animale.TipuriID = selectedTipuri.ID; 
                await App.Database.SaveAnimaleAsync(animale);
                await Navigation.PopAsync();
            }
        }

    }
}
