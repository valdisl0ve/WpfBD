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
using MySql.Data.MySqlClient;

namespace WpfBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    class Product
    {
        public Product()
        {
        }

        public Product(int id, string product_name, int remainder, int id_table_manufacturer, int id_table_type, int self_price)
        {
            this.id = id;
            this.product_name = product_name;
            this.remainder = remainder;
            this.id_table_manufacturer = id_table_manufacturer;
            this.id_table_type = id_table_type;
        this.self_price = self_price;
        }
        public int id { get; set; }
        public string product_name { get; set; }
        public int remainder { get; set; }
        public int id_table_manufacturer { get; set; }
        public int id_table_type { get; set; }
        public int self_price { get; set; }
    }



    public partial class MainWindow : Window
    {


        MySqlConnection db = new MySqlConnection(connection);
        const string connection =" Server=mysql60.hostland.ru;    Database=host1323541_vrn08;   Uid=host1323541_itstep;   Pwd=269f43dc;   ";
        List<Product> product_list = new List<Product>();


        public MainWindow()
        {
            InitializeComponent();




            
               
                //product_list.Add(new Product(1, "тетрадь", 10, 1, 1, 50));
                //grid.ItemsSource = product_list;
            


        }

        private void dbConnect_Click(object sender, RoutedEventArgs e)
        {
            try {
                db = new MySqlConnection(connection);
                db.Open();
                log.Content = "Connected";
            }
            catch
            {
                log.Content = "fail to connect";
            }
        }

        private void get_product_data_Click(object sender, RoutedEventArgs e)
        {


            MySqlCommand command = new MySqlCommand($"SELECT * FROM table_product ", db);
            MySqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                Product product = new Product();
                product.id = (int)reader["id"];
                product.product_name = reader["product_name"].ToString();
                product.remainder = (int)reader["remainder"];
                product.id_table_manufacturer = (int)reader["id_table_manufacturer"];
                product.id_table_type = (int)reader["id_table_type"];
                product.self_price = (int)reader["self_price"];
                product_list.Add(product);
            }
            grid.ItemsSource = product_list;
            db.Close();
        }
    }
}
