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
using Google.YouTube.Player;

namespace iEducator.Droid
{
    [Activity(Label = "YouTubePlayerActivity")]
    public class YouTubePlayerActivity : YouTubeBaseActivity,IYouTubePlayerOnInitializedListener
    {
        private int RECOVERY_DIALOG_REQUEST = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_topics_youtube_player);
            YouTubePlayerView youtubeplayer = FindViewById<YouTubePlayerView>(Resource.Id.youtube_view);

            
            youtubeplayer.Initialize(DevConstants.DEVELOPER_KEY,this);

        }
        public void OnInitializationFailure(IYouTubePlayerProvider p0, YouTubeInitializationResult p1)
        {
            //throw new NotImplementedException();
            if (p1.IsUserRecoverableError)
            {
                p1.GetErrorDialog(this, RECOVERY_DIALOG_REQUEST).Show();
            }
            else
            {
                String errorMessage = String.Format("this is weared", p1.ToString());
                Toast.MakeText(this, "" + p1, ToastLength.Long).Show();
            }
        }

        public void OnInitializationSuccess(IYouTubePlayerProvider p0, IYouTubePlayer p1, bool p2)
        {

            string uri = "android.resource://" + Application.PackageName + "/" + Resource.Raw.demo;
            //Uri uri = Android.Net.Uri.Parse("android.resource://" + Application.PackageName + "/" + Resource.Raw.demo).ToString();


            //   p1.SetPlayerStyle(YouTubePlayerPlayerStyle.Default);

            // p1.LoadVideo(DevConstants.VIDEO_ID);
            p1.LoadVideo(uri);
            //throw new NotImplementedException();
        }

    }
}