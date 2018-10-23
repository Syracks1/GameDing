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
using System.Configuration;
using System.Data.SqlClient;
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CharCreate : Page
    {
        public CharCreate()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var NameTB = tb_name;
            var RaceTB = cb_race;
            var PowerTB = cb_power;
            var ProfTB = cb_profession;

            string Name = NameTB.Text;
            string Race = RaceTB.Text;
            string Power = PowerTB.Text;
            string Prof = ProfTB.Text;

            string connectionString = null;
            string sql = null;
            connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GameDing;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {

                cnn.Open();
                sql = "insert into Character ([Name], [Race], [Power], [Prof]) values(@name,@race,@power,@prof)";
                
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@race", Race);
                    cmd.Parameters.AddWithValue("@power", Power);
                    cmd.Parameters.AddWithValue("@prof", Prof);
                    cmd.ExecuteNonQuery();
                }
            }

            Windows.Game game = new Windows.Game();
            game.Show();

            Window1 win1 = new Window1();
            win1.Close();

            this.Visibility = Visibility.Hidden;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
