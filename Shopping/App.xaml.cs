using Prism.Ioc;
using Shopping.ViewModels;
using Shopping.Views;
using Shopping.Views.Pages;
using System.Windows;

namespace Shopping
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<StepView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Page1View, Page1ViewModel>();
            containerRegistry.RegisterForNavigation<Page2View, Page2ViewModel>();
            containerRegistry.RegisterForNavigation<Page3View, Page3ViewModel>();
            containerRegistry.RegisterForNavigation< UserControl1>();
        }
    }
}
