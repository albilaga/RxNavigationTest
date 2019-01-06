using System.Reactive.Disposables;
using ReactiveUI;
using RxNavigationTest.ViewModels;

namespace RxNavigationTest.Views
{
    public partial class Page2View : BaseContentPage<Page2ViewModel>
    {
        public Page2View()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.BindCommand(this.ViewModel, vm => vm.GoToPage3, v => v.GoToPage3Button).DisposeWith(disposable);
            });
        }
    }
}
