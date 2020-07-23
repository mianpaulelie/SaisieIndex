using SaisieIndex.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;

namespace SaisieIndex.Views
{
    public class DeleteNouvelIndex : ContentPage
    {
        private ListView _listView;
        private Button _button;

        NouvelIndex _nouvelIndex = new NouvelIndex();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteNouvelIndex()
        {
            this.Title = "Modifier Index";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<NouvelIndex>().OrderBy(x => x.Nom).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _nouvelIndex = (NouvelIndex)e.SelectedItem;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<NouvelIndex>().Delete(x => x.IdClient == _nouvelIndex.IdClient);
            await Navigation.PopAsync();
        }

    }
}