using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using WpfApplication1.message;
using System.Globalization;
using System.Collections.ObjectModel;
using WpfApplication1.Model;
using System.Diagnostics;


namespace WpfApplication1
{
   
    public class Integracion
    {


        //Declaracion de variables ************************************************************
        public List<MostrarLista> ListaMostrar { get; set; }
        public string Ase_cNummov { get; set; } public string Emp_cCodigo { get; set; } public string Pan_cAnio { get; set; } public string Per_cPeriodo { get; set; }
        public string Lib_cTipoLibro { get; set; } public string Ase_nVoucher { get; set; } public string Ten_cTipoEntidad { get; set; } public string Asd_cAfecto { get; set; }
        public string Ent_cCodEntidad { get; set; } public string Asd_cTipoDoc { get; set; } public string Asd_cTipoDocRef { get; set; }
        public string Asd_cSerieDocRef { get; set; } public string Asd_cNumDocRef { get; set; } public string Com_cTipoIgv { get; set; }
        public Decimal Asd_nMontoInafecto { get; set; } public string Asd_cRetencion { get; set; } public string Asd_cFlgSpot { get; set; }
        public string Asd_cDestino { get; set; } public string Asd_cProvCanc { get; set; } public string Asd_cOperaTC { get; set; }
        public string Asd_cTipoMoneda { get; set; } public string Asd_cMonedaCalculo { get; set; } public string Asd_cEstado { get; set; }
        public string Asd_cDeleted { get; set; } public string Tra_cCodigo { get; set; } public string Asd_cMonAdic { get; set; }
        public string Asd_cComprobante { get; set; } public string Asd_cProceso { get; set; } public string Asd_cRegAux { get; set; }
        public string Asd_cRegAuxDet { get; set; } public string Asd_cConvMon { get; set; } public string Asd_cManual { get; set; }
        public string Pla_cCuentaContable { get; set; } public string Asd_cGlosa { get; set; } public string Cos_cCodigo { get; set; } public string Asd_cSerieDoc { get; set; }
        public string Asd_cNumDoc { get; set; } public string Ecp_cOperacion { get; set; } public string Asd_cBaseImp { get; set; }
        public string Asd_cNumSpot { get; set; } public string Asd_cUserCrea { get; set; } public string Asd_cUserModifica { get; set; }
        public string Asd_cEquipoUser { get; set; } public string Asd_cFormaPago { get; set; } public string Asd_cGrupo { get; set; } public string Asd_cCodConcepto { get; set; }
        public string Asd_dFecDoc { get; set; } public string numeroDoc { get; set; } public string serieDoc { get; set; } public string buscarTienda { get; set; }//dateTimePicker1.Value.ToString("dd-MM-yyyy");
        public string Asd_dFechaCrea { get; set; }
        public string Ase_dFecha { get; set; }
        public string Asd_dFecDocRef { get; set; }
        public string Asd_dFecVen { get; set; }
        public string Asd_dFechaSpot { get; set; }
        public string Asd_dFechaModifica { get; set; } 
        public decimal Asd_nDebeSoles { get; set; } public decimal Asd_nHaberSoles { get; set; } public decimal Asd_nTipoCambio { get; set; }
        public decimal Asd_nDebeMonExt { get; set; } public decimal Asd_nHaberMonExt { get; set; } public decimal Imp_nPorcentaje { get; set; }
        public decimal Asd_nPorcenDist { get; set; } public decimal Asd_cImpAdic { get; set; }
        public int Asd_nItem { get; set; } public int Asd_nCorre { get; set; } public int dato { get; set; } public int listo { get; set; }
        
       
        /* VARIABLES DE CABECERA */
        public string Ase_cGlosa { get; set; } public string Ase_cEstado { get; set; } public string Ase_cOperaTC { get; set; }
        public string Ase_cUserCrea { get; set; } public string Ase_cUserModifica { get; set; } public string Ase_cDeleted { get; set; }
        public string Ase_cEquipoUser { get; set; } public string Ase_dFechaModifica { get; set; } public string Ase_cElimSoft { get; set; }
        public string Ase_cCuadreManual { get; set; } public string Ase_cCodSoft { get; set; } public string Asd_cEstadoO { get; set; } public string Asd_cEstadoD { get; set; }
        public string Ase_dFechaCrea { get; set; }
        public string Ase_cTipoMoneda { get; set; } public decimal Ase_nTipoCambio { get; set; }
        public string numMov = "";
        public string asiento = "";
        public int valNumMov = 0;
        public int valAsiento = 0;
        public string exoneracion = null;
        public string tipoRenta = null;
        public string modalidad = null;
        public string idAduana = null;
        public string claservicio = null;
        MessageViewModel mv = new MessageViewModel();
        ObservableCollection<mVentas> venta = new ObservableCollection<mVentas>();
        ObservableCollection<mVentas> ventaTotal = new ObservableCollection<mVentas>();
        ObservableCollection<mCobros> cobro = new ObservableCollection<mCobros>();
        ObservableCollection<mCobros> cobroTotal = new ObservableCollection<mCobros>();

             
        
        //fin de declaracion de variables ****************************************************


        public Integracion()
        {
            Ase_cNummov = ""; Emp_cCodigo = ""; Pan_cAnio = ""; Per_cPeriodo = "";
            Lib_cTipoLibro = ""; Ase_nVoucher = ""; Ten_cTipoEntidad = "";
            Ent_cCodEntidad = ""; Asd_cTipoDoc = ""; Asd_cTipoDocRef = "";
            Asd_cSerieDocRef = ""; Asd_cNumDocRef = ""; Com_cTipoIgv = "";
            Asd_nMontoInafecto = 0; Asd_cRetencion = ""; Asd_cFlgSpot = "";
            Asd_cDestino = ""; Asd_cProvCanc = ""; Asd_cOperaTC = "";
            Asd_cTipoMoneda = ""; Asd_cMonedaCalculo = ""; Asd_cEstado = "";
            Asd_cDeleted = ""; Tra_cCodigo = ""; Asd_cMonAdic = "";
            Asd_cComprobante = ""; Asd_cProceso = ""; Asd_cRegAux = "";
            Asd_cRegAuxDet = ""; Asd_cConvMon = ""; Asd_cManual = "";
            Pla_cCuentaContable = ""; Asd_cGlosa = ""; Cos_cCodigo = ""; Asd_cSerieDoc = "";
            Asd_cNumDoc = ""; Ecp_cOperacion = ""; Asd_cBaseImp = "";
            Asd_cNumSpot = ""; Asd_cUserCrea = ""; Asd_cUserModifica = "";
            Asd_cEquipoUser = ""; Asd_cFormaPago = ""; Asd_cGrupo = ""; Asd_cCodConcepto = "";
            Asd_dFecDoc = ""; //numeroDoc = ""; serieDoc = ""; buscarTienda = "";//dateTimePicker1.Value.ToString("dd-MM-yyyy");
            Asd_dFecVen = "01/01/1900 12:00 AM";
            Asd_dFecDocRef = "01/01/1900 12:00 AM";
            Asd_dFechaSpot = "01/01/1900 12:00 AM";
            Ase_cCuadreManual = "0"; Ase_cCodSoft = "001"; Asd_cEstadoO = "1"; Asd_cEstadoD = ""; Ase_cElimSoft = "0";
            Asd_dFechaCrea = DateTime.Now.ToString("yyyyMMdd"); Ase_dFecha = DateTime.Now.ToString("yyyyMMdd");
            Asd_dFechaModifica = DateTime.Now.ToString("yyyyMMdd");
            Ase_dFechaModifica = DateTime.Now.ToString("yyyyMMdd");
            Ase_dFechaCrea = DateTime.Now.ToString("yyyyMMdd");
            //Ase_cFechaDocRef = DateTime.Now.ToString("yyyyMMdd"); ;
            Asd_nDebeSoles = 0; Asd_nHaberSoles = 0; Asd_nTipoCambio = 0; Ase_nTipoCambio = 0;
            Asd_nDebeMonExt = 0; Asd_nHaberMonExt = 0; Imp_nPorcentaje = 0;
            Asd_nPorcenDist = 0; Asd_cImpAdic = 0;
            Asd_nItem = 0; Asd_nCorre = 0; Asd_cAfecto = "";
            
        }


        private void sincronizarCobros(string sAnio, string sPeriodo, string sLibro, string sGlosa, string sFechaSql, string sTienda,
                              string iniFinFactura, string sucursal, string conx, string mov, string vou)
        {

            bool listo = false;
         //   cobroTotal.Clear();
            
            try
            {
                this.Ase_cNummov = mov;
                this.Ase_nVoucher = vou;
                this.Pan_cAnio = sAnio;
                this.Per_cPeriodo = sPeriodo;
                this.Lib_cTipoLibro = sLibro;
                this.Emp_cCodigo = "003";
                this.Asd_cTipoDoc = "12";
                this.Asd_dFecDoc = sFechaSql;
                if (sTienda == "001T")
                    this.Asd_cSerieDoc = "T001";
                else if (sTienda == "006T")
                    this.Asd_cSerieDoc = "T005";
                else if (sTienda == "007T")
                    this.Asd_cSerieDoc = "T007";
                else
                    this.Asd_cSerieDoc = "T008";

                //Asd_cSerieDoc = cbSucursal.SelectedItem.ToString().ToUpper() == "Surco".ToUpper() ? "T005" : "T001";

                this.Imp_nPorcentaje = 18;
                this.Asd_cOperaTC = "SCV";
                this.Asd_cTipoMoneda = "038";
                this.Asd_cEstado = "A";
                this.Asd_cUserCrea = "DPEREZ";
                this.Asd_cUserModifica = "DPEREZ";
                this.Asd_cEquipoUser = "CONTABILIDAD";

                int i = 0;
                foreach (var data in ventaTotal)
                {
                    this.Pla_cCuentaContable = data.cuenta;
                    this.Asd_nItem = i + 1;
                    this.Asd_nDebeSoles = data.debe;
                    this.Asd_nHaberSoles = data.haber;
                    this.Cos_cCodigo = data.cuenta == "70111" ? data.serie : "";
                    this.Ten_cTipoEntidad = data.cuenta == "12121" ? "C" : "";
                    this.Ent_cCodEntidad = data.cuenta == "12121" ? "00001" : "";
                    this.Asd_cNumDoc = data.numero;
                    this.Asd_cBaseImp = (data.cuenta == "40111" || data.cuenta == "70111") ? "002" : "";
                    string query2 = @"spCn_GrabaAsientoDet 'INSERTAR','" + this.Ase_cNummov + "','" + this.Emp_cCodigo + "','" + this.Pan_cAnio + "','" + this.Per_cPeriodo + "','" +
                                           this.Lib_cTipoLibro + "','" + this.Ase_nVoucher + "'," + this.Asd_nItem + ",'" + this.Pla_cCuentaContable + "','" + sGlosa + "'," +
                                           this.Asd_nDebeSoles + "," + this.Asd_nDebeMonExt + "," + this.Asd_nHaberSoles + "," + this.Asd_nHaberMonExt + "," + this.Asd_nTipoCambio + ",'" +
                                           this.Cos_cCodigo + "','" + this.Ten_cTipoEntidad + "','" + this.Ent_cCodEntidad + "','" + this.Asd_cTipoDoc + "','" + this.Asd_cSerieDoc + "','" +
                                           this.Asd_cNumDoc + "','" + this.Asd_dFecDoc + "','" + this.Asd_cTipoDocRef + "','" + this.Asd_cSerieDocRef + "','" + this.Asd_cNumDocRef + "'," +
                                           "NULL" + "," + this.Asd_nMontoInafecto + ",'" + this.Asd_cRetencion + "','" + this.Asd_cFlgSpot + "'," + "NULL" + ",'" +
                                           this.Asd_cNumSpot + "','" + this.Asd_cDestino + "'," + this.Asd_nCorre + ",'" + this.Asd_cUserCrea + "','" + this.Asd_cEstado + "','" +
                                           this.Asd_cProvCanc + "','" + this.Asd_cOperaTC + "','" + this.Asd_cTipoMoneda + "'," + "default" + "," + this.Imp_nPorcentaje + ",'" +
                                           this.Asd_cAfecto + "'," + "NULL" + "," + "default" + "," + "default" + ",'" + this.Asd_cBaseImp + "','" +
                                           this.Asd_cMonAdic + "'," + this.Asd_cImpAdic + ",'" + this.Asd_cComprobante + "','" + this.Asd_cProceso + "','" + this.Ecp_cOperacion + "','" +
                                           this.Asd_cRegAux + "','" + this.Asd_cConvMon + "','" + this.Asd_cManual + "','" + this.Asd_cRegAuxDet + "','" + this.Asd_cGrupo + "','" +
                                           this.Asd_cCodConcepto + "'," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL";



                    // +"','" +
                    Conexion cn = new Conexion(conx);
                    listo = cn.insertar(query2);
                    i++;
                }

            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }

        }

        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectAdmin"></param>

        private void sincronizar(string sAnio,string sPeriodo, string sLibro,string sGlosa, string sFechaSql, string sTienda, 
                                 decimal cxc, decimal igv, decimal rc, decimal bi, string iniFinFactura,string sucursal,string conx, string mov, string vou )
        {
            
            bool listo = false;
            ventaTotal.Clear();

          
            try
            {
                this.Ase_cNummov = mov;
                this.Ase_nVoucher = vou;
                this.Pan_cAnio = sAnio;
                this.Per_cPeriodo = sPeriodo;
                this.Lib_cTipoLibro = sLibro;
                this.Emp_cCodigo = "003";
                this.Asd_cTipoDoc = "12";
                this.Asd_dFecDoc = sFechaSql;
                if (sTienda == "001T")
                    this.Asd_cSerieDoc = "T001";
                else if (sTienda == "006T")
                    this.Asd_cSerieDoc = "T005";
                else if (sTienda == "007T")
                    this.Asd_cSerieDoc = "T007";
                else
                    this.Asd_cSerieDoc = "T008";

                //Asd_cSerieDoc = cbSucursal.SelectedItem.ToString().ToUpper() == "Surco".ToUpper() ? "T005" : "T001";
                
                this.Imp_nPorcentaje = 18;
                this.Asd_cOperaTC = "SCV";
                this.Asd_cTipoMoneda = "038";
                this.Asd_cEstado = "A";
                this.Asd_cUserCrea = "DPEREZ";
                this.Asd_cUserModifica = "DPEREZ";
                this.Asd_cEquipoUser = "CONTABILIDAD";

                ventaTotal.Add(new mVentas("12121", sucursal, iniFinFactura, cxc, 0));
                ventaTotal.Add(new mVentas("40111", sucursal, iniFinFactura, 0, igv));
                ventaTotal.Add(new mVentas("46997", sucursal, iniFinFactura, 0, rc));
                ventaTotal.Add(new mVentas("70111", sucursal, iniFinFactura, 0, bi));
                int i = 0;
                foreach (var data in ventaTotal)
                {
                    this.Pla_cCuentaContable = data.cuenta;
                    this.Asd_nItem = i + 1;
                    this.Asd_nDebeSoles = data.debe;
                    this.Asd_nHaberSoles = data.haber;
                    this.Cos_cCodigo = data.cuenta == "70111" ? data.serie : "";
                    this.Ten_cTipoEntidad = data.cuenta == "12121" ? "C" : "";
                    this.Ent_cCodEntidad = data.cuenta == "12121" ? "00001" : "";
                    this.Asd_cNumDoc = data.numero;
                    this.Asd_cBaseImp = (data.cuenta == "40111" || data.cuenta == "70111") ? "002" : "";
                    string query2 = @"spCn_GrabaAsientoDet 'INSERTAR','" + this.Ase_cNummov + "','" + this.Emp_cCodigo + "','" + this.Pan_cAnio + "','" + this.Per_cPeriodo + "','" + 
                                           this.Lib_cTipoLibro + "','" + this.Ase_nVoucher + "'," + this.Asd_nItem + ",'" + this.Pla_cCuentaContable + "','" + sGlosa + "'," +
                                           this.Asd_nDebeSoles + "," + this.Asd_nDebeMonExt + "," + this.Asd_nHaberSoles + "," + this.Asd_nHaberMonExt + "," + this.Asd_nTipoCambio + ",'" +
                                           this.Cos_cCodigo + "','" + this.Ten_cTipoEntidad + "','" + this.Ent_cCodEntidad + "','" + this.Asd_cTipoDoc + "','" + this.Asd_cSerieDoc + "','" +
                                           this.Asd_cNumDoc + "','" + this.Asd_dFecDoc + "','" + this.Asd_cTipoDocRef + "','" + this.Asd_cSerieDocRef +"','" + this.Asd_cNumDocRef + "'," +
                                           "NULL" + "," + this.Asd_nMontoInafecto + ",'" + this.Asd_cRetencion + "','" + this.Asd_cFlgSpot + "'," + "NULL" + ",'" +
                                           this.Asd_cNumSpot + "','" + this.Asd_cDestino + "'," + this.Asd_nCorre + ",'" + this.Asd_cUserCrea + "','" + this.Asd_cEstado + "','" +
                                           this.Asd_cProvCanc + "','" + this.Asd_cOperaTC + "','" + this.Asd_cTipoMoneda + "'," + "default" + "," + this.Imp_nPorcentaje + ",'" +
                                           this.Asd_cAfecto + "'," + "NULL" + "," + "default" + "," + "default" + ",'" + this.Asd_cBaseImp+ "','" +
                                           this.Asd_cMonAdic + "'," + this.Asd_cImpAdic + ",'" + this.Asd_cComprobante + "','" + this.Asd_cProceso + "','" + this.Ecp_cOperacion + "','" +
                                           this.Asd_cRegAux + "','" + this.Asd_cConvMon + "','" + this.Asd_cManual + "','" + this.Asd_cRegAuxDet + "','" + this.Asd_cGrupo + "','" +
                                           this.Asd_cCodConcepto + "'," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL";
                    
                   
            
                    // +"','" +
                    Conexion cn = new Conexion(conx);
                    listo = cn.insertar(query2);
                    i++;
                }
                
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();
                
            }
          
        }




        /// <summary>
        /// void cabecera
        /// </summary>
        /// <param name="numnov"></param>
        /// <param name="dato"></param>
        /// <param name="descrip"></param>
        /// <param name="anio"></param>
        /// <param name="periodo"></param>
        /// <param name="libro"></param>
        /// <param name="voucher"></param>
        /// <param name="conn"></param>


        public void crearCabecera(string anio, string periodo, string libro, string glosa,string conn,string fechaReal, ref string movimiento, ref string voucher )
        {

            int i = 0;
            bool listo = false;
            Ase_cTipoMoneda = "038";
            Ase_cEstado = "A";
            Ase_cUserCrea = "DPEREZ";
            Ase_cUserModifica = "DPEREZ";
            Ase_cEquipoUser = "CONTABILIDAD";
            Emp_cCodigo = "003";
            Pan_cAnio = anio;
            Per_cPeriodo = periodo;
            Lib_cTipoLibro = libro;
            Ase_cOperaTC = "";
            Ase_cGlosa = glosa;
            string query2;

            string  queryI;
            string sql = @"SELECT top(1) Ase_cNummov , Ase_nVoucher 
                            FROM   CNC_ASIENTO_VOUCHER
                             WHERE  Emp_cCodigo = '003' 
                                    AND Pan_cAnio = '" + anio +
                                "' AND Per_cPeriodo = '" + periodo +
                                "' AND Lib_cTipoLibro = '" + libro + "'" +
                                " ORDER BY Ase_nVoucher desc";
            
            string sql2 = @"SELECT top(1) Ase_cNummov 
                            FROM   CNC_ASIENTO_VOUCHER
                             WHERE  Emp_cCodigo = '003' 
                             ORDER BY Ase_cNummov desc";
        

            try
            {
                // toda esta parte es para generar el nro de movimiento y el asiento
                Conexion cn = new Conexion(conn);

                SqlDataReader reader = cn.consulta3(sql);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        numMov = reader.GetString(0);
                        asiento = reader.GetString(1);
                        i++;
                    }
                    cn.Cerrar();
                    if (i == 1)
                    {
                        valNumMov = Int32.Parse(numMov) + 1;
                        valAsiento = Int32.Parse(asiento) + 1;
                        Ase_nVoucher = valAsiento.ToString().PadLeft(10, '0');
                        Ase_cNummov = valNumMov.ToString().PadLeft(10, '0');
                        movimiento = Ase_cNummov;
                        voucher = Ase_nVoucher;
                        query2 = @"spCn_GrabaAsientoCab 'INSERTAR','" + Ase_cNummov + "','" +
                                           Emp_cCodigo + "','" + Pan_cAnio + "','" + Per_cPeriodo + "','" + Lib_cTipoLibro + "','" +
                                           Ase_nVoucher + "','" + fechaReal + "','" + Ase_cOperaTC + "','" + Ase_cTipoMoneda + "'," +
                                           Ase_nTipoCambio + ",'" + Ase_cGlosa + "','" +  " " + "','" + Ase_cUserCrea + "','" +
                                           Ase_cEstado + "','" + "0" + "','" + "001" + "'," + "default" + ",'" + "1" + "','" +
                                           "" + "'," + "NULL" + "," + "NULL" + "," + "NULL" + ",'" + "0" + "','" + "0" + "'"; 
                                                              
                        listo = cn.insertar(query2);
                        cn.Cerrar();
                    }

                }
                else
                {
                    //cn.cerrar();
                    //Conexion cn = new Conexion(conn);
                    cn.Cerrar();
                    SqlDataReader reader2 = cn.consulta3(sql2);
                    if (reader2.HasRows)
                    {

                        while (reader2.Read())
                        {
                            numMov = reader2.GetString(0);
                            i++;
                        }
                        cn.Cerrar();    
                        if (i == 1)
                        {
                            valNumMov = Int32.Parse(numMov) + 1;
                            //valAsiento = Int32.Parse(asiento) + 1;
                            Ase_nVoucher = libro + periodo+"000001";//valAsiento.ToString().PadLeft(10, '0');
                            Ase_cNummov = valNumMov.ToString().PadLeft(10, '0');
                            movimiento = Ase_cNummov;
                            voucher = Ase_nVoucher;

                            query2 = @"spCn_GrabaAsientoCab 'INSERTAR','" + Ase_cNummov + "','" +
                                               Emp_cCodigo + "','" + Pan_cAnio + "','" + Per_cPeriodo + "','" + Lib_cTipoLibro + "','" +
                                               Ase_nVoucher + "','" + fechaReal + "','" + Ase_cOperaTC + "','" + Ase_cTipoMoneda + "'," +
                                               Ase_nTipoCambio + ",'" + Ase_cGlosa + "','" + " " + "','" + Ase_cUserCrea + "','" +
                                               Ase_cEstado + "','" + "0" + "','" + "001" + "'," + "default" + ",'" + "1" + "','" +
                                               "" + "'," + "NULL" + "," + "NULL" + "," + "NULL" + ",'" + "0" + "','" + "0" + "'"; 
                                          
                            listo = cn.insertar(query2);
                            cn.Cerrar();
                        }

                    }
                }
           }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();
                 
            }

        }



/// <summary>
/// Verificar Cobros: inicia el proceso de cobros
/// </summary>
/// <param name="fechaSql"></param>
/// <param name="conex1"></param>
/// <param name="conex2"></param>
        public void verficarCobros(string fechaSql, string conex1, string conex2)
        {

            decimal sumFactura = 0;
            decimal sumFacturaDol = 0;
            decimal sumEfectivo = 0;
            decimal sumVisa = 0;
            decimal sumMaster = 0;
            decimal sumAmerican = 0;
            decimal sumDiner = 0;
            decimal sumConsumo = 0;
            decimal sumDolares = 0;
            string[] tienda = new string[] { "001T", "006T", "007T", "008T" };
            string t = "";
            string sql = "";
            string sucursal = "";
            string facturas = "";
            string movi = "";
            string vouc = "";
           
            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes

            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

            for (int i = 1; i < 5; i++)
            {
                cobro.Clear();
                t = i == 1 ? "01" : i == 2 ? "02" : i == 3 ? "05" : "05";
                movi = "";
                vouc = "";
           
                try
                {
                    //consulta que saca la informacion de ventas
                    Conexion cn = new Conexion(conex1);
                    sql = @"SELECT a.numero,CASE  WHEN d.total IS NULL THEN 0 ELSE d.total END AS total,a.IMPORTE,a.CODFORMAPAGO,c.DESCRIPCION
                                    FROM VW_TESORERIA a inner join TIPOSPAGO b on a.CODTIPOPAGO = b.CODTIPOPAGO
                                    inner join FORMASPAGO c on a.CODFORMAPAGO = c.CODFORMAPAGO
                                    left join FACTURASVENTATOT d on a.NUMERO = d.NUMERO and a.serie = d.SERIE
                                    WHERE  a.serie = '" + tienda[i - 1] + "' and FECHADOCUMENTO = '" + fechaSql + "' order by numero";

                    SqlDataReader reader = cn.consulta3(sql);
                    //se le asigna a cada cuenta contable el valor correpondiente de la venta, para despues realizar una agrupacion y sacar la diferencia
                    if (reader.HasRows)
                    {
                        Int32 num = 0;
                        int x = 0;
                        while (reader.Read())
                        {
                            if (num != reader.GetInt32(0))
                            {
                                cobro.Add(new mCobros("12021", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(1)), "FACTURA"));

                                 x = Convert.ToInt32(reader.GetValue(3));
                                switch (i)
                                {
                                    case 1://efectivo
                                        cobro.Add(new mCobros("10111", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "EFECTIVO"));
                                        break;
                                    case 2://visa
                                        cobro.Add(new mCobros("16292", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "VISA"));
                                        break;
                                    case 3://master
                                        cobro.Add(new mCobros("16291", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "MASTER"));
                                        break;
                                    case 5://american
                                        cobro.Add(new mCobros("16293", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "AMERICAN"));
                                        break;
                                    case 6://dollares
                                        cobro.Add(new mCobros("10112", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "DOLLARES"));
                                        break;
                                    case 8://diner
                                        cobro.Add(new mCobros("16294", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "DINER"));
                                        break;
                                    case 10://consumo
                                        cobro.Add(new mCobros("16981", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "CONSUMO"));
                                        break;

                                }

                            }
                            else
                            {
                                x = Convert.ToInt32(reader.GetValue(3));
                                switch (i)
                                {
                                    case 1://efectivo
                                        cobro.Add(new mCobros("10111", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "EFECTIVO"));
                                        break;
                                    case 2://visa
                                        cobro.Add(new mCobros("16292", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "VISA"));
                                        break;
                                    case 3://master
                                        cobro.Add(new mCobros("16291", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "MASTER"));
                                        break;
                                    case 5://american
                                        cobro.Add(new mCobros("16293", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "AMERICAN"));
                                        break;
                                    case 6://dollares
                                        cobro.Add(new mCobros("10112", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "DOLLARES"));
                                        break;
                                    case 8://diner
                                        cobro.Add(new mCobros("16294", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "DINER"));
                                        break;
                                    case 10://consumo
                                        cobro.Add(new mCobros("16981", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(2)), 0, "CONSUMO"));
                                        break;

                                }
                            }

                            num = reader.GetInt32(0);
                           

                        }
                    
         
                         sumFactura = Math.Round(cobro.Sum(z => z.haber ),2);
                         sumEfectivo = Math.Round(cobro.Sum(z => z.cuenta == "10111" ? z.debe : 0), 2);
                         sumVisa = Math.Round(cobro.Sum(z => z.cuenta == "16292" ? z.debe : 0), 2);
                         sumMaster = Math.Round(cobro.Sum(z => z.cuenta == "16291" ? z.debe : 0), 2);
                         sumAmerican = Math.Round(cobro.Sum(z => z.cuenta == "16293" ? z.debe : 0), 2);
                         sumDiner = Math.Round(cobro.Sum(z => z.cuenta == "16294" ? z.debe : 0), 2);
                         sumConsumo = Math.Round(cobro.Sum(z => z.cuenta == "16981" ? z.debe : 0), 2);
                         sumFacturaDol = Math.Round(cobro.Sum(z => z.cuenta == "10112" ? z.haber : 0), 2);
                         sumDolares = Math.Round(cobro.Sum(z => z.cuenta == "10112" ? z.debe : 0), 2);

                                                
          
                        //Asignacion de resultados para crear el asiento cabecera
                        sucursal = tienda[i - 1] == "001T" ? "MIRAFLORES" : tienda[i - 1] == "006T" ? "SURCO" : "SAN ISIDRO";
                        vg.Anio = fecha.Year.ToString();
                        vg.Periodo = fecha.ToString("MM");
                        vg.Libro = "05";
                        facturas = venta.First().numero + "-" + venta.Last().numero;
                        vg.Glosa = "CONSUMO: " + sucursal + " " + facturas + " Fecha: " + fecha.ToString("dd-MM-yyyy");
                    /////////////////////////////////////////
                        cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFactura, "Facturas"));

                        if (sumEfectivo != 0)
                            cobroTotal.Add(new mCobros("10111", sucursal, facturas, sumEfectivo, 0, "Efecivo"));
                        if (sumMaster != 0)
                            cobroTotal.Add(new mCobros("16291", sucursal, facturas, sumMaster, 0, "Master"));
                        if (sumVisa != 0)
                            cobroTotal.Add(new mCobros("16292", sucursal, facturas, sumVisa, 0, "Visa"));
                        if (sumAmerican != 0)
                            cobroTotal.Add(new mCobros("16293", sucursal, facturas, sumAmerican, 0, "American"));
                        if (sumDiner != 0)
                            cobroTotal.Add(new mCobros("16294", sucursal, facturas, sumDiner, 0, "Diner"));
                        if (sumConsumo != 0)
                            cobroTotal.Add(new mCobros("16981", sucursal, facturas, sumConsumo, 0, "Consumo"));

                       // cobroTotal.Add(new mCobros("12121", sucursal, factuas, facturas, 0));
          
                        // si hay diferencia entre la cuenta x cobrar y el total neto de la venta
                        // llenamos el combo box con la fecha y la tienda que tiene los problemas, para que este muestre en el grid el detalle
                    
                             //verifica si el asiento existe
                             if (vg.checkAll(conex2))
                             {
                                 mv.Message = "El Asiento ya Existe, por favor Verifique";
                                 mv.Caption = "Error Asiento existente";
                                 mv.mensajeria();
                             }
                             else // en caso de qeu no exista crea la cabecera y crea el asiento
                             {
                                 crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc);

                                 sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, tienda[i - 1],  facturas, t, conex2, movi, vouc);
                                 cobroTotal.Clear();
                             }
                         

                    }

                }
                catch (Exception e)
                {
                    mv.Message = mv.ToStringAllExceptionDetails(e);
                    mv.Caption = "Error sql";
                    mv.mensajeria();

                }

            }
        }
    
    ///// verificacion
        // crea la matriz del asiento detallado, de esta forma se verifica si hay alguna diferencia antes de crear el asiento
        public void verficarVentas(string fechaSql,string conex1,string conex2)
        {
           
            decimal cxc = 0; //cuenta x cobrar
            decimal igv = 0; //igv
            decimal rc = 0; // recargo al consumo
            decimal bi = 0; //base imponible
            decimal totalNeto = 0; // total neto
            string[] tienda = new string[] { "001T", "006T", "007T", "008T" };
            string t = "";
            string sql = "";
            string sucursal = "";
            string facturas = "";
            string movi = "";
            string vouc = "";
            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
           
            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
           
            for (int i = 1; i < 5; i++)
            {
                venta.Clear();
                t = i == 1 ? "01" : i == 2 ? "02" : i == 3 ? "05" : "05";
                movi = "";
                vouc = "";
                try
                {
                    //consulta que saca la informacion de ventas
                    Conexion cn = new Conexion(conex1);
                    sql = @"SELECT A.NUMFACTURA AS NUMERO,0 AS total,0 as totiva,0 as totreq, 0 as baseimponibre FROM FACTURASVENTA AS A
                        where a.FECHAENTRADA = '" + fechaSql + "' and a.NUMSERIE = '" + tienda[i - 1] + "' and a.TOTALNETO = 0 ";
                    sql = sql + @" union 
                        SELECT numero,total,totiva,totreq,baseimponible 
                        from FACTURASVENTA b  right outer join FACTURASVENTATOT a on a.NUMERO = b.NUMFACTURA and a.SERIE = b.NUMSERIE
                        where b.FECHAENTRADA = '" + fechaSql + "' and a.SERIE = '" + tienda[i - 1] + "'  order by NUMERO";
                    SqlDataReader reader = cn.consulta3(sql);
                    //se le asigna a cada cuenta contable el valor correpondiente de la venta, para despues realizar una agrupacion y sacar la diferencia
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            venta.Add(new mVentas("12121", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(1)), 0));
                            venta.Add(new mVentas("40111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(2))));
                            venta.Add(new mVentas("40997", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(3))));
                            venta.Add(new mVentas("70111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(4))));

                        }
                        cxc = Math.Round(venta.Sum(x => x.cuenta == "12121" ? x.debe : 0), 2);
                        igv = Math.Round(venta.Sum(x => x.cuenta == "40111" ? x.haber : 0), 2);
                        rc = Math.Round(venta.Sum(x => x.cuenta == "40997" ? x.haber : 0), 2);
                        bi =  Math.Round(venta.Sum(x => x.cuenta == "70111" ? x.haber : 0), 2);


                                                //Asignacion de resultados para crear el asiento cabecera
                        totalNeto = igv + rc + bi;
                        sucursal = tienda[i - 1] == "001T" ? "MIRAFLORES" : tienda[i - 1] == "006T" ? "SURCO" : "SAN ISIDRO"; 
                        vg.Anio = fecha.Year.ToString();
                        vg.Periodo = fecha.ToString("MM");
                        vg.Libro = "05";
                        facturas = venta.First().numero + "-" + venta.Last().numero;
                        vg.Glosa = "CONSUMO: " + sucursal+ " " + facturas + " Fecha: " + fecha.ToString("dd-MM-yyyy");
                       
                        // si hay diferencia entre la cuenta x cobrar y el total neto de la venta
                        // llenamos el combo box con la fecha y la tienda que tiene los problemas, para que este muestre en el grid el detalle
                        if (cxc != Math.Round(totalNeto, 2))
                        {
                            MostrarLista unMostrar = new MostrarLista();
                            unMostrar.Fecha = fecha.ToString("dd-MM-yyyy");
                            unMostrar.Tienda = tienda[i - 1];
                            ListaMostrar.Add(unMostrar);
                            // mv.Message = "Hay un error en la siguiente fecha " + p;
                            // mv.Caption = "Titulo";
                            // mv.mensajeria();
                        }
                        
                        // no hay error en el asiento es decir no hay diferencia en la cxc y el total neto
                        // entonces verificamos si ya este asiento existe

                        else
                        {
                            //verifica si el asiento existe
                            if (vg.checkAll(conex2))
                            {
                                mv.Message = "El Asiento ya Existe, por favor Verifique";
                                mv.Caption = "Error Asiento existente";
                                mv.mensajeria();
                            }
                            else // en caso de qeu no exista crea la cabecera y crea el asiento

                            {
                                crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2,fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc);

                                sincronizar(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, tienda[i - 1],cxc,igv,rc,bi,facturas,t,conex2,movi,vouc);
                            }
                        }

                    }

                }
                catch (Exception e)
                {
                    mv.Message = mv.ToStringAllExceptionDetails(e);
                    mv.Caption = "Error sql";
                    mv.mensajeria();

                }

            }
        }
    
    
    }


}
