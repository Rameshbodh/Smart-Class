using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;



namespace iEducator.Droid
{
    public class LeaderBoardFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_LeaderBoard, container, false);

            var topicName = view.FindViewById<TextView>(Resource.Id.textViewtopic);

            SavedMCQResultDataPreferences read = new SavedMCQResultDataPreferences();

            int[] readArray = read.ReadMCQResult();

            topicName.Text = "Math";

            var totalAttempt = view.FindViewById<TextView>(Resource.Id.textViewAttempt);

           


            var totalCorrect = view.FindViewById<TextView>(Resource.Id.textViewCorrect);

           

            var percentage = view.FindViewById<TextView>(Resource.Id.textViewPercentage);


            float per;
           
          //  Toast.MakeText(Application.Context, "value to be noted  " + per, ToastLength.Long).Show();

            if (readArray[0] != 0)
            {

                per = (((float)readArray[1] / readArray[0]) * 100);

                totalAttempt.Text = "Total Attempt =           " + readArray[0];

                totalCorrect.Text = "Right Answer =             " + readArray[1];

                percentage.Text = "Total Percentage =           " + per + "    %";
            }
            else
            {
                //we have to use Activity to use alertbox in fragment
                AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
                alert.SetTitle("Sorry you can not view your score");
                alert.SetMessage("You have to compleat the test to see your score ...!");

                alert.SetPositiveButton("OK", (senderAlert, args) =>
                {
                    // write your own set of instructions


                    Intent main = new Intent(Application.Context, typeof(IEducatorHomePage));
                    //clear all the stack activities
                    // main.SetFlags(ActivityFlags.ClearTop);


                    StartActivity(main);





                });
                alert.Create();
                alert.Show();


            }









            // Toast.MakeText(Application.Context, "Value  " + s, ToastLength.Long).Show();


            return view;


        }
    }
}