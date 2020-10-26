using Cargo_Transportation.DBProvider;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cargo_Transportation.Dialog
{
    public class BaseDialogUserControl : UserControl
    {
        private int                     _deliveryCost = 0;
        private readonly DialogWindow   _dialogWindow;

        public int                      MinimHeight { get; set; } = 100;
        public int                      MinimWidth { get; set; } = 250;
        public int                      TitleHeight { get; set; } = 15;
        public string                   Title { get; set; }

        public ICommand                 SendCommand { get; set; }
        public ICommand                 AcceptCommand { get; set; }
        public ICommand                 RefuseCommand { get; set; }
        public ICommand                 AppointCommand { get; set; }
        public ICommand                 CloseCommand { get; private set; }

        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _dialogWindow = new DialogWindow();
                _dialogWindow.ViewModel = new DialogWindowViewModel(_dialogWindow);

                CloseCommand = new RelayCommand(() => _dialogWindow.Close());
                SendCommand = new RelayCommand(SendMethod);
                RefuseCommand = new RelayCommand(RefuseMethod);
                AcceptCommand = new RelayCommand(AcceptMethod);
                AppointCommand = new RelayCommand(AppointMethod);
            }
        }

        private void                    AppointMethod()
        {
            if ((DataContext as DialogWithOrderInfoViewModel).CompanyCars.FirstOrDefault(c => c.SelectColor == "8a8a8a") != null &&
                (DataContext as DialogWithOrderInfoViewModel).CompanyCars.FirstOrDefault(c => c.SelectColor == "8a8a8a").CarStatus == "Free")
            {
                _dialogWindow.Close();
                var car = (DataContext as DialogWithOrderInfoViewModel).CompanyCars.FirstOrDefault(c => c.SelectColor == "8a8a8a").Car;
                var route = IoC.Application_Work.All_Routes.First(r => r.Product.Id == (DataContext as DialogWithOrderInfoViewModel).Product.Id);

                WorkWithDB.Update_Car_Async(car, route);
                WorkWithDB.Update_Product_Async((DataContext as DialogWithOrderInfoViewModel).Product, StatusOfProduct.HoldDriverAccept);
                (DataContext as DialogWithOrderInfoViewModel).Product.Status = StatusOfProduct.HoldDriverAccept;
                IoC.DispatcherView.Reload_Orders();
            }
        }
        private void                    RefuseMethod()
        {
            _dialogWindow.Close();
            WorkWithDB.Update_Product_Async((DataContext as DialogWithOrderInfoViewModel).Product, StatusOfProduct.Completed);
            (DataContext as DialogWithOrderInfoViewModel).Product.Status = StatusOfProduct.Completed;
            IoC.UserView.Set_Orders();
        }
        private void                    AcceptMethod()
        {
            _dialogWindow.Close();
            WorkWithDB.Update_Product_Async((DataContext as DialogWithOrderInfoViewModel).Product, StatusOfProduct.HoldDispetcherToDriverAccept);
            (DataContext as DialogWithOrderInfoViewModel).Product.Status = StatusOfProduct.HoldDispetcherToDriverAccept;
            IoC.UserView.Set_Orders();
        }
        private void                    SendMethod()
        {
            if (!int.TryParse((DataContext as DialogWithOrderInfoViewModel).DeliveryCost, out _deliveryCost))
                return;
            _dialogWindow.Close();
            WorkWithDB.Update_Product_Async((DataContext as DialogWithOrderInfoViewModel).Product, StatusOfProduct.HoldUserAccept);
            WorkWithDB.Update_Route_Async((DataContext as DialogWithOrderInfoViewModel).Product.Route, _deliveryCost);
            (DataContext as DialogWithOrderInfoViewModel).Product.Status = StatusOfProduct.HoldUserAccept;
            IoC.DispatcherView.Reload_Orders();
        }
        public Task                     ShowDialog<T>(T viewModel)
            where T : BaseDiallogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    _dialogWindow.ViewModel.MinHeight = MinimHeight;
                    _dialogWindow.ViewModel.MinWidth = MinimWidth;
                    _dialogWindow.ViewModel.TitleHeight = TitleHeight;
                    _dialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    _dialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;
                    await Task.Delay(100);
                    _dialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }
    }
}
