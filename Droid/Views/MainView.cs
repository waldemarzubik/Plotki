using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Com.Gossip.Droid.Views
{
    [Activity]
    public class MainView : ViewBase
    {
        private ActionBarDrawerToggle _drawerToggle;

        public DrawerLayout DrawerLayout
        {
            get { return FindViewById<DrawerLayout>(Resource.Id.drawer_layout); }
        }

        public MainView()
            : base(Resource.Layout.MainView, Resource.Id.toolbar)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (_drawerToggle == null)
            {
                _drawerToggle = new ActionBarDrawerToggle(this, DrawerLayout, FindViewById<Toolbar>(Resource.Id.toolbar), 0, 0);
                _drawerToggle.DrawerIndicatorEnabled = true;
            }

            DrawerLayout.SetDrawerListener(_drawerToggle);
            DrawerLayout.CloseDrawers();
            _drawerToggle.SyncState();
        }

        protected override void OnCreateToolbar()
        {
            base.OnCreateToolbar();

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }
    }
}