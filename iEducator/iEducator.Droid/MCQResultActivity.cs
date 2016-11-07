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

namespace iEducator.Droid
{
    [Activity(Label = "ResultActivity",Theme ="@style/MyTheme")]
    public class MCQResultActivity : Activity
    {

        Button Ok;
        private static string rightans_intent;
        private static int result_intent;
        TextView anskey, result;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_result);
            // Create your application here




            anskey = FindViewById<TextView>(Resource.Id.textViewAnswer);

            result = FindViewById<TextView>(Resource.Id.textViewResult);

            Ok = FindViewById<Button>(Resource.Id.buttonOk);

            result_intent = Intent.GetIntExtra("check", 0);

            rightans_intent = Intent.GetStringExtra("answer");


            if (result_intent == 1)
            {
                result.Text = "Oops.... Your are wrong";

                anskey.Text = "Correct Answer =    " + rightans_intent;
            }
            else
            {
                result.Text = "weldone you are right";

                anskey.Text = "please press continue for next question";
            }






            Ok.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MCQ)));
            };


        }

        protected override void OnPause()
        {
            base.OnPause();
            Finish();
        }
        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            Toast.MakeText(this, "your answer has been submited can not go back press continue to proceed", ToastLength.Long).Show();

        }

    }
}