using System;
using System.Reactive;
using ReactiveUI;

namespace RxNavigationTest.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        public Page1ViewModel()
        {
            this.GoToPage2 = ReactiveCommand.CreateFromObservable<Unit, Unit>((arg) => this.ViewStackService.PushPage(new Page2ViewModel()));
        }

        public readonly ReactiveCommand<Unit, Unit> GoToPage2;
    }
}
