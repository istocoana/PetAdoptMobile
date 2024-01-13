
using PetAdoptM.ViewsModels;

namespace PetAdoptM.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardPageViewModeel();
    }
}