using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data;
using System.Windows.Input;
using System;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Text;
using System.IO;
using System.Diagnostics;

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
            cmd.CommandText = "Select  * from[Table-Ubsluga]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Table_Ubsluga");
            da.Fill(dt);

            g3.ItemsSource = dt.DefaultView;

            con.Close();
        }




        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {


            if (!string.IsNullOrEmpty(textbox_uczen_imie.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_Pesel.Text) && !string.IsNullOrEmpty(combobox_uczen_klasa.Text) && textbox_uczen_Pesel.Text.Length == 11) //wymagane pola nie sa puste
            {
                
                
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                con.Open();

                // insert command 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"INSERT INTO  [Table-uczen](Imie, DrugieImie, Nazwisko, NazwiskoPanienskie, ImieMatki, ImieOjca, DataUrodzenia,  Pesel, Plec, Klasa, Grupa) VALUES(@Imie, @DrugieImie, @Nazwisko, @NazwiskoPanienskie, @ImieMatki, @ImieOjca, @DataUrodzenia, @Pesel,@Plec,@Klasa, @Grupa)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Imie", textbox_uczen_imie.Text);
                cmd.Parameters.AddWithValue("@DrugieImie", textbox_uczen_drugieImie.Text);
                cmd.Parameters.AddWithValue("@Nazwisko", textbox_uczen_nazwisko.Text);
                cmd.Parameters.AddWithValue("@NazwiskoPanienskie", textbox_uczen_nazwiskoPanienskie.Text);
                cmd.Parameters.AddWithValue("@ImieMatki", textbox_uczen_ImieMatki.Text);
                cmd.Parameters.AddWithValue("@ImieOjca", textbox_uczen_ImieOjca.Text);
               cmd.Parameters.AddWithValue("@DataUrodzenia", data_urodzenia.Text);
                cmd.Parameters.AddWithValue("@Pesel", textbox_uczen_Pesel.Text);
                cmd.Parameters.AddWithValue("@Plec", combobox_uczen_plec.Text);
                cmd.Parameters.AddWithValue("@Klasa", combobox_uczen_klasa.Text);
                cmd.Parameters.AddWithValue("@Grupa", combobox_uczen_grupa.Text);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("zamknieto");
                binddatagrip();

            }
            else
            {
                MessageBox.Show("Uzupełnij wymagane pola: Imie,Nazwisko,Pesel(musi posiadac 11 cyfr),Klasa");
            }
        }



        
        private void buttonSendnauczyciel_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textbox_uczen_imie.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_Pesel.Text) && !string.IsNullOrEmpty(combobox_uczen_klasa.Text) && textbox_uczen_Pesel.Text.Length == 11) //wymagane pola nie sa puste
            {

            }
            else
            {

            }
           
        }

        private void buttonSendobsluga_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(textbox_uczen_imie.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_nazwisko.Text) && !string.IsNullOrEmpty(textbox_uczen_Pesel.Text) && !string.IsNullOrEmpty(combobox_uczen_klasa.Text) && textbox_uczen_Pesel.Text.Length == 11) //wymagane pola nie sa puste
            {
            }
            else
            {

            }
            */
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
        private void textbox_nauczyciel_imie_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) //tylko litery w textbox imie
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

        private void textbox_nauczyciel_Pesel_PreviewKeyDown(object sender, KeyEventArgs e) //tylko liczby w peselu
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

        private void textbox_nauczyciel_drugieImie_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_nauczyciel_nazwisko_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_nauczyciel_nazwiskoPanienskie_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_nauczyciel_ImieMatki_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_nauczyciel_ImieOjca_PreviewKeyDown(object sender, KeyEventArgs e)
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
        private void textbox_obsluga_imie_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) //tylko litery w textbox imie
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

        private void textbox_obsluga_Pesel_PreviewKeyDown(object sender, KeyEventArgs e) //tylko liczby w peselu
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

        private void textbox_obsluga_drugieImie_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_obsluga_nazwisko_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_obsluga_nazwiskoPanienskie_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_obsluga_ImieMatki_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void textbox_obsluga_ImieOjca_PreviewKeyDown(object sender, KeyEventArgs e)
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
        private void combobox_obsluga_Etat_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void btn_uczen_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                image_uczen.Source = new BitmapImage(fileUri);
            }
        }

        private void btn_nauczyciel_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                image_nauczyciel.Source = new BitmapImage(fileUri);
            }
        }

        private void btn_obsluga_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                image_obsluga.Source = new BitmapImage(fileUri);
            }
        }

        private void btn_daneUczniowie_Click(object sender, RoutedEventArgs e)
        {
            this.g1.SelectAllCells();
            this.g1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.g1);
            this.g1.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("UczenDane.txt");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("UczenDane.txt");
            }
            catch (Exception ex)
            { }
            MessageBox.Show("Pliki znajduja sie w katalogu bin/Debug w folderze z programem ");
        }

        private void btn_daneNauczyciel_Click(object sender, RoutedEventArgs e)
        {
            this.g2.SelectAllCells();
            this.g2.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.g2);
            this.g2.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("NauczycielDane.txt");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("NauczycielDane.txt");
            }
            catch (Exception ex)
            { }
            MessageBox.Show("Pliki znajduja sie w katalogu bin/Debug w folderze z programem ");
        }

        private void btn_daneObsluga_Click(object sender, RoutedEventArgs e)
        {
            this.g3.SelectAllCells();
            this.g3.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.g3);
            this.g3.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("ObslugaDane.txt");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("ObslugaDane.txt");
            }
            catch (Exception ex)
            { }
            MessageBox.Show("Pliki znajduja sie w katalogu bin/Debug w folderze z programem ");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(data_urodzenia.Text);
        }












        //
    }
}
