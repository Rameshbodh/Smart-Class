using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using UIKit;
using System.IO;
using Android.Content.Res;
using System.Xml.Linq;
using System.Linq;
using Android.Graphics;
using System.Collections.Generic;
using Android.Util;

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


       

          //  List<string> subjactName=
       // int[] subjactImage = { Resource.Drawable.english, Resource.Drawable.Maths1, Resource.Drawable.Hindi, Resource.Drawable.science, Resource.Drawable.sst };
       public List<Bitmap> subjactImage = new List<Bitmap>();
        public List<string> subjactName = new List<string>();
        public List<string> subjactId = new List<string>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
           


            mLayoutManager = new GridLayoutManager(Application.Context, 2, GridLayoutManager.Vertical, false);


            //to read the text from xml file
            //AssetsManager for getting the xml file from assets folder
                AssetManager assets = Application.Context.Assets;
            // to read the content from xml file as string

            StreamReader sr = new StreamReader(assets.Open("iedu_access.xml"));

            //to convert the string in xml document

            XDocument doc = XDocument.Load(sr);


            var subjacts = (from x in doc.Descendants("Subject").Descendants("Table")

                            select new

                            {

                                id = Convert.ToString(x.Element("SubjectId").Value),

                                name = Convert.ToString(x.Element("SubjectName").Value),

                                image = Convert.ToString(x.Element("SubjectImage").Value)

                            }).ToList();


            Bitmap encodedImage = null; ;

            foreach (var sub in subjacts)

            {
                //decode the base64 string
                    encodedImage = DecodeImage(sub.image);


                    subjactId.Add(""+sub.id);

                    subjactName.Add("" + sub.name);

                    subjactImage.Add(encodedImage);


            }
            
            //_imageview.SetImageBitmap(encodedImage);


            //inflating the xml layout

            View view = inflater.Inflate(Resource.Layout.activity_home, container, false);
           

            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);


            mRecyclerView.SetLayoutManager(mLayoutManager);





            PhotoAlbumAdapter adapter = new PhotoAlbumAdapter(Application.Context,subjactName,subjactImage);

            mRecyclerView.SetAdapter(adapter);

            adapter.ItemClick += OnItemClick;
          

       



            return view;

         
        }
        
        // method for converting base64 string to Bitmap Image
        public Bitmap DecodeImage(string image)
        {
            byte[] imageBytes = Base64.Decode(image, Base64Flags.Default);

            return BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

        }



        void OnItemClick(object sender, int position)
        {
            // Display a toast that briefly shows the enumeration of the selected photo:
            int photoNum = position + 1;
//            Toast.MakeText(Application.Context, "This is photo number " + photoNum, ToastLength.Short).Show();

            Bundle b = new Bundle();
            int subId = Convert.ToInt32(subjactId[position]);
            string topicName = subjactName[position];
            Bitmap imageID = subjactImage[position];

            Toast.MakeText(Application.Context, "This is subjact id " + subId, ToastLength.Long).Show();



            b.PutString("topic", topicName);
            b.PutParcelable("image", imageID);
            b.PutInt("subjactId", subId);
            //b.PutInt("image", 0);



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

            List<string> subjactname;
            List<Bitmap> subjact;
            //public PhotoAlbum mPhotoAlbum;
            Context context;
            public PhotoAlbumAdapter(Context context,List<string> subjactname, List<Bitmap> subjact)
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
                vh.Image.SetImageBitmap(subjact[position]);
                vh.Caption.Text = subjactname[position];

            }

            public override int ItemCount
            {
                get { return subjactname.Count; }
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
