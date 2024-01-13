
using PetAdoptM.Models;
namespace PetAdoptM;

public partial class LocatieEntryPage : ContentPage
{
	public LocatieEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetLocatieAsync();
    }
    async void OnLocatieAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LocatiePage
        {
            BindingContext = new Locatie()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new LocatiePage
            {
                BindingContext = e.SelectedItem as Locatie
            });
        }
    }

}
