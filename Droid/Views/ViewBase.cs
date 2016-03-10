using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Com.Gossip.Droid.Views
{
    public class ViewBase : MvxAppCompatActivity
    {
        private readonly int _layoutResId;
        private readonly int _toolbarResId;

        protected ViewBase(int layoutResId, int toolbarResId = 0)
        {
            _layoutResId = layoutResId;
            _toolbarResId = toolbarResId;
        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(_layoutResId);
        }

        public override void SetContentView(View view)
        {
            base.SetContentView(view);
            OnCreateToolbar();
            OnCreateBindings();
        }

        protected virtual void OnCreateToolbar()
        {            
            using (var toolbar = FindViewById<Toolbar>(_toolbarResId))
            {
                if (toolbar != null)
                {
                    SetSupportActionBar(toolbar);
                    SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                    SupportActionBar.SetHomeButtonEnabled(true);
                }
            }
        }

        protected virtual void OnCreateBindings()
        {            
        }
    }
}