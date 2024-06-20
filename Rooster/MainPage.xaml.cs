using System;
using Rooster.Data;
using Rooster.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using static Microsoft.Maui.Controls.Internals.Profile;
namespace Rooster
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Les> _lessen;
        private DateTime _selectedDate;
        public MainPage()
        {
            InitializeComponent();
            _lessen = new ObservableCollection<Les>();
            lessenListView.ItemsSource = _lessen;
            _selectedDate = DateTime.Now;
        }
        protected override async void bijOpstarten()
        {
            base.bijOpstarten();
            await LaadLessen(_selectedDate);
        }
        private async void datumGeselecteerd(object sender, DateChangedEventArgs e)
        {
            _selectedDate = e.NewDate;
            await LaadLessen(_selectedDate);

        }
        private async void LaadLessen()
        {
            var lessen = await GetLessenDetails();
            _lessen.Clear();
            foreach (var les in lessen)
            {
                _lessen.Add(les);
            }
        }
        private async Task<List<Les>> GetLessenDetails(DateTime datum)
        {
            var database = await Database.GetDatabase();
            string geformatteerdeDatum = datum.ToString("yyyy-MM-dd");

            var lessen = await database.Table<Les>()
                                       .Where(1 => 1.Datum == geformatteerdeDatum)
                                       .ToListAsync();

            foreach (var les in lessen)
            {
                var vak = await database.FindAsync<Vak>(les.VakId);
                if (vak != null )
                {
                    les.VakNaam = vak.Naam;
                }
                var docent = await database.FindAsync<Docent>(les.DocentId);
                if (docent != null )
                {
                    les.DocentNaam = docent.Naam;
                }
                var lokaal = await database.FindAsync<Lokaal>(les.LokaalId);
                if (lokaal != null )
                {
                    les.KlasLokaal = lokaal.KlasLokaal;
                }
            }
            return lessen;
        }

    }

}