using Com.Gossip.Shared.DataModels;
using Com.Gossip.Shared.Interfaces;
using Com.Gossip.Shared.Interfaces.Cache;
using Com.Gossip.Shared.Tmz;
using MvvmCross.Platform.IoC;
using Com.Gossip.Shared.ViewModels;
using MvvmCross.Platform;

namespace Com.Gossip.Shared
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<IHttpClientFactory, TmzHttpFactory>();
            Mvx.RegisterType<ICacheInfo, CacheInfo>();
            
            RegisterAppStart<MainViewModel>();
        }
    }
}