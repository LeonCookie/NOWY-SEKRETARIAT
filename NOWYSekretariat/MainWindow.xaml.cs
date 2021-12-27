using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System;
using System.Data;

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
            binddatagrip();

        }

        private void binddatagrip()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NOWYSekretariat.Properties.Settings.dbUczenConnection"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select  * from[Table-uczen]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Uczen");
            da.Fill(dt);

            g1.ItemsSource = dt.DefaultView;
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

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NOWYSekretariat.Properties.Settings.dbUczenConnection"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Inser into[Table-uczen](Imie)values(@nm)";
            cmd.Parameters.AddWithValue("@nm", textbox_uczen_imie.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if(a==1)
            {
                MessageBox.Show("Data add ");
                binddatagrip();
            }

        }

        //
    }
}
