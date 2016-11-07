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
using Android.Support.V7.Widget;
using Java.Lang;
using Android.Support.Design.Widget;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace iEducator.Droid
{
    [Activity(Label = "TopicsActivity", Theme = "@style/MyTheme.NoActionBar")]
    public class TopicsActivity : AppCompatActivity
    {
        //instance of recyclerview
        RecyclerView mRecyclerView;

        CollapsingToolbarLayout collapsingToolBar;

        CoordinatorLayout coordinatorLayout;

        Toolbar toolbar;
        //instance for setting up the layoutManager for recycler view 
        RecyclerView.LayoutManager mLayoutManager;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_topics);

            coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.coordinatorLayout);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            ImageView imageView = FindViewById<ImageView>(Resource.Id.subjact_image);

            //getting the value from intent HomeFragment

            string topicName = Intent.GetStringExtra("topic");

            int image = Intent.GetIntExtra("image",0);

            imageView.SetImageResource(image);



            mLayoutManager = new LinearLayoutManager(this);


            SetSupportActionBar(toolbar);


            collapsingToolBar.Title = ""+topicName;

                
            mRecyclerView.SetLayoutManager(mLayoutManager);

           

            string[] list = new string[] { "Negative numbers: addition and subtraction",
            "Negative numbers: multiplication and division",
            "Fractions, decimals, & percentages",
            "Rates & proportional relationships.Expressions",
            "Equations",
            "inequalities",
            "Geometry",
            "Statistics and probability"};

            TopicsAdapter adapter = new TopicsAdapter(list);

            mRecyclerView.SetAdapter(adapter);


            adapter.ItemClick += OnItemClick;

            //  .Click +=de

            


        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            

            base.OnSaveInstanceState(outState);
        }





        public override void OnBackPressed()
        {
            //base.OnBackPressed();

            Intent main = new Intent(this, typeof(IEducatorHomePage));
            main.SetFlags(ActivityFlags.ClearTop);
            StartActivity(main);



        }
        void OnItemClick(object sender, int position)
        {
            // Display a toast that briefly shows the enumeration of the selected photo:
            int photoNum = position + 1;

            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
            //StartActivity(new Intent(this, typeof(TopicsVideoActivity)));


            //to show the custom snackbar for displaying multiple options like study material , video ,MCQ after onclick video topics 
            Snackbar snackBar = Snackbar.Make(coordinatorLayout, "", Snackbar.LengthLong);



            Snackbar.SnackbarLayout layout = (Snackbar.SnackbarLayout)snackBar.View;

            TextView text = layout.FindViewById<TextView>(Resource.Id.snackbar_text);

            text.Visibility = ViewStates.Invisible;

            View snackBarView = LayoutInflater.From(this).Inflate(Resource.Layout.custom_snackbar_topic_activity, null);

            Button textViewVideo = snackBarView.FindViewById<Button>(Resource.Id.textViewVideo);

            Button textViewStudy = snackBarView.FindViewById<Button>(Resource.Id.textViewStudy);

            Button textViewMCQ = snackBarView.FindViewById<Button>(Resource.Id.textViewMCQ);


            textViewVideo.Click += delegate
            {
                StartActivity(new Intent(this, typeof(TopicsVideoActivity)));
            };
            textViewStudy.Click += delegate
            {
                StartActivity(new Intent(this, typeof(StudyMaterialWebView)));
            };
            textViewMCQ.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MCQ)));
            };


            //List<string> list = new List<string>();

            //list.Add("Video");
            //list.Add("Study Material");
            //list.Add("Multiple Choice Question");

            //ListView listView = snackBarView.FindViewById<ListView>(Resource.Id.ListView);

            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SelectDialogSingleChoice, list);

            //listView.Adapter = adapter;



            layout.AddView(snackBarView, 0);




            snackBar.Show();

            //    TextView textView = FindViewById<TextView>(Resource.Id.snackbar_text);



        }



    }

    //adapter for list of topics

    public class TopicsAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        string[] list;


        public TopicsAdapter(string [] list)
        {
            this.list = list;
        }


        public override int ItemCount
        {
            get
            {
                return  list.Length;
            }
        }
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TopicViewHolder vh = holder as TopicViewHolder;
            vh.caption.Text = list[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.single_item_topic_view, parent, false);
            TopicViewHolder vh = new TopicViewHolder(itemView,OnClick);
            return vh;
        }




       
    }



    public class TopicViewHolder : RecyclerView.ViewHolder
    {
        public TextView caption { get; private set; }

        public TopicViewHolder(View itemView, Action<int> listener) :base(itemView)
        {
            caption = itemView.FindViewById<TextView>(Resource.Id.textViewTopic);


            itemView.Click += (sender, e) => listener(AdapterPosition);
        }
    }
    
}