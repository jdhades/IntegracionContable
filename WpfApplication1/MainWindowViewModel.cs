using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WpfApplication1.Model;
using System.Data.SqlClient;
using WpfApplication1.message;

namespace WpfApplication1
{
    class MainWindowViewModel : INotifyPropertyChanged
	{
		public MainWindowViewModel()
		{
			VentasCollection = new ObservableCollection<mVentas>();
			
		}

		private ObservableCollection<mVentas> ventasCollection;
		public ObservableCollection<mVentas> VentasCollection
		{
			get { return ventasCollection; }
			set
			{
				ventasCollection = value;
				RaisePropertyChanged("VentasCollection");
			}
		}


		private void BindData(string con, string fechaDia, string tienda, string buscarTienda)
		{
			MessageViewModel ms = new MessageViewModel();
            string sql;
            try
            {   
                Conexion cn = new Conexion(con);
                sql = @"SELECT A.NUMFACTURA AS NUMERO,0 AS total,0 as totiva,0 as totreq, 0 as baseimponibre FROM FACTURASVENTA AS A
                        where a.FECHAENTRADA = '"+fechaDia+"' and a.NUMSERIE = '"+tienda+"' and a.TOTALNETO = 0 ";
                sql = sql +@" union 
                        SELECT numero,total,totiva,totreq,baseimponible 
                        from FACTURASVENTA b  right outer join FACTURASVENTATOT a on a.NUMERO = b.NUMFACTURA and a.SERIE = b.NUMSERIE
                        where b.FECHAENTRADA = '" + fechaDia +"' and a.SERIE = '"+tienda+"'  order by NUMERO";
                SqlDataReader reader = cn.consulta3(sql);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        //new ventas{cuenta = "70111",serie = buscarTienda, numero =(reader.GetInt32(0)).ToString(), debe = 0 , haber = Convert.ToInt32(reader.GetValue(2))};
                        
                        VentasCollection.Add(new mVentas("12121", buscarTienda, (reader.GetInt32(0)).ToString(), Convert.ToInt32(reader.GetValue(1)), 0));
                        VentasCollection.Add(new mVentas("40111", buscarTienda, (reader.GetInt32(0)).ToString(), 0 , Convert.ToInt32(reader.GetValue(2))));
                        VentasCollection.Add(new mVentas("46997", buscarTienda, (reader.GetInt32(0)).ToString(), 0 , Convert.ToInt32(reader.GetValue(2))));
                        VentasCollection.Add(new mVentas("70111", buscarTienda, (reader.GetInt32(0)).ToString(), 0 , Convert.ToInt32(reader.GetValue(2))));
                        
                    }
                }

            }
            catch (Exception e)
            {
                ms.Message = ms.ToStringAllExceptionDetails(e);
                ms.Caption = "Error sql";
                ms.mensajeria();
                
            }
            
            
           }

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName)
		{
			if (null != PropertyChanged)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}
    
        
    
}
