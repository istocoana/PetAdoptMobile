using PetAdoptM.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using PetAdoptM.Models;

namespace PetAdoptM
{
    public partial class AnimalePage : ContentPage
    {
        private List<Locatie> locatiiList;

        public AnimalePage()
        {
            InitializeComponent();
            BindingContext = new Animale(); 
            LoadLocations();
        }

        private async void LoadLocations()
        {
            locatiiList = await App.Database.GetLocatieAsync();
            if (locatiiList != null && locatiiList.Any())
            {
                LocatiePicker.ItemsSource = locatiiList;
                LocatiePicker.ItemDisplayBinding = new Binding("Localitate");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var animale = (Animale)BindingContext;
            animale.LocatieID = (LocatiePicker.SelectedItem as Locatie)?.ID ?? 0;
            await App.Database.SaveAnimaleAsync(animale);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var animale = (Animale)BindingContext;
            await App.Database.DeleteAnimaleAsync(animale);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipuriPage((Animale)this.BindingContext)
            {
                BindingContext = new Animale()
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            
            var locations = await App.Database.GetLocatieAsync();
            LocatiePicker.ItemsSource = locations;
            LocatiePicker.ItemDisplayBinding = new Binding("Localitate");

            
            var animale = (Animale)BindingContext;
            if (animale.LocatieID != 0)
            {
                LocatiePicker.SelectedItem = locations.FirstOrDefault(loc => loc.ID == animale.LocatieID);
            }

          
            listView.ItemsSource = await App.Database.GetTipAsync(animale.ID);
        }

        async void OnAddTipButtonClicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new TipuriPage((Animale)BindingContext));
        }
    }
}

