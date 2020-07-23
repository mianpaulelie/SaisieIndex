using SaisieIndex.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;


namespace SaisieIndex.Views
{
    public class EditNouvelIndex : ContentPage
    {
        private ListView _listView;
        private Entry _idclientEntry;
        private Entry _nomEntry;
        private Entry _genreEntry;
        private Entry _souscriptionEntry;
        private Button _button;

        NouvelIndex _nouvelIndex = new NouvelIndex();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        

        public EditNouvelIndex()
        {
            this.Title = "Modifier Index";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<NouvelIndex>().OrderBy(x => x.Nom).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idclientEntry = new Entry();
            _idclientEntry.Placeholder = "ID";
            _idclientEntry.IsVisible = false;
            stackLayout.Children.Add(_idclientEntry);

            _nomEntry = new Entry();
            _nomEntry.Keyboard = Keyboard.Text;
            _nomEntry.Placeholder = "Nom nouvel index";
            stackLayout.Children.Add(_nomEntry);

            _genreEntry = new Entry();
            _genreEntry.Keyboard = Keyboard.Text;
            _genreEntry.Placeholder = "Genre";
            stackLayout.Children.Add(_genreEntry);

            _souscriptionEntry = new Entry();
            _souscriptionEntry.Keyboard = Keyboard.Text;
            _souscriptionEntry.Placeholder = "Souscription";
            stackLayout.Children.Add(_souscriptionEntry);

            _button = new Button();
            _button.Text = "Modifier";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            NouvelIndex nouvelIndex = new NouvelIndex()
            {
                IdClient = Convert.ToInt32(_idclientEntry.Text),
                Nom = _nomEntry.Text,
                Genre = _genreEntry.Text,
                Souscription = _souscriptionEntry.Text
            };
            db.Update(nouvelIndex);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _nouvelIndex = (NouvelIndex)e.SelectedItem;
            _idclientEntry.Text = _nouvelIndex.IdClient.ToString();
            _nomEntry.Text = _nouvelIndex.Nom;
            _genreEntry.Text = _nouvelIndex.Genre;
            _souscriptionEntry.Text = _nouvelIndex.Souscription;
        }
    }
}