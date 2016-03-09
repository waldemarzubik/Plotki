using System.Collections.Generic;
using Android.Content;
using Com.Gossip.Droid.Models;
using Com.Gossip.Shared;
using Com.Gossip.Shared.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

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

        protected override IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var toReturn = base.ViewNamespaceAbbreviations;
                toReturn["uicontrols"] = "Com.Gossip.Droid.Controls";
                return toReturn;
            }
        }
    }
}
