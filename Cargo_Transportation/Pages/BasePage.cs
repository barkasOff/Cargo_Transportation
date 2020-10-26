using Cargo_Transportation.Animations;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cargo_Transportation.Pages
{
    public class                BasePage : Page
    {
        private object          _viewModel;

        public PageAnimation    PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation    PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float            SlideSeconds { get; set; } = 0.8f;
        public bool             ShouldAnimateOut { get; set; }
        public object           ViewModelObject
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;
            Loaded += BasePage_Loaded;
        }

        private async void      BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }
        public async Task       AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
            }
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromRight;
        }
        public async Task       AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None)
                return;
            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;
            }
        }
    }
}
