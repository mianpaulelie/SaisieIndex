using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaisieIndex.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {

            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Nouvel Index";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjouterIndex());
        }
    }
}


