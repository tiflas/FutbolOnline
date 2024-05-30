using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using static AppFutbolls.MainPage;
using System.Numerics;

namespace AppFutbolls
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            ActualizarHome(); 
        }
        public class Status
        {
            [JsonProperty("long")]
            public string Longg { get; set; }
            [JsonProperty("short")]
            public string Shortt { get; set; }
            [JsonProperty("elapsed")]
            public string Elapsed { get; set; }
        }
        public class Venue
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }
        }
        public class league
        {
            [JsonProperty("logo")]
            public string Logo { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }
            [JsonProperty("country")]
            public string country { get; set; }
            [JsonProperty("flag")]
            public string flag { get; set; }
        }

        public class Teams
        {
            [JsonProperty("home")]
            public Team Home { get; set; }

            [JsonProperty("away")]
            public Team Away { get; set; }
        }

        public class Team
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("logo")]
            public string Logo { get; set; }

            [JsonProperty("winner")]
            public bool? Winner { get; set; }
        }

        public class Goals
        {
            [JsonProperty("home")]
            public int Home { get; set; }

            [JsonProperty("away")]
            public int Away { get; set; }
        }

        public class Score
        {
            [JsonProperty("halftime")]
            public Halftime halftime { get; set; }
            [JsonProperty("fulltime")]
            public Fulltime fulltime { get; set; }
            [JsonProperty("extratime")]
            public Extratime extratime { get; set; }
            [JsonProperty("penalty")]
            public Penalty penalty { get; set; }
        }

        public class Halftime
        {
            [JsonProperty("home")]
            public int home { get; set; }
            [JsonProperty("away")]
            public int away { get; set; }
        }

        public class Fulltime
        {
            [JsonProperty("home")]
            public object home { get; set; }
            [JsonProperty("away")]
            public object away { get; set; }
        }

        public class Extratime
        {
            [JsonProperty("home")]
            public object home { get; set; }
            [JsonProperty("away")]
            public object away { get; set; }
        }

        public class Penalty
        {
            [JsonProperty("home")]
            public object home { get; set; }
            [JsonProperty("away")]
            public object away { get; set; }
        }

        public class Fixture
        {
            [JsonProperty("referee")]
            public string referee { get; set; }
            [JsonProperty("date")]
            public string date { get; set; }
            [JsonProperty("venue")]
            public Venue venue { get; set; }
            [JsonProperty("status")]
            public Status Status { get; set; }
        }

        public class Player
        {
            [JsonProperty("name")]
            public string name { get; set; }
        }

        public class Assist
        {
            [JsonProperty("name")]
            public string name { get; set; }
        }

        public class Time
        {
            [JsonProperty("elapsed")]
            public int elapsed { get; set; }
        }

        public class Event
        {
            [JsonProperty("time")]
            public Time time { get; set; }
            [JsonProperty("team")]
            public Team team { get; set; }
            [JsonProperty("player")]
            public Player player { get; set; }
            [JsonProperty("assit")]
            public Assist assist { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
            [JsonProperty("detail")]
            public string detail { get; set; }
            [JsonProperty("comments")]
            public object comments { get; set; }
        }

        public class FixtureResponse
        {
            [JsonProperty("teams")]
            public Teams Teams { get; set; }
            [JsonProperty("goals")]
            public Goals Goals { get; set; }
            [JsonProperty("league")]
            public league league { get; set; }
            [JsonProperty("score")]
            public Score score { get; set; }
            [JsonProperty("events")]
            public List<Event> Event { get; set; }
            [JsonProperty("fixture")]
            public Fixture Fixture { get; set; }

        }

        public class ApiResponse
        {
            [JsonProperty("response")]
            public List<FixtureResponse> Response { get; set; }
        }
        private async void ActualizarHome()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "d339faf3955e6df4f88261d01c59f641");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");

            HttpResponseMessage response = await httpClient.GetAsync("https://v3.football.api-sports.io/fixtures?live=all");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                MatchesCollectionView.ItemsSource = apiResponse.Response;
                MatchesCollectionView.ItemTapped += ListView_ItemTapped; // Manejar el evento ItemTapped
            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedFixture = e.Item as FixtureResponse;

                // Navegar a la página "Detalle" pasando el objeto seleccionado como parámetro
                await Navigation.PushAsync(new DetallePartido(selectedFixture));
            }
        }
        private async void Actualizar(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "d339faf3955e6df4f88261d01c59f641");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");

            HttpResponseMessage response = await httpClient.GetAsync("https://v3.football.api-sports.io/fixtures?live=all");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                MatchesCollectionView.ItemsSource = apiResponse.Response;
                MatchesCollectionView.ItemTapped += ListView_ItemTapped; // Manejar el evento ItemTapped
            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
            }
        }
    }
}
