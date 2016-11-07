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
using Android.Support.V4.View;
using Android.Support.V4.App;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Android.Views.Animations;

namespace iEducator.Droid
{
    [Activity(Label = "MCQ",Theme ="@style/MyTheme.NoActionBar")]
    public class MCQ : AppCompatActivity,View.IOnClickListener
    {
        //mcq options
        Button opt1, opt2, opt3, opt4;

        //submit answer button
        private static Button submit;

        //variable for reading the data from shared prefrences

        private static int RIGHT_ANSWER_COUNT = 0;

        private static int GET_PREF_RIGHT_COUNT = 0;

    //    private static int WRONG_COUNT = 0;



        //question display
        TextView question,correct;

    
        //counter for increamenting the question number sequence
        private static int counter = 0;

  

        //counter for checking  whether the option buttons is clicked or selected or not 
        private static int count = 0;


        //for storing the value of right answer when option is selected
        private static string ans = null;

        //for passing the values to next activity screen
        private static Bundle bundle_save_states = new Bundle();

        private static ISharedPreferences prefs = Application.Context.GetSharedPreferences("PREF_NAME", FileCreationMode.Private);
       private static ISharedPreferencesEditor editor = prefs.Edit();

        private static string[] ques = new string[] { "Q1. In addition and subtraction of two integers , sign of the answer depends upon ?",
            "Q2. Sum of two negative number is always ",
            "Q3. Sum of two Positive number is always ",
            "Q4. Sum of – 36 and 29 is ",
            "Q5. Sum of   ̶ 19 and  ̶  21 is ",
            "Q6. Which of the following statement is false",
            "Q7. The pair of integers whose sum is  ̶  5 ",
            "Q8. What integers or number should be added to  ̶  5 to get 4",
            "Q9 .  What will be the additive inverse of  ̶  5 ",
            "Q10. What will be the additive inverse of  7",
              };
        private static string[] opta = new string[] {
            "Smaller number",
            "positive",
            "negative",
            "-65",
            "-40",
            "- 7 + (̶  6 ) = ̶  13 ",
            "1,-4",
            "1",
            "-6",
            "-7"
              };
        private static string[] optb = new string[] {
            "Their difference",
            "Negative",
            "Positive",
            "65",
            "40",
            "  ̶  5  + 1 = 4",
            " -1 , 6",
            "-1",
            "-4",
            "-6"
              };
        private static string[] optc = new string[] {
            " Their sum",
            "0",
            "1",
            "-7",
            "2",
            "2  +  (̶ 1 ) = 1",
            "-3,-2",
            "-9",
            "3",
            "-5"
        };
        private static string[] optd = new string[] {
            " Greater numerical value",
            "1",
            "0",
            "7",
            "-2",
            "8  + (̶  9 ) =  ̶  1",
            "5,0",
            "9",
            "5",
            "-4"
        };
        private static string[] answerKey = new string[]
        {
            " Greater numerical value","Negative","Positive","-7","-40","  ̶  5  + 1 = 4","-3,-2","9","5","-7"
        };
        

    

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_mcq);

            question = FindViewById<TextView>(Resource.Id.textView1);

            opt1 = FindViewById<Button>(Resource.Id.button1);

            opt2 = FindViewById<Button>(Resource.Id.button2);

            opt3 = FindViewById<Button>(Resource.Id.button3);

            opt4 = FindViewById<Button>(Resource.Id.button4);

            submit = FindViewById<Button>(Resource.Id.button5);


            correct = FindViewById<TextView>(Resource.Id.textViewNumber);
           



            //shared preferences code of saving data and reading data
           

            // var value2 = prefs.GetString ("your_key2", null);
           


           
            
            
            opt1.SetOnClickListener(this);
            opt2.SetOnClickListener(this);
            opt3.SetOnClickListener(this);
            opt4.SetOnClickListener(this);
            submit.SetOnClickListener(this);

           

            //submit.Click += delegate
            //{
            //    Toast.MakeText(this, "select the option first", ToastLength.Long).Show();
            //};

        }
        //use View.IOnClickListener
        // to handle the multiple button click event
        //using v.id in switch case
        public void OnClick(View v)
        {
            Animation fadeIn_animation = AnimationUtils.LoadAnimation(Application.Context, Resource.Animation.abc_fade_in);
            switch (v.Id)
            {
                case Resource.Id.button1:

                    ans = opt1.Text;

                    count++;
                   
                    opt1.SetBackgroundResource(Resource.Drawable.rounded_corner);

                    opt1.StartAnimation(fadeIn_animation);

           
                    

                    opt2.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt3.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt4.SetBackgroundResource(Resource.Drawable.circular_border);

                    break;

                case Resource.Id.button2:
                  
                    ans = opt2.Text;

                    count++;

                    opt2.SetBackgroundResource(Resource.Drawable.rounded_corner);

                    opt2.StartAnimation(fadeIn_animation);

                    opt1.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt4.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt3.SetBackgroundResource(Resource.Drawable.circular_border);
                




                    break;
                case Resource.Id.button3:
                    
                    ans = opt3.Text;

                    count++;

                   

                    opt3.SetBackgroundResource(Resource.Drawable.rounded_corner);

                    opt3.StartAnimation(fadeIn_animation);

                    opt1.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt2.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt4.SetBackgroundResource(Resource.Drawable.circular_border);

                   
                    break;
                case Resource.Id.button4:


                    ans = opt4.Text;

                    count++;

                    opt4.StartAnimation(fadeIn_animation);

                    opt4.SetBackgroundResource(Resource.Drawable.rounded_corner);

                    opt1.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt2.SetBackgroundResource(Resource.Drawable.circular_border);
                    opt3.SetBackgroundResource(Resource.Drawable.circular_border);

                    break;

                case Resource.Id.button5:


                    submit.Focusable = true;
                    submit.FocusableInTouchMode = true;
                    submit.RequestFocusFromTouch();
                    
                    //check to display right or wrong anser in textview in next activity 
                    int check = 0;

                    if (count!=0)
                    {
                        
                        check = 2;
                        if(ans==answerKey[counter] && ans!=null)
                        {
                            

                            Toast.MakeText(this, "you are right", ToastLength.Long).Show();


                            bundle_save_states.PutInt("check", check);

                            RIGHT_ANSWER_COUNT++;

                            //next activity
                            Intent main = new Intent(this, typeof(MCQResultActivity));

                            main.PutExtras(bundle_save_states).ToString();

                            StartActivity(main);

                            counter++;

                            saveToPrefrence(counter);
                        }
                        else
                        {

                            check = 1;

                          

                            Toast.MakeText(this, "wrong", ToastLength.Long).Show();

                          //  WRONG_COUNT++;


                            
                            bundle_save_states.PutInt("check", check);

                            bundle_save_states.PutString("answer", answerKey[counter]);

                            //bundle_save_states.PutString("answerKey", "" + answerKey[rightAnswerCounter--]);
                           
                          
                             //next activity 
                            Intent main = new Intent(this, typeof(MCQResultActivity));

                            main.PutExtras(bundle_save_states).ToString();

                            StartActivity(main);

                            counter++;

                            

                            //method call for saving the data
                            saveToPrefrence(counter);
                        }
                        //increamenting value so that no event will accur(onclick->submit button) without selecting the answers
                        count = 0;
                    }
                    else
                    {
                        Toast.MakeText(this, "please select your answer before submitting", ToastLength.Long).Show();
                    }
                    break;


            }


            //   throw new NotImplementedException();
        }
        //saving all the data
        private void saveToPrefrence(int rightCount )
        {


            editor.PutInt("Counter", rightCount);


            editor.Apply();

          //  readFromPrefrence();

           

            //   throw new NotImplementedException();
        }

     

        private void readFromPrefrence()
        {
         //   GET_PREF_RIGHT_ANSWER_COUNT = prefs.GetInt("RightAnswer", 0);

            GET_PREF_RIGHT_COUNT = prefs.GetInt("Counter", 0);

            if (GET_PREF_RIGHT_COUNT == 0)
            {
                correct.Text = "Result = "+ RIGHT_ANSWER_COUNT +"/"+ques.Length;


                question.Text = "" + ques[0];

                opt1.Text = "" + opta[0];

                opt2.Text = "" + optb[0];

                opt3.Text = "" + optc[0];

                opt4.Text = "" + optd[0];
            }
            else if(GET_PREF_RIGHT_COUNT<=9)
            {
                correct.Text = "Result = " + RIGHT_ANSWER_COUNT + "/" + ques.Length;
               

                question.Text = "" + ques[GET_PREF_RIGHT_COUNT];

                opt1.Text = "" + opta[GET_PREF_RIGHT_COUNT];


                opt2.Text = "" + optb[GET_PREF_RIGHT_COUNT];

                opt3.Text = "" + optc[GET_PREF_RIGHT_COUNT];

                opt4.Text = "" + optd[GET_PREF_RIGHT_COUNT];
            }
            else
            {
                question.Text = "Weldone you have completed the course";
                question.Gravity = GravityFlags.CenterHorizontal;
               
               // question.SetGravity(GravityFlags.Center);
                correct.Text = "Total Correct Answer = " + RIGHT_ANSWER_COUNT +"  Out of = "+ques.Length;
                opt1.Visibility = ViewStates.Gone;
                opt2.Visibility = ViewStates.Gone;
                opt3.Visibility = ViewStates.Gone;
                opt4.Visibility = ViewStates.Gone;

                submit.Text = "OK";

                //when all the answer has been compleated
                submit.Click += delegate
                {

                    counter = 0;

                    saveToPrefrence(counter);
                 
                    Intent main = new Intent(this,typeof(TopicsActivity));
                    StartActivity(main);

                };



                SavedMCQResultDataPreferences saveValue = new SavedMCQResultDataPreferences();

                saveValue.SaveMCQResult(optb.Length, RIGHT_ANSWER_COUNT);


            }

        }

        protected override void OnPause()
        {
            base.OnPause();
            

        }

        protected override void OnResume()
        {
            base.OnResume();


        }
        protected override void OnDestroy()
        {
           base.OnDestroy();
            counter = 0;
            saveToPrefrence(counter);

            Finish();

         

        }
        protected override void OnStop()
        {
           base.OnStop();
           
        }
        protected override void OnStart()
        {
         base.OnStart();
            readFromPrefrence();
        }
        public override void OnBackPressed()
        {
         //   base.OnBackPressed();
            var back = 1;
            if (back > 0) { 
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Really Exit ?");
            alert.SetMessage("Are you sure you want to exit ?");
               
            alert.SetPositiveButton("OK", (senderAlert, args) => {
                // write your own set of instructions
                Finish();
                counter = 0;
                saveToPrefrence(counter);
               
                Intent main = new Intent(this, typeof(TopicsActivity));
                //clear all the stack activities
                main.SetFlags(ActivityFlags.ClearTop);

               
                StartActivity(main);





            });
            alert.Create();
            alert.Show();
            }
        }

    }
}
