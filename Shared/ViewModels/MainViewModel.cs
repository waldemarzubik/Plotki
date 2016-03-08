using MvvmCross.Core.ViewModels;

namespace Com.Gossip.Shared.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";

        public MainViewModel()
        {
        }

        public string Hello
        { 
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
    }
}