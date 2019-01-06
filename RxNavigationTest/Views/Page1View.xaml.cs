using System.Reactive.Disposables;
using ReactiveUI;
using RxNavigationTest.ViewModels;

namespace RxNavigationTest.Views
{
    public partial class Page1View : BaseContentPage<Page1ViewModel>
    {
        public Page1View()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.BindCommand(this.ViewModel, vm => vm.GoToPage2, v => v.GoToPage2Button).DisposeWith(disposable);
            });
        }
    }
}
