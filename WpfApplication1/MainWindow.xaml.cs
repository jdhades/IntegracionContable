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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
             string con2 = @"Server=CONTABILIDAD\SQLEXPRESS; Database=SAFC_ECB; User Id=user; Password = user";
             string sql = "SELECT * FROM SGM_USUARIOS WHERE usu_cCodUsuario = '" + txtUsuario.Text + "'";
            Conexion cn = new Conexion(con2);


            SqlDataReader reader = cn.consulta3(sql);
            if (reader.HasRows)
            {

                menu _ver = new menu();
                this.Close();
                _ver.ShowDialog();
            }
              
            else
                await this.ShowMessageAsync("Error", "Verifica tus datos");
            
        }
    }
}
