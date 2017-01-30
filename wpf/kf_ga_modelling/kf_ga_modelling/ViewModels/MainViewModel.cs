using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kf_ga_modelling.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _recordsFile = "N/A";
        #endregion


        public string RecordsFile {
            get { return _recordsFile; }
            set {
                _recordsFile = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
