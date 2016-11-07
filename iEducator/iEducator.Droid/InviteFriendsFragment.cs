using System;
using System.Collections.Generic;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using System.IO;
using Android.Content.Res;

using System.Xml.Linq;
using System.Linq;
using Android.Media;
using Android.Graphics;

namespace iEducator.Droid
{
    public class InviteFriendsFragment : Fragment
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
            View view = inflater.Inflate(Resource.Layout.fragment_InviteFriend, container, false);
            var textFragment = view.FindViewById<TextView>(Resource.Id.textViewReportfragment);
            var _listV = view.FindViewById<ListView>(Resource.Id.listView);
            var _imageview = view.FindViewById<ImageView>(Resource.Id.imageView);
            List<string> list = new List<string>();
            //   string content;

            //reading the content from xml file



            //xmlstring = sr.ReadToEnd();

            //XmlDocument doc = new XmlDocument();

            //doc.Load(sr);


           
            //var nodes = doc.SelectNodes("/subjacts/subjact");

            //if (nodes.Count > 0) {
            //    for (int i =0;i< nodes.Count;i++)
            //    {
            //        list.Add(""+ nodes[i].InnerXml);
            //    }
            //    textFragment.Text = "hello" + subjact;

            //    _listV.Adapter = new ArrayAdapter<string>(Application.Context, Android.Resource.Layout.SimpleListItem1, list);

            //     }
            //reading the content from xml file in assets folder
            AssetManager assets = Application.Context.Assets;
            //  StreamReader sr = new StreamReader(assets.Open("subjact_info.xml"));
            StreamReader sr = new StreamReader(assets.Open("iedu_access.xml"));
            XDocument doc = XDocument.Load(sr);

            //  IEnumerable<SubjactInfo> subjact = (from x in doc.Descendants("Subject")
            var subjact = (from x in doc.Descendants("Subject").Descendants("Table")
                                                    //table = x.descendants("table").elements("subjectname"),
                                                    //id = x.descendants("table").elements("subjectid"),
                                                select new
                                                {
                                                    
                                                    Id = Convert.ToString(x.Element("SubjectId").Value),
                                                    Name = Convert.ToString(x.Element("SubjectName").Value)
                                                    //image=Convert.ToString(x.Element("image").Value)
                                                }).ToList();
            //Bitmap encodedImage = null; ;
            foreach(var sub in subjact)
            {
                string s = Convert.ToString(sub.Name);
                string b = Convert.ToString(sub.Id);
                //encodedImage = DecodeImage(sub.image);
                    list.Add("" + s);
                


            }
           // _imageview.SetImageBitmap(encodedImage);
      



            _listV.Adapter = new ArrayAdapter<string>(Application.Context, Android.Resource.Layout.SimpleListItem1, list);
            
            
            return view;


        }
        public Bitmap DecodeImage(string image)
        {
            byte[] imageBytes = Base64.Decode(image,Base64Flags.Default);

                return BitmapFactory.DecodeByteArray(imageBytes,0,imageBytes.Length);
            
        }
    }
}