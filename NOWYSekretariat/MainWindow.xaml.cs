using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NOWYSekretariat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            NOWYSekretariat.Database1DataSet database1DataSet = ((NOWYSekretariat.Database1DataSet)(this.FindResource("database1DataSet")));
            // Załaduj dane do tabeli _Table_uczen. Możesz modyfikować ten kod w razie potrzeby.
            NOWYSekretariat.Database1DataSetTableAdapters.Table_uczenTableAdapter database1DataSetTable_uczenTableAdapter = new NOWYSekretariat.Database1DataSetTableAdapters.Table_uczenTableAdapter();
            database1DataSetTable_uczenTableAdapter.Fill(database1DataSet._Table_uczen);
            System.Windows.Data.CollectionViewSource _Table_uczenViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("_Table_uczenViewSource")));
            _Table_uczenViewSource.View.MoveCurrentToFirst();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //
    }
}
