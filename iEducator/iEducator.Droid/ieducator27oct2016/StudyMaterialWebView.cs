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
using Android.Webkit;
using Java.Lang;

namespace iEducator.Droid
{
    [Activity(Label = "StudyMaterial")]
    public class StudyMaterialWebView : AppCompatActivity
    {
        protected static WebView webViewStudyMaterial;
        protected static View loadingSpinner;
        private WebViewClient webViewclient = new Mywebview(); 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_study_material);
            // Create your application here
            webViewStudyMaterial = FindViewById<WebView>(Resource.Id.LocalWebViewStudy);
            loadingSpinner = FindViewById(Resource.Id.loading_spinner);
            webViewStudyMaterial.SetWebViewClient(webViewclient);  // stops request going to Web Browser

           // http://developer.xamarin.com
            webViewStudyMaterial.LoadUrl("https://en.wikipedia.org/wiki/Negative_number");

            //  webViewStudyMaterial.Settings.JavaScriptEnabled = true;// to enable the javascript

            // this = YourActivity
        
            //MyTask c = new MyTask();
            //c.Execute();
        }
        public class Mywebview : WebViewClient
        {
            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);

                loadingSpinner.Visibility = ViewStates.Gone;
                webViewStudyMaterial.Visibility = ViewStates.Visible;

            }

            public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
            {
                base.OnPageStarted(view, url, favicon);
                loadingSpinner.Visibility = ViewStates.Visible;
                webViewStudyMaterial.Visibility = ViewStates.Invisible;
            }
            //public override void OnReceivedError(WebView view, ClientError errorCode, string description, string failingUrl)
            //{
            //    Log.Error(TAG, "Error " + errorCode + ": " + description);
            //    Toast.MakeText(view.Context, "Error " + errorCode + ": " + description, ToastLength.Long).Show();
            //    base.OnReceivedError(view, errorCode, description, failingUrl);
            //}

            public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
            {
                base.OnReceivedError(view, request, error);
            }


        }


        //public class MyTask : AsyncTask
        //{


        //    //ProgressDialog dialog;
        //   // Context c_context;




        //    protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        //    {


        //        webViewStudyMaterial.LoadUrl("http://developer.xamarin.com");


        //        return true;
        //        // throw new NotImplementedException();
        //    }
        //    protected override void OnPreExecute()
        //    {
        //        base.OnPreExecute();

        //        //dialog = new ProgressDialog(Application.Context);
        //        //dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
        //        //dialog.SetMessage("Loading Please wait...");
        //        //dialog.SetCanceledOnTouchOutside(false);
        //        //dialog.Show();


        //    }
        //    protected override void OnPostExecute(Java.Lang.Object result)
        //    {
        //        base.OnPostExecute(result);
        //        //   dialog.Hide();


        //    }







        //    }
    }
}


