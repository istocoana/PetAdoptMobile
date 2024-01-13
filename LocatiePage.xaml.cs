
using PetAdoptM.Models;

namespace PetAdoptM;

public partial class LocatiePage : ContentPage
{
    public LocatiePage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var locatie = (Locatie)BindingContext;
        await App.Database.SaveLocatieAsync(locatie);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var locatie = (Locatie)BindingContext;
        await App.Database.DeleteLocatieAsync(locatie);
        await Navigation.PopAsync();
    }
}

