using MvvmCross.Platform.IoC;
using Com.Gossip.Bollywood.Shared.ViewModels;

namespace Com.Gossip.Bollywood.Shared
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}