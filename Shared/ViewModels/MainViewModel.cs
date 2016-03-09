using System.Collections.Generic;
using Com.Gossip.Shared.DataModels;
using Com.Gossip.Shared.Interfaces;
using Com.Gossip.Shared.Tmz;
using MvvmCross.Core.ViewModels;

namespace Com.Gossip.Shared.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;

        private string _hello = "Hello MvvmCross";

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.ExecuteOperation<ArticlesRequest, List<Article>>();
        }

        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
    }
}