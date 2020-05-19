using MiniTC.ViewModel.BaseClass;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class ViewModel : ViewModelBase
    {
        #region własności
        // path - panel 1
        private string currentDir1 = null;
        public string CurrentDir1
        {
            get { return currentDir1; }
            set
            {
                currentDir1 = value;
                onPropertyChanged(nameof(Files1));
                onPropertyChanged(nameof(CurrentDir1));
            }
        }

        // path - panel 2
        private string currentDir2 = null;
        public string CurrentDir2
        {
            get { return currentDir2; }
            set
            {
                currentDir2 = value;
                onPropertyChanged(nameof(Files2));
                onPropertyChanged(nameof(CurrentDir2));
            }
        }

        // lista dysków
        public ObservableCollection<string> Disks
        {
            get { return new ObservableCollection<string>(Model.Model.FindDisks()); }
        }

        // lista plików na lewym panelu
        public ObservableCollection<string> Files1
        {
            get { return new ObservableCollection<string>(Model.Model.FindFiles(CurrentDir1)); }
        }

        // lista plików na prawym panelu
        public ObservableCollection<string> Files2
        {
            get { return new ObservableCollection<string>(Model.Model.FindFiles(CurrentDir2)); }
        }

        // lewy panel
        private ICommand _click1 = null;
        public ICommand Click1
        {
            get
            {
                return _click1 ?? (_click1 = new RelayCommand(
                    (arg) => { CurrentDir1 = Model.Model.ChangePath(CurrentDir1, SelectedItem); },
                    (arg) => true
                    ));
            }
        }

        // prawy panel
        private ICommand _click2 = null;
        public ICommand Click2
        {
            get
            {
                return _click2 ?? (_click2 = new RelayCommand(
                    (arg) => { CurrentDir2 = Model.Model.ChangePath(CurrentDir2, SelectedItem); },
                    (arg) => true
                    ));
            }
        }

        // przycisk "Copy>>"
        private ICommand _copyClick = null;
        public ICommand CopyClick
        {
            get
            {
                return _copyClick ?? (_copyClick = new RelayCommand(
                    (arg) => { 
                        if (currentDir2 != null) 
                            Model.Model.CopyFile(CurrentDir1 + @"\" + SelectedItem, currentDir2 + @"\" + SelectedItem);

                        onPropertyChanged(nameof(Files2));
                    },
                    (arg) => true
                    ));
            }
        }

        public string SelectedItem { get; set; }

        #endregion
    }
}
