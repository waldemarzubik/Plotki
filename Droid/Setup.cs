using Android.Content;
using Com.Gossip.Droid.Models;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Com.Gossip.Shared;
using Com.Gossip.Shared.Interfaces;
using MvvmCross.Platform;

namespace Com.Gossip.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.LazyConstructAndRegisterSingleton<IStorage, StorageService>();
        }
    }
}
