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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Data.SqlClient;
using System.Collections;
using WpfApplication1.message;
using WpfApplication1.Model;
using System.Collections.ObjectModel;
using System.Globalization;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    /// 

    public partial class menu : MetroWindow
    {
    
        ObservableCollection<mVentas> venta = new ObservableCollection<mVentas>();
        string con = "Server=PASTELAMORA; Database=BD1; User Id=jdhades; Password = P4nt3r4--";
        public string con2 = @"Server=CONTABILIDAD\SQLEXPRESS; Database=SAFC_ECB; User Id=user; Password = user";
        //string con2 = @"Server=LAYER-PC\TTEST; Database=SAFC_ECB; User Id=profit; Password = profit";
       
        public menu()
        {
            
            InitializeComponent();
        }

         private void CenterWindowsOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            
        }

        private void cerrarVentana(){
            principal.Width = 424;
            CenterWindowsOnScreen();
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
        }
        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            
            principal.Width= 1024;
            CenterWindowsOnScreen();
            //flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            flyVentas.IsOpen = true;

        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyVentas.IsOpen = false;
            flyCobros.IsOpen = false;
            flyCompras.IsOpen = true;
        }

        private void flyCompras_ClosingFinished(object sender, RoutedEventArgs e)
        {
            principal.Width = 424;
            CenterWindowsOnScreen();
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            
        }

        private void flyVentas_ClosingFinished(object sender, RoutedEventArgs e)
        {
            principal.Width = 424;
            CenterWindowsOnScreen();
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
        }


        private void btnCobros_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = true;
        }
   
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

     

        private void cmbFecha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            venta.Clear();
            
            int check = rbMiraflores.IsChecked == true ? 1 : rbEncalada.IsChecked == true ? 2 : 3;
            ComboBox cb = sender as ComboBox;
            string data = cb.SelectedValue ==null?"": cb.SelectedValue.ToString();
            if (data != "")
            {
                DataContext = this.agregarData(data, con, check, sender);
                

            }
        }

         public ObservableCollection<mVentas> agregarData(string data, string con,int codTienda,object sender)
        {

            
             MessageViewModel mv = new MessageViewModel();
           // DataGrid dgv1 = dgVenta as DataGrid;
            ComboBox cb = sender as ComboBox;
            string fechaDia = cb.SelectedValue.ToString();
            decimal total = 0;
            string tienda;
            string buscarTienda;
            if (codTienda == 1)
            {
                tienda = "001T";
                buscarTienda = "01";

            }
            else if (codTienda == 2)
            {
                tienda = "006T";
                buscarTienda = "02";

            }
            else if (codTienda == 3)
            {
                tienda = "007T";
                buscarTienda = "05";

            }
            else
            {
                tienda = "008T";
                buscarTienda = "05";

            }


        string sql;
            try
            {   
                Conexion cn = new Conexion(con);
                sql = @"SELECT A.NUMFACTURA AS NUMERO,0 AS total,0 as totiva,0 as totreq, 0 as baseimponibre FROM FACTURASVENTA AS A
                        where a.FECHAENTRADA = '" + fechaDia + "' and a.NUMSERIE = '" + tienda + "' and a.TOTALNETO = 0 ";
                sql = sql +@" union 
                        SELECT numero,total,totiva,totreq,baseimponible 
                        from FACTURASVENTA b  right outer join FACTURASVENTATOT a on a.NUMERO = b.NUMFACTURA and a.SERIE = b.NUMSERIE
                        where b.FECHAENTRADA = '" + fechaDia + "' and a.SERIE = '" + tienda + "'  order by NUMERO";
                SqlDataReader reader = cn.consulta3(sql);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        venta.Add(new mVentas("12121", buscarTienda, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(1)), 0) { cuenta = "12121", serie = buscarTienda, numero = (reader.GetInt32(0)).ToString(), debe = Convert.ToDecimal(reader.GetValue(1)), haber = 0 });
                        venta.Add(new mVentas("40111", buscarTienda, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(2))) { cuenta = "40111", serie = buscarTienda, numero = (reader.GetInt32(0)).ToString(), debe = 0, haber = Convert.ToDecimal(reader.GetValue(2)) });
                        venta.Add(new mVentas("40997", buscarTienda, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(3))) { cuenta = "40997", serie = buscarTienda, numero = (reader.GetInt32(0)).ToString(), debe = 0, haber = Convert.ToDecimal(reader.GetValue(3)) });
                        venta.Add(new mVentas("40111", buscarTienda, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(4))) { cuenta = "70111", serie = buscarTienda, numero = (reader.GetInt32(0)).ToString(), debe = 0, haber = Convert.ToDecimal(reader.GetValue(4)) });

                    }
                    total = venta.Sum(x => x.cuenta == "12121" ? x.debe : 0);
                }
                
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }
            return venta;
    }

         private void btnSincronizar_Click(object sender, RoutedEventArgs e)
         {
             Integracion ni = new Integracion();
             cmbFecha.Items.Clear();

             ComboBoxItem tab = new ComboBoxItem();
             DateTime inicio = DateTime.Parse(dpFechaIni.Text);
             DateTime final = DateTime.Parse(dpFechaFin.Text);
             TimeSpan dias = final - inicio;
             
             // HAY QUE CAMBIAR TODA ESTA VERGA PARA REDUCIR CODIGO
             for (DateTime i = inicio; i <= final; i = i.AddDays(1))
             {
                 if (dias.Days > 31)
                 {
                     MessageBoxResult result = MessageBox.Show("La diferencia entre fecha es mayor a 30 dias desea continuar?", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                     if (result == MessageBoxResult.OK)
                     {
                         i = final;
                     }

                 }
                 else
                 {
                     ni.verficarVentas(i.ToString("yyyyMMdd"), con, con2);
                 }

                 //cmbFecha.Items.Add(i.ToString("yyyyMMdd"));
                 //cmb.DataContext = tab;
                 //tcGeneral.SelectedIndex = 0;

             }
         }

         private void btncSincronizar_Click(object sender, RoutedEventArgs e)
         {
             Integracion ni = new Integracion();
             cmbcFecha.Items.Clear();

             ComboBoxItem tab = new ComboBoxItem();
             DateTime inicio = DateTime.Parse(dpcFechaIni.Text);
             DateTime final = DateTime.Parse(dpcFechaFin.Text);
             TimeSpan dias = final - inicio;
             for (DateTime i = inicio; i <= final; i = i.AddDays(1))
             {
                 if (dias.Days > 31)
                 {
                     MessageBoxResult result = MessageBox.Show("La diferencia entre fecha es mayor a 30 dias desea continuar?", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                     if (result == MessageBoxResult.OK)
                     {
                         i = final;
                     }

                 }
                 else
                 {
                     ni.verficarCobros(i.ToString("yyyyMMdd"), con, con2);
                 }

                 //cmbFecha.Items.Add(i.ToString("yyyyMMdd"));
                 //cmb.DataContext = tab;
                 //tcGeneral.SelectedIndex = 0;

             }
         }

         private void flyPayment_ClosingFinished(object sender, RoutedEventArgs e)
         {
             principal.Width = 424;
             CenterWindowsOnScreen();
             flyVentas.IsOpen = false;
             flyCompras.IsOpen = false;
         }

         private void cmbpFecha_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {

         }

         private void btnpSincronizar_Click(object sender, RoutedEventArgs e)
         {
             Integracion ni = new Integracion();
            
             DateTime inicio = DateTime.Parse(dpFechaIni.Text);
             DateTime final = DateTime.Parse(dpFechaFin.Text);
             TimeSpan dias = final - inicio;
             
             // HAY QUE CAMBIAR TODA ESTA VERGA PARA REDUCIR CODIGO
             for (DateTime i = inicio; i <= final; i = i.AddDays(1))
             {
                 if (dias.Days > 31)
                 {
                     MessageBoxResult result = MessageBox.Show("La diferencia entre fecha es mayor a 30 dias desea continuar?", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                     if (result == MessageBoxResult.OK)
                     {
                         i = final;
                     }

                 }
                 else
                 {
                     ni.verificarCompras(i.ToString("yyyyMMdd"), con, con2);
                 }

             }
         }

   


             // mv.BindData(con, fechaDia, tienda, buscarTienda);
             
            
    
        
    }
}
