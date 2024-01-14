using PetAdoptM.Models;
namespace PetAdoptM;

public partial class AnimaleEntryPage : ContentPage
{
	public AnimaleEntryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int animalId = 1; 
        var animaleList = await App.Database.GetAnimaleAsync(animalId);

       
        foreach (var animale in animaleList)
        {
            animale.Locatie = await App.Database.GetLocatieAsync(animale.LocatieID);
        }

        listView.ItemsSource = animaleList;
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
            await Navigation.PushAsync(new AnimalePage
            {
                BindingContext = e.SelectedItem as Animale
            });
        }
    }
}