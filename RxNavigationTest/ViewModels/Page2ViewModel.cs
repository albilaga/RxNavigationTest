using System;
using System.Reactive;
using ReactiveUI;

namespace RxNavigationTest.ViewModels
{
    public class Page2ViewModel : BaseViewModel
    {
        public Page2ViewModel()
        {
            this.GoToPage3 = ReactiveCommand.CreateFromObservable<Unit, Unit>((arg) => this.ViewStackService.PushPage(new Page3ViewModel()));
        }

        public readonly ReactiveCommand<Unit, Unit> GoToPage3;
    }
}
