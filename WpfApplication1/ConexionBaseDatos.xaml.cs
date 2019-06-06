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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ConexionBaseDatos.xaml
    /// </summary>
    public partial class ConexionBaseDatos : Window
    {
        public ConexionBaseDatos()
        {
            InitializeComponent();
        }

        public static void BuilConnectionString(string DataSource, string InitialCatalog, string UserId, string Password)
        {
            Conexion.BuilConnectionString(DataSource, InitialCatalog, UserId, Password);
        }

        private void btnServerAdmin_Click(object sender, RoutedEventArgs e)
        {
            string NServidor = txtNombreServidor.Text;
            string NDatabase = txtNombreDB.Text;
            string NUsuario = txtUsuario.Text;
            string NPass = txtPassword.Text;

            BuilConnectionString(NServidor, NDatabase, NUsuario, NPass);
        }

      
        
    }
}
