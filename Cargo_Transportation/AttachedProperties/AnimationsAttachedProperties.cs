using Cargo_Transportation.Animations;
using System.Windows;

namespace Cargo_Transportation.AttachedProperties
{
    public abstract class               AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
           where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        public bool                     FirstLoad { get; set; } = true;

        public override void            OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;
            if (FirstLoad)
            {
                void onLoaded(object ss, RoutedEventArgs ee)
                {
                    element.Loaded -= onLoaded;
                    DoAnimation(element, (bool)value);
                    FirstLoad = false;
                }

                element.Loaded += onLoaded;
            }
            else
                DoAnimation(element, (bool)value);
        }

        protected virtual void          DoAnimation(FrameworkElement element, bool value) { }
    }

    public class                        AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void   DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.7f);
            else
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.7f);
        }
    }
    public class                        AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void   DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideAndFadeInFromRight(FirstLoad ? 0 : 0.7f);
            else
                await element.SlideAndFadeOutToRight(FirstLoad ? 0 : 0.7f);
        }
    }
    public class                        AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void   DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.FadeIn(FirstLoad ? 0 : 0.3f);
            else
                await element.FadeOut(FirstLoad ? 0 : 0.3f);
        }
    }
}
