using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppFutbolls.MainPage;

namespace AppFutbolls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePartido : ContentPage
    {
        public DetallePartido(FixtureResponse fixture)
        {
            InitializeComponent();
            this.BindingContext = fixture;
        }

        private async void Volver(object sender, EventArgs e)
        {
            MainPage Inicio = new MainPage();
            NavigationPage navigationPage = new NavigationPage(Inicio);
            Application.Current.MainPage = navigationPage;
            await Navigation.PopAsync();
        }
    }
}