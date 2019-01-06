using System;
using ReactiveUI;
using RxNavigation;
using RxNavigationTest.ViewModels;
using RxNavigationTest.Views;
using Splat;
using Xamarin.Forms;

namespace RxNavigationTest
{
    public class AppBootstrapper
    {
        private readonly NavigationPage _navigationPage;


        public AppBootstrapper()
        {
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            Locator.CurrentMutable.Register(() => new Page1View(), typeof(IViewFor<Page1ViewModel>));
            Locator.CurrentMutable.Register(() => new Page2View(), typeof(IViewFor<Page2ViewModel>));
            Locator.CurrentMutable.Register(() => new Page3View(), typeof(IViewFor<Page3ViewModel>));


            IView mainView = new MainView(RxApp.TaskpoolScheduler, RxApp.MainThreadScheduler, ViewLocator.Current);
            _navigationPage = mainView as NavigationPage;
            IViewStackService viewStackService = new ViewStackService(mainView);
            Locator.CurrentMutable.RegisterConstant(viewStackService, typeof(IViewStackService));

            viewStackService
         .PushPage(new Page1ViewModel())
         //.PushPage(new HomeAfterLoginViewModel())
         .Subscribe();
        }

        public NavigationPage GetMainView()
        {
            return _navigationPage;
        }

    }
}
