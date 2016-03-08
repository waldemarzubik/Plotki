using MvvmCross.Core.ViewModels;

namespace Com.Gossip.Bollywood.Shared.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";

        public string Hello
        { 
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
    }
}