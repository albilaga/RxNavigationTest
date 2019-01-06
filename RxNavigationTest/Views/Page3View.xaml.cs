using System.Reactive.Disposables;
using ReactiveUI;
using RxNavigationTest.ViewModels;

namespace RxNavigationTest.Views
{
    public partial class Page3View : BaseContentPage<Page3ViewModel>
    {
        public Page3View()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.BindCommand(this.ViewModel, vm => vm.GoBack, v => v.GoBackButton).DisposeWith(disposable);
            });
        }
    }
}
