using System;
using PetAdoptM.Data;
using System.IO;

namespace PetAdoptM;

public partial class App : Application
{
    static AnimaleDatabase database;
    public static AnimaleDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               AnimaleDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Animale.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
