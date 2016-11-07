using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using UIKit;

namespace iEducator.Droid
{
    public class HomePageFragment : Fragment
    {
        //instance of recyclerview
        RecyclerView mRecyclerView;

        //instance for setting up the layoutManager for recycler view 
        RecyclerView.LayoutManager mLayoutManager;

        //PhotoAlbum mPhotoAlbum;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your fragment here
        }
        string[] subjactName = { "english", "Maths", "hindi", "punjabi", "science", "Social studies" };
        int[] subjact = { Resource.Drawable.english, Resource.Drawable.Maths1, Resource.Drawable.Hindi, Resource.Drawable.punjabi, Resource.Drawable.science, Resource.Drawable.sst };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            mLayoutManager = new GridLayoutManager(Application.Context, 2, GridLayoutManager.Vertical, false);

           
            


               View view = inflater.Inflate(Resource.Layout.activity_home, container, false);
           

            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);


            mRecyclerView.SetLayoutManager(mLayoutManager);

            PhotoAlbumAdapter adapter = new PhotoAlbumAdapter(Application.Context,subjactName,subjact);
            mRecyclerView.SetAdapter(adapter);

            adapter.ItemClick += OnItemClick;
            //animating grid view 
            //please set the android:animateLayoutChanges="true" in layout before implementing the animation
            //extra xml file in anim folder where we have all the animation xml file than use it using Resource.Animation.grid_item_anim
           // Animation animation = AnimationUtils.LoadAnimation(Application.Context, Resource.Animation.fade_in);

            //for gridview to show animation
           // GridLayoutAnimationController controller = new GridLayoutAnimationController(animation, .2f, .2f);

            //final step
            //for setting the layout animation for gridview

  //          mRecyclerView.LayoutAnimation = controller;

       



            return view;

          //  return base.OnCreateView(inflater, container, savedInstanceState);
        }
        void OnItemClick(object sender, int position)
        {
            // Display a toast that briefly shows the enumeration of the selected photo:
            int photoNum = position + 1;
            Toast.MakeText(Application.Context, "This is photo number " + photoNum, ToastLength.Short).Show();

            Bundle b = new Bundle();

            string topicName = subjactName[position];
            int imageID = subjact[position];

            b.PutString("topic", topicName);
            b.PutInt("image", imageID);


            Intent m = new Intent(Application.Context, typeof(TopicsActivity));

            m.PutExtras(b).ToString();

            StartActivity(m);
        }

        //public void OnClick(View v)
        //{
        //    //  throw new NotImplementedException();
        //    Intent m = new Intent(Application.Context, typeof(TopicsActivity));
        //    ImageView view = v.FindViewById<ImageView>(Resource.Id.my_image_view);

        //    //Application.Context.Resources.GetString(Resource.String.transition_subjact_name)
        //    string transitionName = "shared element";
        //    ActivityOptions transition = ActivityOptions.MakeSceneTransitionAnimation(Application.Context, view, transitionName);
        //    StartActivity(m, transition.ToBundle());
        //}



    }

        public class PhotoAlbumAdapter : RecyclerView.Adapter
        {


            public event EventHandler<int> ItemClick;

            string[] subjactname;
            int[] subjact;
            //public PhotoAlbum mPhotoAlbum;
            Context context;
            public PhotoAlbumAdapter(Context context,string[] subjactname, int[] subjact)
            {
                this.subjact = subjact;
                this.subjactname = subjactname;
                this.context = context;
              //  mPhotoAlbum = photoAlbum;
            }

            void OnClick(int position)
            {
                if (ItemClick != null)
                    ItemClick(this, position);
                
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                PhotoViewHolder vh = holder as PhotoViewHolder;
                vh.Image.SetImageResource(subjact[position]);
                vh.Caption.Text = subjactname[position];

            }

            public override int ItemCount
            {
                get { return subjactname.Length; }
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.single_grid_custom_subjact, parent, false);
                PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
                return vh;
            }

        }



        public class PhotoViewHolder : RecyclerView.ViewHolder
        {
            public ImageView Image { get; private set; }
            public TextView Caption { get; private set; }

            public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView)
            {
                // Locate and cache view references:
                Image = itemView.FindViewById<ImageView>(Resource.Id.my_image_view);
                Caption = itemView.FindViewById<TextView>(Resource.Id.my_text_view);

                itemView.Click += (sender, e) => listener(AdapterPosition);

              
            }


        }

}
