using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.Input
{
    public class                TextEntryViewModel : BaseViewModel
    {
        public string           Label { get; set; }
        public string           OriginalText { get; set; }
        public string           EditedText { get; set; }
        public bool             Editing { get; set; }
        public int              MaxLength { get; set; }
        public UpdateClientData UpdateClientData { get; set; }

        public ICommand         EditCommand { get; set; }
        public ICommand         CancelCommand { get; set; }
        public ICommand         SaveCommand { get; set; }

        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(EditMethod);
            CancelCommand = new RelayCommand(CancelMethod);
            SaveCommand = new RelayCommand(SaveMethod);
        }

        private void            SaveMethod()
        {
            OriginalText = EditedText;
            Editing = false;
            Update_Real_Data();
        }

        private void            CancelMethod()
        {
            Editing = false;
        }
        private void            EditMethod()
        {
            EditedText = OriginalText;
            Editing = true;
        }

        private void            Update_Client_Data()
        {
            switch (UpdateClientData)
            {
                case UpdateClientData.FullName:
                    (IoC.Application_Work.Current_User as Client).FullName = OriginalText;
                    break;
                case UpdateClientData.PhoneNumber:
                    (IoC.Application_Work.Current_User as Client).PhoneNumber = OriginalText;
                    break;
                case UpdateClientData.Email:
                    (IoC.Application_Work.Current_User as Client).Email = OriginalText;
                    break;
                case UpdateClientData.CompanyName:
                    (IoC.Application_Work.Current_User as Client).CompanyName = OriginalText;
                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }
        private async void      Update_Real_Data()
        {
            // TODO: Add to db
            await Task.Run(() =>
            {
                //foreach (var us in IoC.Application_Work.All_Users)
                //    if (us == )

                Update_Client_Data();
                IoC.UserView.PersonalAreaVM.Update_User_PA();
            });
        }
    }
}
