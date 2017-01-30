using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace kf_ga_modelling.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _recordsFile = "N/A";
        ICommand _openFileCmd = null;
        #endregion


        public string RecordsFile {
            get { return _recordsFile; }
            set {
                _recordsFile = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenFileCommand {
            get {
                if (_openFileCmd == null)
                {
                    _openFileCmd = new AsyncDelegateCommand(OpenFileExecuted, false);
                }

                return _openFileCmd;
            }
        }

        async Task OpenFileExecuted(object s)
        {
            await Task.Factory.StartNew(() =>
            {
                var dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == true)
                {
                    RecordsFile = dialog.FileName;
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
