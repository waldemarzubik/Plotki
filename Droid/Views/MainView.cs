using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Com.Gossip.Droid.Views
{
    [Activity]
    public class MainView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
