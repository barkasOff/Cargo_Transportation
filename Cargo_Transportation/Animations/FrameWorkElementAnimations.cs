using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Cargo_Transportation.Animations
{
    public static class FrameWorkElementAnimations
    {
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddSlideFromLeft(seconds, element.ActualWidth);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, element.ActualWidth);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddSlideToRight(seconds, element.ActualWidth);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task FadeIn(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds);
            sb.Begin(element);
            if (seconds != 0)
                element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task FadeOut(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);
            sb.Begin(element);
            if (seconds != 0)
                element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
            element.Visibility = Visibility.Collapsed;
        }
    }
}
