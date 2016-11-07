using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using System.Threading.Tasks;

namespace iEducator.Droid
{
    [Activity(Label = "IEducator", MainLauncher = true, NoHistory = true)]
    public class WelcomeScreenSplash : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash);
            Task startupwork = new Task(() =>
            {
              
                Task.Delay(5000);
            });

            startupwork.ContinueWith(t =>
            {
                StartActivity(new Intent(Application.Context, typeof(IEducatorHomePage)));
            }, TaskScheduler.FromCurrentSynchronizationContext());
            startupwork.Start();
            // Create your application here
        }

       
    }
}