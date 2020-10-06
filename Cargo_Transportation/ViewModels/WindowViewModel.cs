using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels
{
    public enum WindowDockPosition
    {
        Undocked = 0,
        Left = 1,
        Right = 2
    }

    public class WindowViewModel : BaseViewModel
    {
        private readonly Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadious = 0;
        private WindowDockPosition _windowDockPosition = WindowDockPosition.Undocked;

        public double MinWidth { get; set; } = 800;
        public double MinHeight { get; set; } = 600;
        public double Height { get; set; }
        public bool Borderless => (_window.WindowState == WindowState.Maximized || _windowDockPosition != WindowDockPosition.Undocked);
        public int ResizeBorder => Borderless ? 0 : 3;
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => OuterMarginSize = value;
        }
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);
        public int WindowRadious
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadious;
            set => _windowRadious = value;
        }
        public CornerRadius WindowCornerRadious => new CornerRadius(WindowRadious);
        public int TitleHeight { get; set; } = 15;
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);
        public Thickness InnerContentPadding => _window.WindowState == WindowState.Maximized ? new Thickness(0) : new Thickness(0);

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public WindowViewModel(Window window)
        {
            _window = window;
            Height = _window.Height - TitleHeight - ResizeBorder;
            _window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadious));
                OnPropertyChanged(nameof(WindowCornerRadious));
                OnPropertyChanged(nameof(InnerContentPadding));
            };
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());

            var mWindowResizer = new WindowResizability(_window);
        }
    }
}
