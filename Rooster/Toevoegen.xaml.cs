using Rooster.Models;
using Rooster.Data;
using System.Collections.ObjectModel;
using System;

namespace Rooster;

public partial class Toevoegen : ContentPage
{
	public Toevoegen()
	{
		InitializeComponent();
		
	}
	private async void lesToevoegen(object sender, EventArgs e)
	{
		var database = await Database.GetDatabase();

		var vak = new Vak { Naam = vakNaamEntry.Text, Beschrijving = vakBeschrijvingEntry.Text };
		await database.InsertAsync(vak);

		var docent = new Docent { Naam = docentNaamEntry.Text, };
		await database.InsertAsync(docent);

		var lokaal = new Lokaal { KlasLokaal = lokaalEntry.Text };
		await database.InsertAsync(lokaal);

		var dag = new Dag { Datum = datumPicker.Date, };
		await database.InsertAsync(dag);

		var les = new Les
		{
			VakId = vak.VakId,
			DocentId = docent.DocentId,
			DagId = dag.DagId,
			LokaalId = lokaal.LokaalId,
			StartTijd = TimeSpan.Parse(startTijdEntry.Text),
			EindTijd = TimeSpan.Parse(eindTijdEntry.Text)
		};
		await database.InsertAsync(les);

		vakNaamEntry.Text = string.Empty;
		vakBeschrijvingEntry.Text = string.Empty;
		docentNaamEntry.Text = string.Empty;
		lokaalEntry.Text = string.Empty;
		startTijdEntry.Text = string.Empty;
		eindTijdEntry.Text = string.Empty;

		await Shell.Current.GoToAsync("MainPage");
	}
}