using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MiniTC
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register(
                "Path",
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
                );

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public static readonly DependencyProperty DisksProperty =
            DependencyProperty.Register(
                "Disks",
                typeof(ObservableCollection<string>),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
                );

        public ObservableCollection<string> Disks
        {
            get { return (ObservableCollection<string>)GetValue(DisksProperty); }
            set { SetValue(DisksProperty, value); }
        }

        public static readonly DependencyProperty FilesProperty =
            DependencyProperty.Register(
                "Files",
                typeof(ObservableCollection<string>),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
                );

        public ObservableCollection<string> Files
        {
            get { return (ObservableCollection<string>)GetValue(FilesProperty); }
            set { SetValue(FilesProperty, value); }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Path = e.AddedItems[0].ToString();
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem",
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
                );

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}
