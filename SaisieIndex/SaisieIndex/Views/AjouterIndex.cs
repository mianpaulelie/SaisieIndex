using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using SaisieIndex.Models;

using Xamarin.Forms;

namespace SaisieIndex.Views
{
    public class AjouterIndex : ContentPage
    {
        private Entry _nomEntry;
        private Entry _genreEntry;
        private Entry _souscriptionEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AjouterIndex ()
        {
            this.Title = "Ajouter un index";

            StackLayout stackLayout = new StackLayout();

            _nomEntry = new Entry();
            _nomEntry.Keyboard = Keyboard.Text;
            _nomEntry.Placeholder = "Nom Client";
            stackLayout.Children.Add(_nomEntry);

            _genreEntry = new Entry();
            _genreEntry.Keyboard = Keyboard.Text;
            _genreEntry.Placeholder = "Genre Client";
            stackLayout.Children.Add(_genreEntry);

            _souscriptionEntry = new Entry();
            _souscriptionEntry.Keyboard = Keyboard.Text;
            _souscriptionEntry.Placeholder = "Souscription Client";
            stackLayout.Children.Add(_souscriptionEntry);

            _saveButton = new Button();
            _saveButton.Text = "Ajouter";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<NouvelIndex>();

            var maxPk = db.Table<NouvelIndex>().OrderByDescending(c => c.IdClient).FirstOrDefault();

            NouvelIndex nouvelIndex = new NouvelIndex()
            {
                IdClient = (maxPk == null ? 1 : maxPk.IdClient + 1),
                Nom = _nomEntry.Text,
                Genre = _genreEntry.Text,
                Souscription = _souscriptionEntry.Text
            };
            db.Insert(nouvelIndex);
            await DisplayAlert(null, nouvelIndex.Nom + " Sauver", "Ok");
            await Navigation.PopAsync();
        }
    }
}