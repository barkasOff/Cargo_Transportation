using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ValueConverters;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Pages;

namespace Cargo_Transportation.Controls
{
    /// <summary>
    /// Логика взаимодействия для PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        public static DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost),
                new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));
        public static DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel),
                typeof(BaseViewModel), typeof(PageHost),
                new UIPropertyMetadata());

        public PageHost()
        {
            InitializeComponent();
        }

        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                page.ViewModelObject = currentPageViewModel;
                return value;
            }
            var oldPageContent = newPageFrame.Content;
            newPageFrame.Content = null;
            oldPageFrame.Content = oldPageContent;
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }
            newPageFrame.Content = new ApplicationValueConverter().Convert(currentPage, null, currentPageViewModel);
            return value;
        }
    }
}
