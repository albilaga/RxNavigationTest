using System;
using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RxNavigationTest.ViewModels;
using Xamarin.Forms;

namespace RxNavigationTest.Views
{
    public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : BaseViewModel
    {
        public BaseContentPage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            this.WhenActivated(disposable =>
            {
                this.ViewModel
                    .LoadingDataStarted
                    .RegisterHandler((arg) =>
                    {
                        arg.SetOutput(Unit.Default);
                    }).DisposeWith(disposable);
                this.ViewModel
                    .LoadingDataFinished
                   .RegisterHandler((arg) =>
                   {
                       arg.SetOutput(Unit.Default);
                   }).DisposeWith(disposable);
                this.ViewModel
                    .LoadingDataFailed
                   .RegisterHandler((arg) =>
                   {
                       arg.SetOutput(Unit.Default);
                   }).DisposeWith(disposable);
            });
        }
    }
}
