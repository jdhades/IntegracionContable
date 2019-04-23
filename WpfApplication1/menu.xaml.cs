using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
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
using System.Data;
using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Windows.Media.Animation;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    /// 
  
    public partial class menu : MetroWindow
    {


        
        ObservableCollection<mVentas> venta = new ObservableCollection<mVentas>();
        
       
        
        public menu()
        {
            
            InitializeComponent();
           
        
        }

        private void CreateDynamicProgressBarControl()
        {
            ProgressBar PBar2 = new ProgressBar();
            PBar2.IsIndeterminate = false;
            PBar2.Orientation = Orientation.Horizontal;
            PBar2.Width = 200;
            PBar2.Height = 20;
            Duration duration = new Duration(TimeSpan.FromSeconds(20));
            DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);
            PBar2.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            SBar.Items.Add(PBar2);
        }  
       


       
        public bool fillComboBox(string connectionString, System.Windows.Controls.ComboBox combobox, string query, string defaultValue, string itemText, string itemValue)
        {
            
             MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter sqladp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection _sqlconTeam = new SqlConnection(connectionString))
                {
                    sqlcmd.Connection = _sqlconTeam;
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = query;
                    _sqlconTeam.Open();
                    sqladp.SelectCommand = sqlcmd;
                    //sqladp.Fill(ds);
                    sqladp.Fill(ds, "defaultTable");
                    DataRow nRow = ds.Tables["defaultTable"].NewRow();
                    //nRow[itemText] = defaultValue;
                    //nRow[itemValue] = "-1";
                    ds.Tables["defaultTable"].Rows.InsertAt(nRow, 0);
                    combobox.DataContext = ds.Tables["defaultTable"].DefaultView;

                    combobox.DisplayMemberPath = itemText;//ds.Tables["defaultTable"].Columns[0].ToString();
                    combobox.SelectedValuePath = itemValue;
                }
                return true;
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();
                return false;

            }
            finally
            {
                sqladp.Dispose();
                sqlcmd.Dispose();
            }
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
            flyReportesVentas.IsOpen = false;
            flyGastos.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyVentas.IsOpen = true;

        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyReportesVentas.IsOpen = false;
            flyGastos.IsOpen = false;
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyEliminar.IsOpen = true;
            flyCobros.IsOpen = false;
        }
        private void btnCobros_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyReportesVentas.IsOpen = false;
            flyGastos.IsOpen = false;
            flyVentas.IsOpen = false;
            flyCompras.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyCobros.IsOpen = true;
        }
        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["movimientos"] = 1;
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyReportesVentas.IsOpen = false;
            flyVentas.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyGastos.IsOpen = false;
            flyCompras.IsOpen = true;
            
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {


        }
        private void btnCompras_Tienda_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["movimientos"] = 0;
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyReportesVentas.IsOpen = false;
            flyVentas.IsOpen = false;
            flyGastos.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyCompras.IsOpen = true;
            
        }
        private void btnGastos_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyReportesVentas.IsOpen = false;
            flyGastos.IsOpen = true;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyVentas.IsOpen = false;

        }

        private void mItemVentas_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            flyGastos.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyVentas.IsOpen = false;
            flyReportesVentas.IsOpen = true;
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


        private void mItemRptFormaPago_Click(object sender, RoutedEventArgs e)
        {
            principal.Width = 1024;
            CenterWindowsOnScreen();
            //flyVentas.IsOpen = false;
            flyReportesVentas.IsOpen = false;
            flyGastos.IsOpen = false;
            flyCompras.IsOpen = false;
            flyCobros.IsOpen = false;
            flyEliminar.IsOpen = false;
            flyVentas.IsOpen = false;
            flyReportesFormasPago.IsOpen = true;
            string sql = "select codformapago id, descripcion descrip from formaspago";
            fillComboBox(con, cbReporteFpTienda, sql, null, "descrip", "id");
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
                tienda = "B001";
                buscarTienda = "01";

            }
            else if (codTienda == 2)
            {
                tienda = "B002";
                buscarTienda = "02";

            }
            else if (codTienda == 3)
            {
                tienda = "B003";
                buscarTienda = "05";

            }
            else
            {
                tienda = "B004";
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
             
             
             DateTime inicio = DateTime.Parse(dpFechaIni.Text);
             DateTime final = DateTime.Parse(dpFechaFin.Text);
             TimeSpan dias = final - inicio;
             
             // HAY QUE CAMBIAR TODA ESTA VERGA PARA REDUCIR CODIGO
             for (DateTime i = inicio; i <= final; i = i.AddDays(1))
             {
                 CreateDynamicProgressBarControl();
                // mpd.Command.Execute(null);

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
            
            
             DateTime inicio = DateTime.Parse(dpcFechaIni.Text);
             DateTime final = DateTime.Parse(dpcFechaFin.Text);
             TimeSpan dias = final - inicio;
             for (DateTime i = inicio; i <= final; i = i.AddDays(1))
             {
                 CreateDynamicProgressBarControl();
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
            
             DateTime inicio = DateTime.Parse(dppFechaIni.Text);
             DateTime final = DateTime.Parse(dppFechaFin.Text);
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

         private void principal_Closed(object sender, EventArgs e)
         {
             
             principal.Close();
             GC.Collect();
         }

         private void principal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
         {
             App.Current.Shutdown();
             GC.Collect();
         }

         
         private void cbPeriodo_Initialized(object sender, EventArgs e)
         {
             var americanCulture = new CultureInfo("en-US");
             List<string> names = new List<string>();
             int num = 1;
             foreach (var item in americanCulture.DateTimeFormat.MonthNames.Take(12))
             {
                 cbPeriodo.Items.Add(string.Format("{0} - {1}", num++.ToString("D2"), item));
             }
             
         }

         private void flyEliminar_ClosingFinished(object sender, RoutedEventArgs e)
         {
             {
                 principal.Width = 424;
                 CenterWindowsOnScreen();
                 flyEliminar.IsOpen = false;
                 flyEliminar.IsOpen = false;
                 vYear.Text = "";
                 vHasta.Text = "";
                 vDesde.Text = "";
                 cbPeriodo.Text = "";
                 cbLibro.Text = "";
                 dgEliminar.ItemsSource = null;
                 
             }
         }

         private void Button_Click(object sender, RoutedEventArgs e)
         {
             MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
             ComboBoxItem typeItem = (ComboBoxItem)cbLibro.SelectedItem;


             string vPeriodo = cbPeriodo.Text == ""?"":cbPeriodo.Text.Substring(0,2);//.SelectedItem.ToString().Substring(0, 2) == "" ? "" : cbPeriodo.SelectedItem.ToString().Substring(0, 2);
             string vLibro = cbLibro.Text == ""?"":cbLibro.Text.Substring(0, 2); //typeItem.Content.ToString().Substring(0, 2) == "" ? "" : typeItem.Content.ToString().Substring(0, 2);

            
             if (vDesde.Text != "" && vHasta.Text != "" && vYear.Text != "" && vPeriodo != "" && vLibro != "")
             {
                 FillDataGrid(vDesde.Text, vHasta.Text, vYear.Text, vPeriodo, vLibro, con, con2);
             }
             else
             {
                 mv.Message = "No Puede haber Campos Vacios";
                 mv.Caption = "Campos Vacios";
                 mv.mensajeria();
             }
             
         }

         /// <summary>
        /// Eliminar asientos malos
        /// </summary>
        /// <param name="vDesde"></param>
        /// <param name="vHasta"></param>
        /// <param name="vYear"></param>
        /// <param name="vPeriodo"></param>
        /// <param name="vLibro"></param>
        /// <param name="conex1"></param>
        /// <param name="conex2"></param>
        public void FillDataGrid(string vDesde, string vHasta, string vYear, string vPeriodo, string vLibro, string conex1, string conex2)
        {
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            string CmdString = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(conex2))
                {
                    CmdString = @"SELECT  Pan_cAnio as vyear, Per_cPeriodo as periodo, Lib_cTipoLibro as libro , Ase_nVoucher as asiento, Ase_dFecha as fecha, Ase_cGlosa as glosa
                             FROM CNC_ASIENTO_VOUCHER
                             WHERE (Emp_cCodigo = '003') AND  Ase_nVoucher BETWEEN '" +
                                 vDesde + "' and '" + vHasta + "' and Pan_cAnio = '" +
                                 vYear + "' and Per_cPeriodo = '" + vPeriodo + "' and Lib_cTipoLibro =  '" + vLibro + "'";
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    
                    
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgEliminar.ItemsSource = dt.DefaultView;
                            //dt.DefaultView.
                            eliminar.IsEnabled = true;
                        }
                        else
                        {
                            mv.Message = "No se encontro Registro, Por favor verifique";
                            mv.Caption = "No hay Registro";
                            mv.mensajeria();
                        }


                        con.Close();


                }
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();
                
            }
        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cbLibro.SelectedItem;

            string vPeriodo = cbPeriodo.SelectedItem.ToString().Substring(0, 2);
            string vLibro = typeItem.Content.ToString().Substring(0, 2);

               // Display a message box asking users if they
           // want to exit the application.
            MessageBoxResult result = MessageBox.Show(@"Esta Seguro que desea ELIMINAR esta informacion Asientos Desde: " +
                                                     vDesde.Text+" Hasta: "+vHasta.Text+" Año: "+ vYear.Text + " Periodo: " + vPeriodo + " Libro: " + vLibro 
                                                     , "ELIMINAR ASIENTOS", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Do this
                   eliminarData(vDesde.Text, vHasta.Text, vYear.Text, vPeriodo, vLibro, con2);
            }else{
                eliminar.IsEnabled = false;
            }
            
        }

        private void realizarBackup()
        {
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            string location = @"D:\MEGA\";
            string dbase = @"SAFC_ECB";
            try
            {
                using (SqlConnection cn = new SqlConnection(con3))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("sp_BackupDatabases", cn);
                    cmd.CommandTimeout = 240;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@backupLocation", location);
                    cmd.Parameters.AddWithValue("@databaseName", dbase);
                    cmd.Parameters.AddWithValue("@backupType", 'F');

                    SqlDataReader dr = cmd.ExecuteReader();
                    cn.Close();

                }
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }
        }
        
        private void eliminarData(string p1, string p2, string p3, string vPeriodo, string vLibro,  string con2)
        {
           
            string CmdString = @"DELETE FROM CNC_ASIENTO_VOUCHER
                                 WHERE (Emp_cCodigo = '003') AND  Ase_nVoucher BETWEEN '" +
                                 p1 + "' and '" + p2 + "' and Pan_cAnio = '" +
                                 p3 + "' and Per_cPeriodo = '" + vPeriodo + "' and Lib_cTipoLibro =  '" + vLibro + "'";
            CreateDynamicProgressBarControl();
            realizarBackup();
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            try
            {
              Conexion con = new Conexion(con2);
               if(con.Eliminar(CmdString)){

                   dgEliminar.ItemsSource = null;
                      vYear.Text = "";
                      vHasta.Text = "";
                      vDesde.Text = "";
                      cbPeriodo.Text = "";
                      cbLibro.Text = ""; 
                   mv.Message = "Se realizo la eliminacion de forma satisfactoria";
                        mv.Caption = "No hay Registro";
                        mv.mensajeria();
               }

            }
             catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }
        }

        private void btnGastosSincronizar_Click(object sender, RoutedEventArgs e)
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
                     ni.verificarGastos(i.ToString("yyyyMMdd"),i, final,con, con2);
                 }

                 //cmbFecha.Items.Add(i.ToString("yyyyMMdd"));
                 //cmb.DataContext = tab;
                 //tcGeneral.SelectedIndex = 0;

             }
         }

        private void btnReporteVenta_Click(object sender, RoutedEventArgs e)
        {
            DateTime inicio = DateTime.Parse(rVentasFechaIni.Text);
             DateTime final = DateTime.Parse(rVentasFechaFin.Text);
            string tienda = cbTienda.Text;
            rvVentasConta.Reset();
            DataTable dt = GetData(inicio.ToString("yyyyMMdd"), final.ToString("yyyyMMdd"), tienda, con);
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            rvVentasConta.LocalReport.DataSources.Add(ds);
            rvVentasConta.LocalReport.ReportPath = "Report1.rdlc";
            //rvVentasConta.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            rvVentasConta.RefreshReport();
        }

        private DataTable GetData(string ini, string fin, string tienda, string conex1 )
        {
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(conex1))
                {
                    SqlCommand cmd = new SqlCommand("OWN_RPT_VENTAS_CONTABILIDAD", cn);
                    cmd.Parameters.Add("@FECHA_INI", SqlDbType.VarChar).Value= ini;
                    cmd.Parameters.Add("@FECHA_FIN", SqlDbType.VarChar).Value = fin;
                    cmd.Parameters.Add("@TIENDA", SqlDbType.VarChar).Value = tienda;
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                }
                
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }
            return dt;
        }

        private void cbReporteFpTienda_Initialized(object sender, EventArgs e)
        {
            
        }

        private DataTable GetDataFp(string ini, string fin,string formaPago, string tienda, string conex1)
        {
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(conex1))
                {
                    SqlCommand cmd = new SqlCommand("OWN_RPT_VENTAS_FORMAS_PAGO", cn);
                    cmd.Parameters.Add("@FECHA_INI", SqlDbType.VarChar).Value = ini;
                    cmd.Parameters.Add("@FECHA_FIN", SqlDbType.VarChar).Value = fin;

                    cmd.Parameters.Add("@TIENDA", SqlDbType.VarChar).Value = tienda;
                    cmd.Parameters.Add("@FORMAPAGO", SqlDbType.VarChar).Value = formaPago;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                }

            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }
            return dt;
        }

        private void btnReporteFormaPago_Click(object sender, RoutedEventArgs e)
        {   
            DateTime inicio = DateTime.Parse(rFpFechaIni.Text );
            DateTime final = DateTime.Parse(rFpFechaFin.Text);
            string tienda = cbReporteTienda.Text;
            string formaPago = (string)cbReporteFpTienda.SelectedValue;
            //string exeFolder = (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Substring(0, (System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)).Length - 3);
            string reportPath = ("Report2.rdlc");
            
            //string formaPago = cbReporteFpTienda.Text;
            rvFormaPago.Reset();
            DataTable dt = GetDataFp(inicio.ToString("yyyyMMdd"), final.ToString("yyyyMMdd"), formaPago, tienda, con);
            ReportDataSource ds = new ReportDataSource("DataSet2", dt);
            rvFormaPago.LocalReport.DataSources.Add(ds);
            rvFormaPago.LocalReport.ReportPath = reportPath;
            rvFormaPago.RefreshReport();
        }
       

      
        

       

        
           
        }

       
             
            
    
        
    
}
