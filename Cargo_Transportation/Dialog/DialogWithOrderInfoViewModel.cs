﻿using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.DriverViewModels;
using Cargo_Transportation.ViewModels.Order;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Cargo_Transportation.Dialog
{
    public class                                    DialogWithOrderInfoViewModel : BaseDiallogViewModel
    {
        public string                               Id { get; set; }
        public string                               PriceOneCar { get; set; }
        public string                               NumberCars { get; set; }
        public string                               DeliveryCost { get; set; }
        public Product                              Product { get; set; }
        public OrderDialogViewModel                 OrderDialogViewModel { get; set; }
        public ObservableCollection<CarViewModel>   CompanyCars { get; set; }


        public ICommand                             CancelCommand { get; set; }

        public DialogWithOrderInfoViewModel()
        {
            CancelCommand = new RelayCommand(CancelMethod);
            CompanyCars = new ObservableCollection<CarViewModel>();
            Initialize_CarViewModel();
            CompanyCars.CollectionChanged += CompanyCars_CollectionChanged;
        }
        private void CompanyCars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            (sender as ObservableCollection<CarViewModel>).Last().PropertyChanged += DialogWithOrderInfoViewModel_PropertyChanged;

        private void DialogWithOrderInfoViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((sender as CarViewModel).SelectColor == "8a8a8a")
                foreach (var car in CompanyCars)
                    if (car != (sender as CarViewModel))
                        car.SelectColor = "7d7d7d";
        }

        private CarViewModel                        Create_CarViewModel(Car car)
        {
            return (new CarViewModel() 
            {
                CarProfilePictureRGB = "ff4",
                CarInitials = car.CarBrand[0].ToString(),
                CarBrand = car.CarBrand,
                CarDriver = car.CurrentDriver.FullName,
                CarStatus = car.CurrentRoute != null ? "Busy" : "Free",
                CarLiftingCapacity = car.LiftingCapacity.ToString(),
                StatusColor = car.CurrentRoute != null ? "ff4747" : "00c541",
                Product = this.Product,
                Car = car
            });
        }
        private void                                Initialize_CarViewModel()
        {
            foreach (var car in IoC.Application_Work.All_Cars)
                CompanyCars.Add(Create_CarViewModel(car));
        }
        private void                                CancelMethod()
        {
            throw new NotImplementedException();
        }
    }
}
