using System;
using MvvmCross.iOS.Views;

namespace Com.Gossip.iOS
{
    public class ViewControllerBase : MvxViewController
    {
        protected ViewControllerBase(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            OnCreateBindings();
        }

        protected virtual void OnCreateBindings()
        {
        }
    }
}