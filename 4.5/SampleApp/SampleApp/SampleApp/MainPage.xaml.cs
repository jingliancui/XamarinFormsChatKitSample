using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void DialogsListBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DialogsListPage());
        }

        private async void MessagesListBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessagesListPage());
        }

        private async void MessageInputBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessageInputPage());
        }
    }
}
