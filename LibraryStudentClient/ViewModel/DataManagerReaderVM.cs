using LibraryStudentClient.Model;
using LibraryStudentClient.View.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.ViewModel
{
    public class DataManagerReaderVM : INotifyPropertyChanged
    {
        #region Блок личного кабинета
        public string Name
        {
            get { return Reader.Name; }
        }
        public string SurName
        {
            get { return Reader.SurName; }
        }
        public string Patronimic
        {
            get { return Reader.Patronimic; }
        }
        public string LibraryCard
        {
            get { return Reader.LibraryCard; }
        }
        public string MobilePhone
        {
            get { return Reader.MobilePhone; }
        }
        public string StudCard
        {
            get { return Reader.StudCard; }
        }
        public List<History> HistoryList
        {
            get { return Reader.Histories; }
            set { Reader.Histories = value; NotifyPropertyChanged("HistoryList"); }
        }

        private History? selectedRecord;
        public History? SelectedRecord
        {
            get { return selectedRecord; }
            set { selectedRecord = value;}
        }

        public void ReturnBook()
        {
            SelectedRecord.ReturnDate = DateTime.Today.ToString("d");
            UserCabinet.view.Items.Refresh();

        }
        #endregion

        #region Блок Мои заявки


        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
