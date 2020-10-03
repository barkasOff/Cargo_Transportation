using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Cargo_Transportation.Controls.Input
{
    /// <summary>
    /// Логика взаимодействия для PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl),
                new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                Debugger.Break();
                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }
    }
}
