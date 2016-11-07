using System;



using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Java.Util;
using Android.Views.Animations;
using Toolbar = Android.Support.V7.Widget.Toolbar;
namespace iEducator.Droid
{
	[Activity (Label = "iEducator",Theme = "@style/MyTheme.NoActionBar")]
	public class IEducatorHomePage : AppCompatActivity
	{
        //int count = 1;

        DrawerLayout drawerLayout;

        //special type of listview layout in navigationdrawer
       
       

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            /* code for dialog
            ProgressDialog dialog = new ProgressDialog(this); // this = YourActivity
            dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            dialog.SetMessage("Loading OTP . Please wait...");
            dialog.SetCanceledOnTouchOutside(false);
            dialog.Show();
            */

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
           
            SupportActionBar.Title = "i EDucator";

         //   SupportActionBar.SetDisplayHomeAsUpEnabled(true);


            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layouts);

            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);


            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);

            drawerLayout.AddDrawerListener(drawerToggle);

            drawerToggle.SyncState();

            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;



            var newFragment = new HomePageFragment();

            var trans = SupportFragmentManager.BeginTransaction();

            trans.SetCustomAnimations(Resource.Animation.bottomuptransition, Resource.Animation.slide_in, Resource.Animation.bottomuptransition, Resource.Animation.slide_in);

            trans.Replace(Resource.Id.fragment_container, newFragment).Commit();


        }




        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            e.MenuItem.SetChecked(true);
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.navigation_item_1):
                   
                    var currentFragment = SupportFragmentManager.FindFragmentById(Resource.Id.fragment_container);

                    //to check whether the current fragment is already present or not
                    if(currentFragment.GetType()==typeof(HomePageFragment))
                        {
                       // Toast.MakeText(this, "home fragment already present ", ToastLength.Long).Show();

                        drawerLayout.CloseDrawers();
                    }
                    else
                    {
                        var newFragment = new HomePageFragment();

                        var trans = SupportFragmentManager.BeginTransaction();

                       // trans.SetCustomAnimations()

                        trans.SetCustomAnimations(Resource.Animation.bottomuptransition,0,0,0);

                        trans.Replace(Resource.Id.fragment_container, newFragment).Commit();

                    }






                    break;
                case Resource.Id.navigation_item_2:

                    var newQandAFragment = new QandADiscussionFragment();

                    var transition = SupportFragmentManager.BeginTransaction();

                    transition.SetCustomAnimations(Resource.Animation.slide_in, 0, Resource.Animation.slide_in,0);

                    transition.Replace(Resource.Id.fragment_container, newQandAFragment).Commit();


                    break;
                case Resource.Id.navigation_item_3:
                    var newLeaderBoardFragment = new LeaderBoardFragment();
                    //  FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, newLeaderBoardFragment).Commit();
                   var transition2 = SupportFragmentManager.BeginTransaction();

                    transition2.SetCustomAnimations(Resource.Animation.slide_in,0, Resource.Animation.slide_in, 0);

                    transition2.Replace(Resource.Id.fragment_container, newLeaderBoardFragment).Commit();

                    break;
                case Resource.Id.navigation_item_4:
                
                    var newInviteFriendsFragment = new InviteFriendsFragment();
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, newInviteFriendsFragment).Commit();

                    break;

                case Resource.Id.navigation_subItem_1:




                    break;

                case Resource.Id.navigation_subItem_2:



                    break;



            }

            // Close drawer
            drawerLayout.CloseDrawers();
        }
    }
}


