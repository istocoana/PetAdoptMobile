using PetAdoptM.Models;
using Microsoft.Maui.Controls;
using System;

namespace PetAdoptM
{
    public partial class AnimaleEntryPage : ContentPage
    {
        public AnimaleEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAnimaleAsync();
        }

        async void OnAnimaleAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnimalePage
            {
                BindingContext = new Animale()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedAnimale = e.SelectedItem as Animale;

                // Load the location information for the selected animal
                selectedAnimale.Locatie = await App.Database.GetLocatieAsync(selectedAnimale.LocatieID);

                await Navigation.PushAsync(new AnimalePage
                {
                    BindingContext = selectedAnimale
                });
            }
        }

    }
}

