using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MvvmCross.iOS.Views;

namespace Com.Gossip.iOS
{
    [MvxFromStoryboard("Main")]
    partial class MainViewController : MvxViewController
    {
        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }
    }
}