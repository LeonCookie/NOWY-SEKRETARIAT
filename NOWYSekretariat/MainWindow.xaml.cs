using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data;
using System.Windows.Input;
using System;


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
            binddatagrip2();
            binddatagrip3();

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
            DataTable dt = new DataTable("Table-uczen");
            da.Fill(dt);

            g1.ItemsSource = dt.DefaultView;

            con.Close();
        }
        private void binddatagrip2()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NOWYSekretariat.Properties.Settings.dbUczenConnection"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select  * from[Table-Nauczyciel]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table-Nauczyciel");
            da.Fill(dt);

            g2.ItemsSource = dt.DefaultView;

            con.Close();
        }
        private void binddatagrip3()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NOWYSekretariat.Properties.Settings.dbUczenConnection"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select  * from[Table-Obsluga]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table-Obsluga");
            da.Fill(dt);

            g3.ItemsSource = dt.DefaultView;

            con.Close();
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


            if (!string.IsNullOrEmpty(textbox_uczen_imie.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_Pesel.Text) && !string.IsNullOrEmpty(combobox_uczen_klasa.Text) && textbox_uczen_Pesel.Text.Length == 11) //wymagane pola nie sa puste
            {


                /*  SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "insert into [Table-uczen](Imie,DrugieImie,Nazwisko,NazwiskoPanienskie,ImieMatki,ImieOjca,DataUrodzenia,Pesel,Plec,Klasa, Grupa) values(@Imie,@DrugieImie,@Nazwisko,@NazwiskoPanienskie,@ImieMatki,@ImieOjca,@Pesel,@Klasa,@Grupa)";
                cmd.Parameters.AddWithValue("@Imie", textbox_uczen_imie.Text);
                cmd.Parameters.AddWithValue("@DrugieImie", textbox_uczen_drugieImie.Text);
                cmd.Parameters.AddWithValue("@Nazwisko", textbox_uczen_nazwisko.Text);
                cmd.Parameters.AddWithValue("@NazwiskoPanienskie", textbox_uczen_nazwiskoPanienskie.Text);
                cmd.Parameters.AddWithValue("@ImieMatki", textbox_uczen_ImieMatki.Text);
                cmd.Parameters.AddWithValue("@ImieOjca", textbox_uczen_ImieOjca.Text);
                cmd.Parameters.AddWithValue("@Pesel", textbox_uczen_Pesel.Text);
                cmd.Parameters.AddWithValue("@Plec", combobox_uczen_plec.Text);
                cmd.Parameters.AddWithValue("@Klasa", combobox_uczen_klasa.Text);
                cmd.Parameters.AddWithValue("@Grupa", combobox_uczen_grupa.Text);
                */
                /* string connectionstring = "NOWYSekretariat.Properties.Settings.dbUczenConnection";
                 SqlConnection con = new SqlConnection(connectionstring);
                 con.Open(); 
                 SqlCommand cmd = new SqlCommand("insert into Table-uczen(Imie,Drugie Imie,Nazwisko, NazwiskoPanienskie, ImieMatki, ImieOjca, DataUrodzenia,Pesel,Plec,Klasa, Grupa) values('"+textbox_uczen_imie.Text+ "','" + textbox_uczen_drugieImie.Text +"','" + textbox_uczen_nazwisko.Text + "','" + textbox_uczen_nazwiskoPanienskie.Text + "','" + textbox_uczen_ImieMatki.Text + "','" + textbox_uczen_ImieOjca.Text + "','" + textbox_uczen_Pesel.Text + "','" + combobox_uczen_plec.Text + "','" + combobox_uczen_klasa.Text + "','" + combobox_uczen_grupa.Text + "')",con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 MessageBox.Show("Udalo się");
                */

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["NOWYSekretariat.Properties.Settings.dbUczenConnection"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into [Table-uczen](Imie)values(@Imie)";
                cmd.Parameters.AddWithValue("@Imie", textbox_uczen_imie.Text);

                cmd.CommandText = "insert into [Table-uczen](DrugieImie)values(@DrugieImie)";
                cmd.Parameters.AddWithValue("@DrugieImie", textbox_uczen_drugieImie.Text);

                cmd.CommandText = "insert into [Table-uczen](Nazwisko)values(@Nazwisko)";
                cmd.Parameters.AddWithValue("@Nazwisko", textbox_uczen_nazwisko.Text);

                cmd.CommandText = "insert into [Table-uczen](NazwiskoPanienskie)values(@NazwiskoPanienskie)";
                cmd.Parameters.AddWithValue("@NazwiskoPanienskie", textbox_uczen_nazwiskoPanienskie.Text);

                cmd.CommandText = "insert into [Table-uczen](ImieMatki)values(@ImieMatki)";
                cmd.Parameters.AddWithValue("@ImieMatki", textbox_uczen_ImieMatki.Text);

                cmd.CommandText = "insert into [Table-uczen](ImieOjca)values(@ImieOjca)";
                cmd.Parameters.AddWithValue("@ImieOjca", textbox_uczen_ImieOjca.Text);

                cmd.CommandText = "insert into [Table-uczen]( DataUrodzenia)values(@DataUrodzenia)";
                cmd.Parameters.AddWithValue("@DataUrodzenia", data_urodzenia.Text);

                cmd.CommandText = "insert into [Table-uczen](Pesel)values(@Pesel)";
                cmd.Parameters.AddWithValue("@Pesel", textbox_uczen_Pesel.Text);

                cmd.CommandText = "insert into [Table-uczen](Plec)values(@Plec)";
                cmd.Parameters.AddWithValue("@Plec", combobox_uczen_plec.Text);

                cmd.CommandText = "insert into [Table-uczen](Klasa)values(@Klasa)";
                cmd.Parameters.AddWithValue("@Klasa", combobox_uczen_klasa.Text);

                cmd.CommandText = "insert into [Table-uczen](Grupa)values(@Grupa)";
                cmd.Parameters.AddWithValue("@Grupa", combobox_uczen_grupa.Text);

                


                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("Data cos tam");
                    binddatagrip();
                }








            }
            else
            {
                MessageBox.Show("Uzupełnij wymagane pola: Imie,Nazwisko,Pesel(musi posiadac 11 cyfr),Klasa");
            }


        }









        private void textbox_uczen_imie_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) //tylko litery w textbox imie
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }

        }

        private void textbox_uczen_Pesel_PreviewKeyDown(object sender, KeyEventArgs e) //tylko liczby w peselu
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;


            if (isNumber || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko cyfry");
            }

        }

        private void textbox_uczen_drugieImie_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }
        }

        private void textbox_uczen_nazwisko_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }
        }

        private void textbox_uczen_nazwiskoPanienskie_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }
        }

        private void textbox_uczen_ImieMatki_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }
        }

        private void textbox_uczen_ImieOjca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isCtrlA = e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isCtrlV = e.Key == Key.V && e.KeyboardDevice.Modifiers == ModifierKeys.Control;
            bool isBack = e.Key == Key.Back;
            bool isLeftOrRight = e.Key == Key.Left || e.Key == Key.Right;
            bool isUpOrDown = e.Key == Key.Up || e.Key == Key.Down;
            bool shift = e.Key == Key.LeftShift || e.Key == Key.RightShift;

            if (isLetter || isCtrlA || isCtrlV || isBack || isLeftOrRight || isUpOrDown || shift)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Tylko litery");
            }
        }

        private void textbox_uczen_Pesel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        



        //
    }
}
