using System;
using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;
using RxNavigation;
using Splat;
using Xamarin.Forms;

namespace RxNavigationTest.ViewModels
{
    public class BaseViewModel : ReactiveObject, ISupportsActivation, IPageViewModel, IEnableLogger
    {
        public string UrlPathSegment
        {
            get;
            protected set;
        }

        //public IScreen HostScreen
        //{
        //    get;
        //    protected set;
        //}

        public readonly Interaction<Unit, Unit> LoadingDataStarted;
        public readonly Interaction<Unit, Unit> LoadingDataFinished;
        public readonly Interaction<Exception, Unit> LoadingDataFailed;

        public readonly ReactiveCommand<Unit, Unit> GoBack;
        public readonly ReactiveCommand<Unit, Unit> GoBackToRoot;
        public readonly ReactiveCommand<Unit, Unit> GoBackModal;

        public ViewModelActivator Activator => viewModelActivator;

        protected readonly ViewModelActivator viewModelActivator = new ViewModelActivator();

        protected readonly CompositeDisposable Disposable = new CompositeDisposable();
        protected IViewStackService ViewStackService { get; }
        protected readonly double FontSize;

        public string Title => "";

        protected BaseViewModel(IViewStackService viewStackService = null)
        {
            //HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
            this.ViewStackService = viewStackService ?? Locator.Current.GetService<IViewStackService>();
            this.LoadingDataStarted = new Interaction<Unit, Unit>();
            this.LoadingDataFinished = new Interaction<Unit, Unit>();
            this.LoadingDataFailed = new Interaction<Exception, Unit>();
            this.GoBack = ReactiveCommand.CreateFromObservable(() => this.ViewStackService.PopPages());
            this.GoBackModal = ReactiveCommand.CreateFromObservable(() => this.ViewStackService.PopModal());
            this.FontSize = Device.RuntimePlatform.Equals(Device.Android, StringComparison.Ordinal) ? 14d : 24d;
            this.GoBackToRoot = ReactiveCommand.CreateFromObservable(() => this.ViewStackService.PopToRoot());
            this.WhenActivated((CompositeDisposable disposable) =>
            {
                this.GoBack
                    .ThrownExceptions
                    .Subscribe(x =>
                    {
                        this.Log().DebugException(nameof(GoBack), x);
                    }).DisposeWith(disposable);
                this.GoBackModal
                  .ThrownExceptions
                  .Subscribe(x =>
                  {
                      this.Log().DebugException(nameof(GoBackModal), x);
                  }).DisposeWith(disposable);
                this.GoBackToRoot
                  .ThrownExceptions
                  .Subscribe(x =>
                  {
                      this.Log().DebugException(nameof(GoBackToRoot), x);
                  }).DisposeWith(disposable);
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Disposable.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
