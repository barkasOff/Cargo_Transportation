using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Input;
using System.Diagnostics;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace Cargo_Transportation.Controls.Input
{
    /// <summary>
    /// Логика взаимодействия для PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControl, IChangePassword
    {
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

		public SecureString CurPass => CurrentPassword.SecurePassword;

		public SecureString NewPass => NewPassword.SecurePassword;

		public SecureString RepNewPass => ConfirmPassword.SecurePassword;

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

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }
    }
}
