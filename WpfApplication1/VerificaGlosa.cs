using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.message;

namespace WpfApplication1
{
    class VerificaGlosa
    {
        public VerificaGlosa()
        {

        }

        public string Anio { get; set; }
        public string Periodo { get; set; }
        public string Libro { get; set; }
        public string Glosa { get; set; }
      //  public string anio { get; set; }

        public bool checkAll(string con)
        {
            
             MessageViewModel mv = new MessageViewModel();
            //string con = @"Server=LAYER-PC\TTEST; Database=SAFC_ECB; User Id=profit; Password = profit";
            string sql = @"SELECT top(1) Ase_cNummov , Ase_nVoucher 
                            FROM   CNC_ASIENTO_VOUCHER
                             WHERE  Emp_cCodigo = '003' 
                                    AND Pan_cAnio = '" + Anio +
                                "' AND Per_cPeriodo = '" + Periodo +
                                "' AND Lib_cTipoLibro = '" + Libro + 
                                "' AND Ase_cGlosa = '" + Glosa + "'" +
                                " ORDER BY Ase_nVoucher desc";
            
            try
            {

                Conexion cn = new Conexion(con);

                SqlDataReader reader = cn.consulta3(sql);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mv.Message = "Ya existe un Asiento \n" + "Nro. Voucher: " + reader.GetSqlValue(1).ToString() + "\n" + " Descripcion: " + Glosa;
                        mv.Caption = "Titulo";
                        mv.mensajeria();
                    }
                        return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                    mv.Caption ="Error sql";
                    mv.mensajeria();
                return true;
            }
            
        }

        
    }
   
}
