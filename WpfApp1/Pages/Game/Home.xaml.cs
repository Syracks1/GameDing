using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1.Pages.Game
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            string connectionString = null;
            string sql = null;
            connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GameDing;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {

                cnn.Open();
                sql = "SELECT Name FROM dbo.Character";

                SqlCommand q = new SqlCommand(sql, cnn);
                SqlDataReader dr = q.ExecuteReader();
                dr.Read();

                lbl_name.Content = dr["Name"].ToString();

            }

        }

    }

}
