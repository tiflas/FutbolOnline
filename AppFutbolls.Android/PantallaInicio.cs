using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFutbolls.Droid
{
    [Activity(Label = "AppFutbol", Icon = "@mipmap/iconocancha", Theme = "@style/nuevotema", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class PantallaInicio : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            // Create your application here
        }
    }
}