using SaisieIndex.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaisieIndex.Views
{
    public class GetAllSaisieIndex : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllSaisieIndex()
        {
            this.Title = "IndexSaisies";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<NouvelIndex>().OrderBy(x => x.Nom).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}