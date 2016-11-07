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
using Android.Media;
using Android.Hardware;
//using Android.Hardware;
//using Android.Graphics;

namespace iEducator.Droid
{
    [Activity(Label = "TopicsVideoActivity",Theme ="@style/MyTheme.NoActionBar")]
    public class TopicsVideoActivity : AppCompatActivity
    {
        private VideoView video;
        private ListView topicList;
        // private TextureView textureView;
        //private MediaPlayer mPlayer;
        //private Camera _camera;
        MediaController ctrl;
        protected override void OnStart()
        {
            base.OnStart();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);

                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

                Window.SetStatusBarColor(Android.Graphics.Color.Black);
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_topics_video);
            
            video = FindViewById<VideoView>(Resource.Id.videoView1);
            topicList = FindViewById<ListView>(Resource.Id.listOftopics);

            string[] list = new string[] { "Negative numbers: addition and subtraction",
            "Negative numbers: multiplication and division",
            "Fractions, decimals, & percentages",
            "Rates & proportional relationships.Expressions",
            "Equations",
            "inequalities",
            "Geometry",
            "Statistics and probability"};


            ArrayAdapter adapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1,list);

            topicList.Adapter = adapter;

            //topicList.SetAdapter(adapter);

            var uri= Android.Net.Uri.Parse("android.resource://" + Application.PackageName + "/" + Resource.Raw.demo);
            
            video.SetVideoURI(uri);

            

           // video.Start();

            //textureView.listner
            ctrl = new MediaController(this);
            
            //  ctrl.SetMediaPlayer(video);
            video.SetMediaController(ctrl);

            ctrl.SetAnchorView(video);

            video.RequestFocus();


            video.Start();


            //textureView = new TextureView(this);
            
            //textureView = FindViewById<TextureView>(Resource.Id.textureView1);

            //textureView.SurfaceTextureListener = this;


            //SetContentView(textureView);
            
        

            



        }

        //public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        //{
        //    //Surface s = new Surface(surface);
        //    ////throw new NotImplementedException();
        //    //var uri = Android.Net.Uri.Parse("android.resource://" + Application.PackageName + "/" + Resource.Raw.demo);
        //    //try
        //    //{
        //    //    mPlayer = new MediaPlayer();
        //    //    mPlayer.SetDataSource(""+uri);
        //    //    mPlayer.SetSurface(s);
        //    //    mPlayer.Prepare();
        //    //    mPlayer.SetOnBufferingUpdateListener=Application.Context;

        //    //}
        //    //catch
        //    //{

        //    //}




        //    _camera = Camera.Open();
        //    var previewSize = _camera.GetParameters().PreviewSize;
        //    textureView.LayoutParameters =
        //        new FrameLayout.LayoutParams(previewSize.Width,
        //            previewSize.Height, (int)GravityFlags.Center);

        //    try
        //    {
        //        _camera.SetPreviewTexture(surface);
        //        _camera.StartPreview();
        //    }
        //    catch (Java.IO.IOException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    // this is the sort of thing TextureView enables
        //    textureView.Rotation = 45.0f;
        //    textureView.Alpha = 0.5f;
        //}

        //public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            
        }
        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            video.Start();
        }


    }





}