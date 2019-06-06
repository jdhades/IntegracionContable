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
       
        /* */
           
      
        /*COLECCIONES*/
        MessageViewModel mv = new MessageViewModel();
        ObservableCollection<mVentas> venta = new ObservableCollection<mVentas>();
        ObservableCollection<mVentas> ventaTotal = new ObservableCollection<mVentas>();
        ObservableCollection<mCobros> cobro = new ObservableCollection<mCobros>();
        ObservableCollection<mCobros> cobroTotal = new ObservableCollection<mCobros>();
        ObservableCollection<mCompras> compra = new ObservableCollection<mCompras>();
        ObservableCollection<mCompras> ComprasTotal = new ObservableCollection<mCompras>();
        ObservableCollection<mGastos> gastos = new ObservableCollection<mGastos>();

             
        
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


        private void sincronizarCompra(string sAnio, string sPeriodo, string sLibro, string sGlosa, string sFechaSql, string sTienda,
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
                this.Asd_cTipoDoc = "01";
                this.Asd_dFecDoc = sFechaSql;
                this.Asd_cDestino = "0";
                //Asd_cSerieDoc = cbSucursal.SelectedItem.ToString().ToUpper() == "Surco".ToUpper() ? "T005" : "T001";

                this.Imp_nPorcentaje = 18;


                this.Asd_cEstado = "A";
                this.Asd_cUserCrea = "DPEREZ";
                this.Asd_cUserModifica = "DPEREZ";
                this.Asd_cEquipoUser = "CONTABILIDAD";

                int i = 0;
                foreach (var data in ComprasTotal)
                {
                    this.Pla_cCuentaContable = data.cuenta;
                    this.Asd_cOperaTC =  "SCV";
                    this.Asd_cTipoMoneda =  "038";
                    this.Asd_nItem = i + 1;
                    this.Asd_nDebeSoles =  data.debe;
                    this.Asd_nHaberSoles = data.haber;
                    this.Asd_nDebeMonExt = 0;
                    this.Asd_cSerieDoc = data.serie_doc;

                    switch (data.cCosto)
                    {
                        case "004C": this.Cos_cCodigo = (data.cuenta == "40111" || data.cuenta == "42120") ? "" : "01"; break;
                        case "006C": this.Cos_cCodigo = (data.cuenta == "40111" || data.cuenta == "42120") ? "" : "02"; break;
                        case "007C": this.Cos_cCodigo = (data.cuenta == "40111" || data.cuenta == "42120") ? "" : "05"; break;
                        case "4C":   this.Cos_cCodigo = (data.cuenta == "40111" || data.cuenta == "42120") ? "" : "04"; break;
                        case "A":    this.Cos_cCodigo = (data.cuenta == "40111" || data.cuenta == "42120") ? "" : "01"; break;
                        default: break;


                    } 
                     
                    this.Ten_cTipoEntidad = data.cuenta == "42120" ? "P" : "";
                    this.Ent_cCodEntidad = data.cuenta == "42120" ? data.entidad : "";
                    this.Ecp_cOperacion =  "";
                    this.Asd_cProvCanc =  "";
                    this.Asd_cNumDoc = data.numero;
                    this.Asd_cBaseImp = (data.cuenta != "42120" ) ? "006" : "";
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


        private void sincronizarCobro(string sAnio, string sPeriodo, string sLibro, string sGlosa, string sFechaSql, string sTienda,
                              string iniFinFactura, string sucursal, string conx, string mov, string vou, ref int i, string contClient, string contRuc, string direccion)
        {

            bool listo = false;
            string cadena = sTienda.Substring(0, 2);
           string cadena2 =sFechaSql.Replace("-","");
           string corte = cadena2.Substring(6,2)+cadena2.Substring(4, 2);
           
            

         //   cobroTotal.Clear();
            
            try
            {
                this.Ase_cNummov = mov;
                this.Ase_nVoucher = vou;
                this.Pan_cAnio = sAnio;
                this.Per_cPeriodo = sPeriodo;
                this.Lib_cTipoLibro = sLibro;
                this.Emp_cCodigo = "003";
                
                this.Asd_cTipoDoc = cadena == "B0" ? "03" : (cadena == "BC" || cadena == "FC") ? "07" : cadena == "F0" ? "01" : "12";
                this.Asd_dFecDoc = sFechaSql;
                if (sTienda == "001T")
                    this.Asd_cSerieDoc = "T001";
                else if (sTienda == "006T")
                    this.Asd_cSerieDoc = "T005";
                else if (sTienda == "007T")
                    this.Asd_cSerieDoc = "T007";
                else if (sTienda == "008T")
                    this.Asd_cSerieDoc = "T008";
                else
                    this.Asd_cSerieDoc = sTienda;

                //Asd_cSerieDoc = cbSucursal.SelectedItem.ToString().ToUpper() == "Surco".ToUpper() ? "T005" : "T001";

                this.Imp_nPorcentaje = 18;
                
                
                this.Asd_cEstado = "A";
                this.Asd_cUserCrea = "DPEREZ";
                this.Asd_cUserModifica = "DPEREZ";
                this.Asd_cEquipoUser = "CONTABILIDAD";
                
                
                foreach (var data in cobroTotal)
                {
                    if (data.cuenta != "12121" && data.cuenta != "10111" && data.cuenta != "10112" && data.cuenta != "12131" )
                    {
                        
                        this.Asd_cTipoDoc = "24";
                        this.Asd_cSerieDoc = corte;
                    }

                    if (data.cuenta == "10111")
                    {

                        this.Asd_cTipoDoc = "21";
                        this.Asd_cSerieDoc = corte;
                        
                    }

                    if (data.cuenta == "10112")
                    {

                        this.Asd_cTipoDoc = "21";
                        this.Asd_cSerieDoc = corte;
                    }
                    this.Pla_cCuentaContable = data.cuenta;
                    this.Asd_cOperaTC = data.cuenta == "10112" ? "OTR" : "SCV";
                    this.Asd_cTipoMoneda = data.cuenta == "10112" ? "040" : "038";
                    this.Asd_nItem = i + 1;
                    
                   // this.Asd_nDebeSoles = data.cuenta == "10112" ? 0 :data.debe;
                    this.Asd_nHaberSoles = (cadena == "BC" || cadena == "FC") && data.cuenta == "12121" ? data.debe * -1 : data.haber;
                    this.Asd_nDebeMonExt = data.cuenta == "10112" ? data.debe:0;
                    this.Asd_nDebeSoles = (cadena == "BC" || cadena == "FC") && data.cuenta == "12121" ? data.haber * -1 : data.cuenta == "10112" ? 0 : data.debe;
                    //this.Asd_nHaberSoles = cadena == "BC" || cadena == "FC" ? data.debe * -1 : data.haber;
                    if (data.cuenta == "12131")
                    {
                        this.Asd_nHaberSoles = data.debe;
                        //this.Asd_nDebeMonExt = data.cuenta == "10112" ? data.debe : 0;
                        this.Asd_nDebeSoles =  data.haber;
                    }
                    
                    //
                    this.Cos_cCodigo = data.cuenta == "70111" ? data.serie : "";
                    this.Ten_cTipoEntidad = (data.cuenta == "12121" || data.cuenta == "12131") ? "C" : data.cuenta == "16981" ? "T" : "";
                    this.Ent_cCodEntidad = (data.cuenta == "12121" || data.cuenta == "12131") ? codigoDeEntidad(contClient, contRuc, direccion, conx) : data.cuenta == "16981" ? "00046" : "";
                    this.Ecp_cOperacion = (data.cuenta == "12121" || data.cuenta == "12131") ? "D" : "";
                    this.Asd_cProvCanc = (data.cuenta == "12121" || data.cuenta == "12131") ? "C" : "";
                    this.Asd_cNumDoc = data.cuenta == "10111" ? cadena2.ToString()
                                     : data.cuenta == "10112" ? cadena2.ToString()
                                     : data.cuenta == "16291" ? cadena2.ToString()
                                     : data.cuenta == "16292" ? cadena2.ToString()
                                     : data.cuenta == "16293" ? cadena2.ToString()
                                     : data.cuenta == "16299" ? cadena2.ToString()
                                     : data.cuenta == "16296" ? cadena2.ToString()
                                     : data.cuenta == "16297" ? cadena2.ToString()
                                     : data.cuenta == "16298" ? cadena2.ToString()
                                     : data.cuenta == "16290" ? cadena2.ToString()
                                     : data.cuenta == "16300" ? cadena2.ToString()
                                     : data.cuenta == "16294" ? cadena2.ToString() : data.numero;
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



        private string codigoDeEntidad(string client, string ruc, string direccion, string cn)
        {

            string sql = "";
            bool listo = false;
            string sEmp_cCodigo = "003";
            string sEnt_cCodEntidad = "";
            string sTen_cTipoEntidad = "C";
            string sEnt_cPersona = client;
            string sEnt_cDireccion =direccion;
            string sEnt_nRuc = ruc;
            string sEnt_cRepresentante = "";
            string sEnt_cTipoDoc = "04";
            string sEnt_cFlagPersona = "N";
                    
            string sEnt_cEstadoEntidad = "1";
            string sEnt_cEstado = "A";
            string sEnt_cUserCrea = "SQUISPE";
            string sEnt_cApaterno = ""; /*************NUEVOS REGISTROS 02/07/2013 - PAUL CUEVA */
            string sEnt_cAmaterno = "";
            string sEnt_cNombres = "";
            string sEnt_cFlagDomiciliado = "1";
            string sEnt_cAconvenio = "";
            string sPer_cPeriodo = "";
            string sId_Pais = "9001";
            string sId_Vinculo_Economico = "00";   /* FIN DE REGISTROS */
            string sId_Convenio = "00";
            string sPorcentajeSunat = "0";
            string dataCuenta = "";

            sql = @"SELECT Ent_cCodEntidad FROM CNM_ENTIDAD where Ten_cTipoEntidad= 'C' and Ent_nRuc = ltrim(rtrim('" + ruc + "'))";
            Conexion consult = new Conexion(cn);
            SqlDataReader reader = consult.consulta3(sql);
            if (ruc != "")
            {
                sEnt_cFlagPersona = ruc.Substring(0, 1) == "2" ? "J" : "N";
                if (reader.HasRows)
                {
                    reader.Read();
                    dataCuenta = reader.GetValue(0).ToString(); ;
                    consult.Cerrar();
                    return dataCuenta;
                }
                else
                {

                    string queryCont = @"spCn_GrabaEntidad 'INSERTAR','" +
                        sEmp_cCodigo + "','" + sEnt_cCodEntidad + "','" + sTen_cTipoEntidad + "','" + sEnt_cPersona + "','" + sEnt_cDireccion + "','" + sEnt_nRuc + "','" +
                        sEnt_cRepresentante + "','" + sEnt_cTipoDoc + "','" + sEnt_cFlagPersona + "','" + sEnt_cEstadoEntidad + "','" + sEnt_cEstado + "','" + sEnt_cUserCrea + "','" +
                        sEnt_cApaterno + "','" + sEnt_cAmaterno + "','" + sEnt_cNombres + "','" + sEnt_cFlagDomiciliado + "','" + sEnt_cAconvenio + "','" + sPer_cPeriodo + "','" +
                        sId_Pais + "','" + sId_Vinculo_Economico + "','" + sId_Convenio + "','" + sPorcentajeSunat + "'";


                    Conexion con = new Conexion(cn);
                    listo = con.insertar(queryCont);
                    return codigoDeEntidad(client, ruc, direccion, cn);

                }

                
            }

            return "00001";
            
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectAdmin"></param>

        private void sincronizar(string sAnio,string sPeriodo, string sLibro,string sGlosa, string sFechaSql, string sTienda, 
                                 decimal cxc, decimal igv, decimal rc, decimal bi, string iniFinFactura,string sucursal,string conx, string mov, string vou, 
                                 string anulfecha, string anulserie, string anulnumero, string contClient, string contRuc, string direccion)
        {
            //consulta que saca la informacion de ventas
            

           
            bool listo = false;
            ventaTotal.Clear();
            string cadena = sTienda.Substring(0,2);

          


            try
            {
                this.Ase_cNummov = mov;
                this.Ase_nVoucher = vou;
                this.Pan_cAnio = sAnio;
                this.Per_cPeriodo = sPeriodo;
                this.Lib_cTipoLibro = sLibro;
                this.Emp_cCodigo = "003";

                this.Asd_cTipoDoc = cadena == "B0" ? "03" : (cadena == "BC" || cadena == "FC") ? "07" : cadena == "F0" ?"01":"12";
                this.Asd_dFecDoc = sFechaSql;
                if (sTienda == "001T")
                    this.Asd_cSerieDoc = "T001";
                else if (sTienda == "006T")
                    this.Asd_cSerieDoc = "T005";
                else if (sTienda == "007T")
                    this.Asd_cSerieDoc = "T007";
                else if (sTienda == "008T")
                    this.Asd_cSerieDoc = "T008";
                else
                    this.Asd_cSerieDoc = sTienda;
                //Asd_cSerieDoc = cbSucursal.SelectedItem.ToString().ToUpper() == "Surco".ToUpper() ? "T005" : "T001";
                
                this.Imp_nPorcentaje = 18;
                this.Asd_cOperaTC = "SCV";
                this.Asd_cTipoMoneda = "038";
                this.Asd_cEstado = "A";
                this.Asd_cUserCrea = "DPEREZ";
                this.Asd_cUserModifica = "DPEREZ";
                this.Asd_cEquipoUser = "CONTABILIDAD";
                this.Asd_cTipoDocRef = cadena == "BC" ? "03": cadena == "FC" ? "01" : "";
                this.Asd_cSerieDocRef = anulserie;
                this.Asd_dFecDocRef = cadena == "BC" || cadena == "FC" ? "'"+anulfecha+"'" : "NULL";
                this.Asd_cNumDocRef = cadena == "BC" || cadena == "FC" ?anulnumero.PadLeft(8, '0'):anulnumero ;
                ventaTotal.Add(new mVentas("12121", sucursal, iniFinFactura, cxc, 0));
                ventaTotal.Add(new mVentas("40111", sucursal, iniFinFactura, 0, igv));
                ventaTotal.Add(new mVentas("46997", sucursal, iniFinFactura, 0, rc));
                ventaTotal.Add(new mVentas("70111", sucursal, iniFinFactura, 0, bi));
                int i = 0;
                foreach (var data in  ventaTotal)
                {
                    this.Pla_cCuentaContable = data.cuenta;
                    this.Asd_nItem = i + 1;
                    this.Asd_nDebeSoles = cadena == "BC" || cadena == "FC" ? data.haber * -1 : data.debe;
                    this.Asd_nHaberSoles = cadena == "BC" || cadena == "FC" ? data.debe * -1 : data.haber;
                    
                    this.Cos_cCodigo = data.cuenta == "70111" ? data.serie : "";
                    this.Ten_cTipoEntidad = data.cuenta == "12121" ? "C" : "";
                  
                    this.Ent_cCodEntidad = data.cuenta == "12121" ? codigoDeEntidad(contClient,contRuc,direccion,conx): "";
                    this.Asd_cNumDoc = data.numero;
                    this.Asd_cBaseImp = (data.cuenta == "40111" || data.cuenta == "70111") ? "002" : "";
                    string query2 = @"spCn_GrabaAsientoDet 'INSERTAR','" + this.Ase_cNummov + "','" + this.Emp_cCodigo + "','" + this.Pan_cAnio + "','" + this.Per_cPeriodo + "','" + 
                                           this.Lib_cTipoLibro + "','" + this.Ase_nVoucher + "'," + this.Asd_nItem + ",'" + this.Pla_cCuentaContable + "','" + sGlosa + "'," +
                                           this.Asd_nDebeSoles + "," + this.Asd_nDebeMonExt + "," + this.Asd_nHaberSoles + "," + this.Asd_nHaberMonExt + "," + this.Asd_nTipoCambio + ",'" +
                                           this.Cos_cCodigo + "','" + this.Ten_cTipoEntidad + "','" + this.Ent_cCodEntidad + "','" + this.Asd_cTipoDoc + "','" + this.Asd_cSerieDoc + "','" +
                                           this.Asd_cNumDoc + "','" + this.Asd_dFecDoc + "','" + this.Asd_cTipoDocRef + "','" + this.Asd_cSerieDocRef +"','" + this.Asd_cNumDocRef + "'," +
                                           this.Asd_dFecDocRef + "," + this.Asd_nMontoInafecto + ",'" + this.Asd_cRetencion + "','" + this.Asd_cFlgSpot + "'," + "NULL" + ",'" +
                                           this.Asd_cNumSpot + "','" + this.Asd_cDestino + "'," + this.Asd_nCorre + ",'" + this.Asd_cUserCrea + "','" + this.Asd_cEstado + "','" +
                                           this.Asd_cProvCanc + "','" + this.Asd_cOperaTC + "','" + this.Asd_cTipoMoneda + "'," + "default" + "," + this.Imp_nPorcentaje + ",'" +
                                           this.Asd_cAfecto + "'," + "NULL" + "," + "default" + "," + "default" + ",'" + this.Asd_cBaseImp+ "','" +
                                           this.Asd_cMonAdic + "'," + this.Asd_cImpAdic + ",'" + this.Asd_cComprobante + "','" + this.Asd_cProceso + "','" + this.Ecp_cOperacion + "','" +
                                           this.Asd_cRegAux + "','" + this.Asd_cConvMon + "','" + this.Asd_cManual + "','" + this.Asd_cRegAuxDet + "','" + this.Asd_cGrupo + "','" +
                                           this.Asd_cCodConcepto + "'," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL";
                    
                   
            
                    
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


        public void crearCabecera(string anio, string periodo, string libro, string glosa,string conn,string fechaReal, ref string movimiento, ref string voucher, int tipoMoneda )
        {

            int i = 0;
            bool listo = false;
            Ase_cTipoMoneda = tipoMoneda ==2 ? "040":"038";
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
          //  decimal sumFacturaDol = 0;
            decimal sumEfectivo = 0;
            decimal sumVisa = 0;
            decimal sumMaster = 0;
            decimal sumAmerican = 0;
            decimal sumDiner = 0;
            decimal sumConsumo = 0;
            decimal sumDolares = 0;
            decimal sumRappid = 0;
            decimal sumGlovo = 0;
            decimal sumCasaAzul = 0;
            decimal sumLanve = 0;
            decimal sumInterbank = 0;
            decimal sumCredito = 0;


            //string[] tienda = new string[] { "001T", "006T", "007T", "008T" };
           /* string[, ,] tiendas = new string[5, 5, 2]  { {{"Miraflores","001T"}, {"Miraflores","B001"}, {"Miraflores","F001"}, {"Miraflores","BC01"}, {"Miraflores","FC01"}},
                                                       { {"Miraflores","001T"}, {"Miraflores","B006"}, {"Miraflores","F006"}, {"Miraflores","BC06"}, {"Miraflores","FC06"}},
		                                               {  {"Surco","006T"}, {"Surco","B002"}, {"Surco","F002"}, {"Surco","BC02"}, {"Surco","FC02"}}, 
		                                               {  {"San Isidro","007T"}, {"San Isidro","B004"}, {"San Isidro","F004"}, {"San Isidro","BC04"}, {"San Isidro","FC04"}},
		                                               {  {"San Isidro","008T"}, {"San Isidro","B005"}, {"San Isidro","F005"}, {"San Isidro","BC05"}, {"San Isidro","FC05"}}};*/

           // string[,] tiendas = new string[3, 2] { {"",""}, {"", ""}, {"",""} };
            string[] consulta= { "sc.VENTAS_MIRAFLORES = 'T'", "sc.VENTAS_SURCO = 'T' ", "sc.VENTAS_SAN_ISIDRO = 'T' " };
            string[] tiendas = {"MIRAFLORES","SURCO","SAN ISIDRO"};
            string t = "";
            string serie = "";
            string sql = "";
            string sqlT = "";
            string sucursal = "";
            string facturas = "";
            string movi = "";
            string vouc = "";
            int moneda;
            int indice = 0;
            string cadena = "";
            string cliente = "";
            string ruc = "";
            string direccion = "";
            Boolean activado;
            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes

            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

            for (int i = 1; i < 4; i++)
             {

             
                 Conexion pn = new Conexion(conex1);
                 Conexion bn = new Conexion(conex1);
                 movi = "";
                 vouc = "";
                 
                 activado = true;


                 // busca las series de las tiendas
                 sqlT = @"SELECT S.SERIE FROM SERIES S INNER JOIN SERIESCAMPOSLIBRES SC ON S.SERIE = SC.SERIE WHERE " + consulta[i-1];
                 SqlDataReader buscaSerie = bn.consulta3(sqlT);
                 
                 //fin de busqueda

                 sqlT = @"SELECT a.numero,CASE  WHEN d.total IS NULL THEN 0 ELSE d.total END AS total,a.IMPORTE,a.CODFORMAPAGO,c.DESCRIPCION
                                    FROM VW_TESORERIA a inner join TIPOSPAGO b on a.CODTIPOPAGO = b.CODTIPOPAGO
                                    inner join FORMASPAGO c on a.CODFORMAPAGO = c.CODFORMAPAGO
                                    left join FACTURASVENTATOT d on a.NUMERO = d.NUMERO and a.serie = d.SERIE
                                    left join series s on s.SERIE = d.SERIE
                                    inner join SERIESCAMPOSLIBRES sc on s.SERIE = sc.SERIE
                                    WHERE " +consulta[i-1] +"  and FECHADOCUMENTO = '" + fechaSql + "' order by numero";

                 SqlDataReader lector = pn.consulta3(sqlT);

          if(buscaSerie.HasRows)
           {
            try
             {
             while (buscaSerie.Read())
              {

                serie = buscaSerie.GetValue(0).ToString();
                cobro.Clear();
                t = i == 1 ? "01" : i == 2 ? "02" : i == 3 ? "05" : "05";
                moneda = 0;
                cadena = serie.Substring(0, 2);
               
                    
                    //consulta que saca la informacion de ventas
                    Conexion cn = new Conexion(conex1);


                    sql = @"SELECT A.NUMFACTURA AS NUMERO,0 AS total, '' as cliente, '' ruc,'' DIRECCION , '' CREDITO
                            FROM FACTURASVENTA AS A inner join CLIENTES c on c.CODCLIENTE = a.CODCLIENTE
                        where a.FECHAENTRADA = '" + fechaSql + "' and a.NUMSERIE = '" + serie  +"' and a.TOTALNETO = 0 ";
                    sql = sql + @" union 
                        SELECT numero,SUM(total),COALESCE(NOMBRECLIENTE,'') cliente,COALESCE(NIF20,'') ruc,COALESCE(DIRECCION1,'') DIRECCION,  COALESCE(CODBANCO,'') CREDITO
                             from FACTURASVENTA b right outer join FACTURASVENTATOT a on a.NUMERO = b.NUMFACTURA and a.SERIE = b.NUMSERIE 
                             inner join clientes  c on c.CODCLIENTE = b.CODCLIENTE
                        where b.FECHAENTRADA = '" + fechaSql + "' and a.SERIE = '" + serie + @"' 
                        group by numero,NOMBRECLIENTE,NIF20, DIRECCION1,CODBANCO
                        order by NUMERO";


           
                    SqlDataReader reader = cn.consulta3(sql);
                    //se le asigna a cada cuenta contable el valor correpondiente de la venta, para despues realizar una agrupacion y sacar la diferencia
                    if (reader.HasRows)
                    {
                        Int32 num = 0;

                        // el caso de que sea una nota de credito o una factura para que haga el detalle de cada factura y nota de credito
                        if (cadena != "B0")
                        {
                            while (reader.Read())
                            {
                                cobro.Clear();
                                if (num != reader.GetInt32(0))
                                {
                                    cobro.Add(new mCobros("12121", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(1)), "FACTURA"));

                                    if (reader.GetValue(5).ToString().Trim() == "CRED" && cadena != "FC")
                                    {
                                        cobro.Add(new mCobros("12131", t, (reader.GetInt32(0)).ToString(),0 , Convert.ToDecimal(reader.GetValue(1)), "CREDITO"));
                                    }
                                   

                                    num = reader.GetInt32(0);
                                    sumFactura = Math.Round(cobro.Sum(z => z.cuenta == "12121" ? z.haber : 0), 2);
                                    sumCredito = Math.Round(cobro.Sum(z => z.cuenta == "12131" ? z.haber : 0), 2);
                                    sumDolares = Math.Round(cobro.Sum(z => z.cuenta == "10112" ? z.debe : 0), 2);
                                    moneda = 0;
                                    //Asignacion de resultados para crear el asiento cabecera
                                    sucursal = tiendas[i-1];
                                    cliente = reader.GetString(2).Trim();
                                    ruc = reader.GetString(3).Trim();
                                    direccion = reader.GetString(4).Trim();
                                    vg.Anio = fecha.Year.ToString();
                                    vg.Periodo = fecha.ToString("MM");
                                    vg.Libro = "02";
                                    facturas = reader.GetInt32(0).ToString().PadLeft(8, '0');
                                    vg.Glosa = "REG CUADRE: " + sucursal + " " + facturas + " Fecha: " + fecha.ToString("dd-MM-yyyy");
                                    /////////////////////////////////////////

                                    // cobroTotal.Add(new mCobros("12121", sucursal, factuas, facturas, 0));

                                    // si hay diferencia entre la cuenta x cobrar y el total neto de la venta
                                    // llenamos el combo box con la fecha y la tienda que tiene los problemas, para que este muestre en el grid el detalle

                                    //verifica si el asiento existe
                                    if (vg.checkAll(conex2) && activado == true)
                                    {
                                        mv.Message = "El Asiento ya Existe, por favor Verifique";
                                        mv.Caption = "Error Asiento existente";
                                        mv.mensajeria();
                                    }
                                    else // en caso de qeu no exista crea la cabecera y crea el asiento
                                    {
                                        while (moneda <= 1)
                                        {

                                            moneda++;
                                            vg.Glosa = moneda == 1 ? vg.Glosa : vg.Glosa + " DOLARES";
                                            if (moneda == 1)
                                            {
                                                cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFactura, "Facturas"));
                                                if (reader.GetValue(5).ToString().Trim() == "CRED" && cadena != "FC")
                                                    {
                                                        cobroTotal.Add(new mCobros("12131", sucursal, facturas,0 , sumCredito, "Credito"));
                                                  }

                                                if (activado == true)
                                                {
                                                    crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                                    activado = false;
                                                    indice = 0;
                                                }
                                                sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                                cobroTotal.Clear();
                                            }
                                            else
                                            {
                                                

                                                if (sumDolares != 0)
                                                {
                                                    cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFactura, "Facturas"));
                                                    // cobroTotal.Add(new mCobros("10112", sucursal, facturas, sumDolares, 0, "Dolares"));
                                                    if (activado == true)
                                                    {
                                                        crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                                        activado = false;
                                                    }

                                                    sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                                    cobroTotal.Clear();
                                                }
                                            }
                                            cobroTotal.Clear();
                                        }

                                    }
                                }
                            }
                        } // aqui termina el if para sacar uno por uno de facturas y notas de credito


                        if (cadena == "B0" )
                        {
                            moneda = 0;
                            while (reader.Read())
                            {
                                if (num != reader.GetInt32(0))
                                    cobro.Add(new mCobros("12121", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(1)), "FACTURA"));
                                num = reader.GetInt32(0);
                            }

                            sumFactura = Math.Round(cobro.Sum(z => z.haber), 2);
                            sumDolares = Math.Round(cobro.Sum(z => z.cuenta == "10112" ? z.debe : 0), 2);

                            //Asignacion de resultados para crear el asiento cabecera
                            cliente = "";
                            ruc = "";
                            direccion = "";
                            sucursal = tiendas[i-1];
                            vg.Anio = fecha.Year.ToString();
                            vg.Periodo = fecha.ToString("MM");
                            vg.Libro = "02";
                            facturas = cobro.First().numero.ToString().PadLeft(5, '0') + "-" + cobro.Last().numero.ToString().PadLeft(5, '0');
                            vg.Glosa = "REG CUADRE: " + sucursal + " " + facturas + " Fecha: " + fecha.ToString("dd-MM-yyyy");
                            /////////////////////////////////////////




                            // cobroTotal.Add(new mCobros("12121", sucursal, factuas, facturas, 0));

                            // si hay diferencia entre la cuenta x cobrar y el total neto de la venta
                            // llenamos el combo box con la fecha y la tienda que tiene los problemas, para que este muestre en el grid el detalle

                            //verifica si el asiento existe
                            if (vg.checkAll(conex2) && activado == true)
                            {
                                mv.Message = "El Asiento ya Existe, por favor Verifique";
                                mv.Caption = "Error Asiento existente";
                                mv.mensajeria();
                            }
                            else // en caso de qeu no exista crea la cabecera y crea el asiento
                            {
                                while (moneda <= 1)
                                {

                                    moneda++;
                                    vg.Glosa = moneda == 1 ? vg.Glosa : vg.Glosa + " DOLARES";
                                    if (moneda == 1)
                                    {
                                        cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFactura, "Facturas"));


                                        if (activado == true)
                                        {
                                            crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                            activado = false;
                                            indice = 0;
                                        }
                                        sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                        cobroTotal.Clear();
                                    }
                                    else
                                    {
                                        // if (sumFacturaDol != 0)
                                        //     cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFacturaDol, "FacturasDolares"));
                                        //if (sumDolares != 0)

                                        if (sumDolares != 0)
                                        {
                                            cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFactura, "Facturas"));

                                            if (activado == true)
                                            {
                                                crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                                activado = false;
                                            }

                                            sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                            cobroTotal.Clear();
                                        }
                                    }
                                    cobroTotal.Clear();
                                }

                            }
                        }// aqui termina el if para agrupar boletas
                    }
                       
                }
                  buscaSerie.Close() ;
                    if (lector.HasRows)
                        {
                            int x = 0;
                            while (lector.Read())
                            {
                                x = Convert.ToInt32(lector.GetValue(3));
                                switch (x)
                                {
                                    case 1://efectivo
                                        cobro.Add(new mCobros("10111", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "EFECTIVO"));
                                        break;
                                    case 2://visa
                                        cobro.Add(new mCobros("16292", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "VISA"));
                                        break;
                                    case 3://master
                                        cobro.Add(new mCobros("16291", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "MASTER"));
                                        break;
                                    case 5://american
                                        cobro.Add(new mCobros("16293", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "AMERICAN"));
                                        break;
                                    case 6://dollares
                                        cobro.Add(new mCobros("10112", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "DOLLARES"));
                                        break;
                                    case 8://diner
                                        cobro.Add(new mCobros("16294", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "DINER"));
                                        break;
                                    case 10://consumo
                                        cobro.Add(new mCobros("16981", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "CONSUMO"));
                                        break;
                                    case 14://rappid
                                        cobro.Add(new mCobros("16299", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "RAPPID"));
                                        break;
                                    case 15://glovo
                                        cobro.Add(new mCobros("16296", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "GLOVO"));
                                        break;
                                    case 12://casaazul
                                        cobro.Add(new mCobros("16297", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "CASA AZUL"));
                                        break;
                                    case 17://lanve
                                        cobro.Add(new mCobros("16298", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "LANVE"));
                                        break;
                                    case 11://interbank
                                        cobro.Add(new mCobros("16292", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "INTERBANK"));
                                        break;
                                   // case 16://interbank
                                     //   cobro.Add(new mCobros("16300", t, (lector.GetInt32(0)).ToString(), Convert.ToDecimal(lector.GetValue(2)), 0, "GRIFOS"));
                                      //  break;


                                }
                            }
                        
                           
                            sumEfectivo = Math.Round(cobro.Sum(z => z.cuenta == "10111" ? z.debe : 0), 2);
                            sumVisa = Math.Round(cobro.Sum(z => z.cuenta == "16292" ? z.debe : 0), 2);
                            sumMaster = Math.Round(cobro.Sum(z => z.cuenta == "16291" ? z.debe : 0), 2);
                            sumAmerican = Math.Round(cobro.Sum(z => z.cuenta == "16293" ? z.debe : 0), 2);
                            sumDiner = Math.Round(cobro.Sum(z => z.cuenta == "16294" ? z.debe : 0), 2);
                            sumConsumo = Math.Round(cobro.Sum(z => z.cuenta == "16981" ? z.debe : 0), 2);
                            sumRappid = Math.Round(cobro.Sum(z => z.cuenta == "16299" ? z.debe : 0), 2);
                            sumGlovo = Math.Round(cobro.Sum(z => z.cuenta == "16296" ? z.debe : 0), 2);
                            sumCasaAzul = Math.Round(cobro.Sum(z => z.cuenta == "16297" ? z.debe : 0), 2);
                            sumLanve = Math.Round(cobro.Sum(z => z.cuenta == "16298" ? z.debe : 0), 2);
                            sumInterbank = Math.Round(cobro.Sum(z => z.cuenta == "16290" ? z.debe : 0), 2);
                        //    sumGrifo = Math.Round(cobro.Sum(z => z.cuenta == "16300" ? z.debe : 0), 2);
                            
                            sumDolares = Math.Round(cobro.Sum(z => z.cuenta == "10112" ? z.debe : 0), 2);

                            //Asignacion de resultados para crear el asiento cabecera
                            cliente = "";
                            ruc = "";
                            direccion = "";
                            sucursal = tiendas[i-1];
                            vg.Anio = fecha.Year.ToString();
                            vg.Periodo = fecha.ToString("MM");
                            vg.Libro = "02";
                            //facturas = cobro.First().numero.ToString().PadLeft(5, '0') + "-" + cobro.Last().numero.ToString().PadLeft(5, '0');
                            vg.Glosa = "REG CUADRE: " + sucursal +  " Fecha: " + fecha.ToString("dd-MM-yyyy");
                            /////////////////////////////////////////
                            moneda = 0;
                           
                          
                                while (moneda <= 1)
                                {

                                    moneda++;
                                    vg.Glosa = moneda == 1 ? vg.Glosa : vg.Glosa + " DOLARES";
                                    if (moneda == 1)
                                    {
                                       
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
                                        if (sumRappid != 0)
                                            cobroTotal.Add(new mCobros("16299", sucursal, facturas, sumRappid, 0, "Rappid"));
                                        if (sumGlovo != 0)
                                            cobroTotal.Add(new mCobros("16296", sucursal, facturas, sumGlovo, 0, "Glovo"));
                                        if (sumCasaAzul != 0)
                                            cobroTotal.Add(new mCobros("16297", sucursal, facturas, sumCasaAzul, 0, "Casa Azul"));
                                        if (sumLanve != 0)
                                            cobroTotal.Add(new mCobros("16298", sucursal, facturas, sumLanve, 0, "Lanve"));
                                        if (sumInterbank != 0)
                                            cobroTotal.Add(new mCobros("16292", sucursal, facturas, sumInterbank, 0, "Interbank"));
                                     //   if (sumGrifo != 0)
                                       ///     cobroTotal.Add(new mCobros("16300", sucursal, facturas, sumGrifo, 0, "Grifo"));

                                        if (activado == true)
                                        {
                                            crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                            activado = false;
                                            indice = 0;
                                        }
                                        sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                        cobroTotal.Clear();
                                    }
                                    else
                                    {
                                        // if (sumFacturaDol != 0)
                                        //     cobroTotal.Add(new mCobros("12121", sucursal, facturas, 0, sumFacturaDol, "FacturasDolares"));
                                        //if (sumDolares != 0)

                                        if (sumDolares != 0)
                                        {
                                           
                                            cobroTotal.Add(new mCobros("10112", sucursal, facturas, sumDolares, 0, "Dolares"));
                                            if (activado == true)
                                            {
                                                crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, moneda);
                                                activado = false;
                                            }

                                            sincronizarCobro(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, serie, facturas, t, conex2, movi, vouc, ref indice, cliente, ruc, direccion);
                                            cobroTotal.Clear();
                                        }
                                    }
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
            }//aqui el cierre de otra cosa
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
            //string[] tienda = new string[] { "006T","007T","008T", "B002", "B004", "B005",  "F002", "F004", "F005",  "BC02", "BC04", "BC05",  "FC02", "FC04", "FC05" };
            string[,] tiendas =  { {"Miraflores","B001"}, {"Miraflores","F001"}, {"Miraflores","BC01"}, {"Miraflores","FC01"},
                                   {"Miraflores","B006"}, {"Miraflores","F006"},{"Miraflores","BC06"}, {"Miraflores","FC06"},
                                   {"Surco","B002"}, {"Surco","F002"}, {"Surco","BC02"}, {"Surco","FC02"}, 
                                   {"Surco","B007"}, {"Surco","F007"}, {"Surco","BC07"}, {"Surco","FC07"}, 
                                   {"San Isidro","B004"}, {"San Isidro","F004"}, {"San Isidro","BC04"}, {"San Isidro","FC04"},
                                   {"San Isidro","B005"}, {"San Isidro","F005"}, {"San Isidro","BC05"}, {"San Isidro","FC05"}};
            string t = "";
            string sql = "";
            string sucursal = "";
            string facturas = "";
            string movi = "";
            string vouc = "";
            string cadena = "";
            string serieAnul = "";
            string nuemroAnul ="";
            string fechaAnul = "";
            string cliente = "";
            string ruc = "";
            string direccion = "";

            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mv = new MessageViewModel(); // objeto de la clase mensajes
           
            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
          
                         
           for (int j = 1; j < 21; j++)
             {
                venta.Clear();
                cadena = tiendas[j - 1, 1].Substring(0, 2);
                t = tiendas[j - 1, 0] == "Miraflores" ? "01" : tiendas[j - 1, 0] == "Surco" ? "02" : tiendas[j - 1, 0] == "San Isidro" ? "05" : "05";
                serieAnul = "";
                nuemroAnul = "";
                fechaAnul = "";

                movi = "";
                vouc = "";
                try
                {
                    //consulta que saca la informacion de ventas
                    Conexion cn = new Conexion(conex1);
                    sql = @"SELECT A.NUMFACTURA AS NUMERO,0 AS total,0 as totiva,0 as totreq, 0 as baseimponibre, '' as cliente, '' ruc,'' DIRECCION
                            FROM FACTURASVENTA AS A inner join CLIENTES c on c.CODCLIENTE = a.CODCLIENTE  
                            where a.FECHAENTRADA = '" + fechaSql + "' and a.NUMSERIE = '" + tiendas[j-1, 1] + "' and a.TOTALNETO = 0 "
                        + @" union 
                            SELECT numero,SUM(total),SUM(totiva),SUM(totreq),SUM(baseimponible),COALESCE(NOMBRECLIENTE,'') cliente,COALESCE(NIF20,'') ruc,COALESCE(DIRECCION1,'') DIRECCION
                             from FACTURASVENTA b right outer join FACTURASVENTATOT a on a.NUMERO = b.NUMFACTURA and a.SERIE = b.NUMSERIE 
                             inner join clientes  c on c.CODCLIENTE = b.CODCLIENTE
                             where b.FECHAENTRADA = '" + fechaSql + "' and a.SERIE = '" + tiendas[j - 1, 1] + @"' 
                             group by numero,NOMBRECLIENTE,NIF20, DIRECCION1
                             order by NUMERO";
                         
                      
                    SqlDataReader reader = cn.consulta3(sql);
                    //se le asigna a cada cuenta contable el valor correpondiente de la venta, para despues realizar una agrupacion y sacar la diferencia
                    if (reader.HasRows)
                    {
                        if (cadena != "B0" && cadena != "00")
                        {
                            
                            while (reader.Read())
                            {
                                venta.Clear();
                                venta.Add(new mVentas("12121", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(1)), 0));
                                venta.Add(new mVentas("40111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(2))));
                                venta.Add(new mVentas("40997", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(3))));
                                venta.Add(new mVentas("70111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(4))));




                                if (cadena == "FC" || cadena == "BC")
                                {
                                    string sqlabono = "";
                                    Conexion cn1 = new Conexion(conex1);
                                    sqlabono = @" SELECT top(1) HORA,  ABONODE_NUMSERIE, ABONODE_NUMALBARAN
                                                FROM   ALBVENTALIN
                                                WHERE  (NUMALBARAN = " + reader.GetInt32(0).ToString() + " ) AND (NUMSERIE = '" + tiendas[j - 1, 1] + "')";
                                    SqlDataReader lector = cn1.consulta3(sqlabono);
                                    if (lector.HasRows)
                                    {
                                        while (lector.Read())
                                        {
                                            fechaAnul = lector.GetDateTime(0).ToString("dd-MM-yyyy");
                                            serieAnul = lector.GetString(1).ToString();
                                            nuemroAnul = lector.GetValue(2).ToString();
                                        }
                                    }
                                }

                                sucursal = tiendas[j - 1, 0];//i == 1 ? "MIRAFLORES" : i == 2 ? "SURCO" : i == 3 ? "SAN ISIDRO" : "SAN ISIDRO";
                                //    tienda[i - 1] == "001T;" ? "MIRAFLORES" : tienda[i - 1] == "006T" ? "SURCO" : "SAN ISIDRO"; 
                                vg.Anio = fecha.Year.ToString();
                                vg.Periodo = fecha.ToString("MM");
                                vg.Libro = "05";
                                facturas = reader.GetInt32(0).ToString().PadLeft(8, '0');
                                cliente = reader.GetString(5).Trim();
                                ruc = reader.GetString(6).Trim();
                                direccion = reader.GetString(7).Trim();
                                vg.Glosa = "CONSUMO: " + sucursal + " " + tiendas[j - 1, 1] + " - " + facturas + " " + " Fecha: " + fecha.ToString("dd-MM-yyyy");
                                cxc = Math.Round(venta.Sum(x => x.cuenta == "12121" ? x.debe : 0), 2);
                                igv = Math.Round(venta.Sum(x => x.cuenta == "40111" ? x.haber : 0), 2);
                                rc = Math.Round(venta.Sum(x => x.cuenta == "40997" ? x.haber : 0), 2);
                                bi = Math.Round(venta.Sum(x => x.cuenta == "70111" ? x.haber : 0), 2);
                                totalNeto = igv + rc + bi;
                                
                                if (cxc != Math.Round(totalNeto, 2))
                                {
                                    MostrarLista unMostrar = new MostrarLista();
                                    unMostrar.Fecha = fecha.ToString("dd-MM-yyyy");
                                    unMostrar.Tienda = tiendas[j - 1, 0];
                                    ListaMostrar.Add(unMostrar);
                                    
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
                                        j = 21;
                                    }
                                    else // en caso de qeu no exista crea la cabecera y crea el asiento
                                    {
                                                                                
                                        crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, 1);
                                        sincronizar(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, tiendas[j - 1, 1], cxc, igv, rc, bi, facturas, t, 
                                                    conex2, movi, vouc, fechaAnul, serieAnul, nuemroAnul, cliente, ruc, direccion);

                                    }
                                }


                            }


                        }

                        if (cadena == "B0" || cadena == "00")
                        {
                            venta.Clear();

                            while (reader.Read())
                            {

                                venta.Add(new mVentas("12121", t, (reader.GetInt32(0)).ToString(), Convert.ToDecimal(reader.GetValue(1)), 0));
                                venta.Add(new mVentas("40111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(2))));
                                venta.Add(new mVentas("40997", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(3))));
                                venta.Add(new mVentas("70111", t, (reader.GetInt32(0)).ToString(), 0, Convert.ToDecimal(reader.GetValue(4))));
                            }


                            sucursal = tiendas[j - 1, 0];
                           
                            cxc = Math.Round(venta.Sum(x => x.cuenta == "12121" ? x.debe : 0), 2);
                                igv = Math.Round(venta.Sum(x => x.cuenta == "40111" ? x.haber : 0), 2);
                                rc = Math.Round(venta.Sum(x => x.cuenta == "40997" ? x.haber : 0), 2);
                                bi = Math.Round(venta.Sum(x => x.cuenta == "70111" ? x.haber : 0), 2);


                                //Asignacion de resultados para crear el asiento cabecera
                                totalNeto = igv + rc + bi;
                                
                                vg.Anio = fecha.Year.ToString();
                                vg.Periodo = fecha.ToString("MM");
                                vg.Libro = "05";
                                facturas = venta.First().numero.ToString().PadLeft(5, '0') + "-" + venta.Last().numero.ToString().PadLeft(5, '0');
                                vg.Glosa = "CONSUMO: " + sucursal + " " + tiendas[j - 1, 1] + " - " + facturas + " " + " Fecha: " + fecha.ToString("dd-MM-yyyy");

                                // si hay diferencia entre la cuenta x cobrar y el total neto de la venta
                                // llenamos el combo box con la fecha y la tienda que tiene los problemas, para que este muestre en el grid el detalle
                                if (cxc != Math.Round(totalNeto, 2))
                                {
                                    MostrarLista unMostrar = new MostrarLista();
                                    unMostrar.Fecha = fecha.ToString("dd-MM-yyyy");
                                    unMostrar.Tienda = tiendas[j - 1, 0];
                                    ListaMostrar.Add(unMostrar);
                                    
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
                                        j = 21;
                                    }
                                    else // en caso de qeu no exista crea la cabecera y crea el asiento
                                    {
                                        crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, fecha.ToString("dd-MM-yyyy"), ref movi, ref vouc, 1);


                                        sincronizar(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, fechaSql, tiendas[j - 1, 1], cxc, igv, rc, bi, facturas, t, conex2, movi, vouc, fechaAnul, serieAnul, nuemroAnul,"","","");
                                    }
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
    
        ///// 

       

        /// <summary>
        /// //
        /// </summary>
        /// <param name="fechaSql"></param>
        /// <param name="conex1"></param>
        /// <param name="conex2"></param>
        
        public void verificarCompras(string fechaSql, string conex1, string conex2)
        {
            
            string[] tienda = new string[] { "001T", "006T", "007T", "008T" };
            string myProperty = App.Current.Properties["movimientos"].ToString();
            string movimiento = "";
            string t = "";
            string sql = "";
            string sql1 = "";
            string movi = "";
            string vouc = "";
            string cuenta = "";
            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mc = new MessageViewModel(); // objeto de la clase mensajes
           
            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime emision;
             if (myProperty == "0"){
                 movimiento = "' and (a.NUMSERIE != '4C' and a.NUMSERIE != 'A') ";
             }else
             {
                 movimiento = "' and (a.NUMSERIE = '4C' or a.NUMSERIE = 'A')  ";
             }
            try
            {
                        
                //consulta que saca la informacion de ventas
                    Conexion cn = new Conexion(conex1);
                    sql = @"select a.NUMALBARAN,
                            case  when p.entidad IS NULL  then '99999' else p.entidad end as entidad, 
                            case when ac.serie_doc IS NULL or ac.serie_doc = '' then 'err' else  replicate ('0',(4 - len( ac.serie_doc))) + convert(varchar,  ac.serie_doc) end as serie,
                            case when pro.NIF20 IS NULL or pro.NIF20 = '' then 'err' else pro.NIF20 end as ruc,
                            case when pro.NOMPROVEEDOR IS NULL or pro.NOMPROVEEDOR = '' then 'err' else pro.NOMPROVEEDOR end as proveedor,
                            case when a.sualbaran IS NULL or sualbaran = '' then 'err' else replicate ('0',(8 - len( a.sualbaran))) + convert(varchar,  a.sualbaran) end as SUALBARAN,
                            count(a.NUMALBARAN) cantFac,
                            MAX(a.TOTALIMPUESTOS) igv,
                            MAX(a.TOTALNETO) neto,
                            case when ac.FECHA_EMISION is null then a.FECHAALBARAN else ac.FECHA_EMISION END FECHA_EMISION,
                            a.numserie as cCosto
                             from ALBCOMPRACAB as a inner join ALBCOMPRALIN as b on a.NUMALBARAN = b.NUMALBARAN and a.NUMSERIE = b.NUMSERIE
                             inner join ALBCOMPRACAMPOSLIBRES AS AC ON ac.NUMALBARAN = A.NUMALBARAN AND AC.NUMSERIE = A.NUMSERIE
                             inner join PROVEEDORES AS pro on a.CODPROVEEDOR = pro.CODPROVEEDOR
                             inner join PROVEEDORESCAMPOSLIBRES as p on a.CODPROVEEDOR = p.CODPROVEEDOR 
	                         inner join articulos as c on c.CODARTICULO = b.CODARTICULO
	                         inner join secciones as s on c.SECCION = s.NUMSECCION
                        where a.FECHAALBARAN = '" + fechaSql + movimiento + " and pro.NIF20 != '20491980860' and  upper(ac.TIPO_DOCUMENTOP) = 'F' " +
                        "group by a.NUMALBARAN, p.ENTIDAD, ac.serie_doc, pro.NIF20, pro.NOMPROVEEDOR,a.SUALBARAN,A.FECHAALBARAN,ac.fecha_emision, a.numserie ";
                    
               

                    SqlDataReader reader = cn.consulta3(sql);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Conexion cn2 = new Conexion(conex1); 
                            sql1 = @"select a.NUMALBARAN as factura,s.CENTROCOSTE as cuenta, sum(b.total) sub_total
                                from ALBCOMPRACAB as a inner join ALBCOMPRALIN as b on a.NUMALBARAN = b.NUMALBARAN and a.NUMSERIE = b.NUMSERIE
                                     inner join ALBCOMPRACAMPOSLIBRES AS AC ON ac.NUMALBARAN = A.NUMALBARAN AND AC.NUMSERIE = A.NUMSERIE
                                     inner join PROVEEDORESCAMPOSLIBRES as p on a.CODPROVEEDOR = p.CODPROVEEDOR 
	                                 inner join articulos as c on c.CODARTICULO = b.CODARTICULO
	                                 inner join secciones as s on c.SECCION = s.NUMSECCION
                                where a.FECHAALBARAN = '" + fechaSql + movimiento + " and  upper(ac.TIPO_DOCUMENTOP) = 'F' and a.NUMALBARAN = " + reader.GetValue(0).ToString() + 
                                " group by a.NUMALBARAN,s.CENTROCOSTE";
                           
                            SqlDataReader reader2 = cn2.consulta3(sql1);
                            
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                   // en el ultimo campo hay que poner la serie
                                    if (reader2.GetString(1) == "")
                                        cuenta = "65978";
                                    else
                                        cuenta = reader2.GetString(1);

                                    ComprasTotal.Add(new mCompras(cuenta, reader.GetString(1), reader.GetValue(5).ToString(), Convert.ToDecimal(reader2.GetValue(2)), 0, reader.GetString(2), reader.GetString(10)));
                                }
                            }
                            // en el ultimo campo hay que poner la serie
                            ComprasTotal.Add(new mCompras("40111", reader.GetString(1), reader.GetValue(5).ToString(), Convert.ToDecimal(reader.GetValue(7)), 0, reader.GetString(2), reader.GetString(10)));
                            ComprasTotal.Add(new mCompras("42120", reader.GetString(1), reader.GetValue(5).ToString(), 0, Convert.ToDecimal(reader.GetValue(8)), reader.GetString(2), reader.GetString(10)));
                            
                                 emision = reader.GetDateTime(9);
                                vg.Anio = emision.Year.ToString();
                                vg.Periodo = emision.ToString("MM");
                           
                            vg.Libro = "06";
                            vg.Glosa = "COMPRAS: " + "Nro. " + reader.GetString(5) + " Proveedor: " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4)+ " C.C: "+  reader.GetString(10);
                            crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, emision.ToString("dd-MM-yyyy"), ref movi, ref vouc, 0);
                            sincronizarCompra(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, emision.ToString("yyyyMMdd"), "", "", t, conex2, movi, vouc);
                            ComprasTotal.Clear();
                            cn2.Cerrar();
                        }

                    }
                    cn.Cerrar();
            }
            catch (Exception e)
            {
                mc.Message = mv.ToStringAllExceptionDetails(e);
                mc.Caption = "Error sql";
                mc.mensajeria();

            }

        }



        public void verificarGastos(string fechaSql,DateTime begin,DateTime end, string conex1, string conex2)
        {

            string[] tienda = new string[] { "001T", "006T", "007T", "008T" };
            
            
            string t = "";
            string sql = "";
            string sql1 = "";
            string movi = "";
            string vouc = "";
            
            string[] separadas;
            string anio = "";
            string periodo = "";

            
            VerificaGlosa vg = new VerificaGlosa(); // objeto de clase de vericacion de glosa
            MessageViewModel mc = new MessageViewModel(); // objeto de la clase mensajes

            DateTime fecha = DateTime.ParseExact(fechaSql, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            

            anio = begin.Year.ToString();
            periodo = begin.ToString("MM");

            try
            {

                //consulta que saca la informacion de ventas
                Conexion cn = new Conexion(conex1);
                Conexion cn1 = new Conexion(conex2);
                sql = @"select p.fecha, p.CAJA, p.numero,p.COMENTARIO,p.IMPORTE, bd.CIF
                        from pagos as p 
                        left join CONCEPTOSPAGO as c on p.CODCONCEPTOPAGO = c.ID
                        left join cBD1_2017.dbo.cuentas as bd on p.CUENTADEGASTOS = bd.CODIGO COLLATE Modern_Spanish_CS_AS
                        where p.fecha = "+fechaSql+" and tipo = 1";

                sql1 = @"SELECT Pla_cCuentaContable, Ent_cCodEntidad, Asd_cNumDoc, Asd_nDebeSoles, Asd_nHaberSoles,  
                        Asd_cSerieDoc, Cos_cCodigo,  Asd_cGlosa, Asd_dFecDoc,   Ten_cTipoEntidad
                        FROM   CND_ASIENTO_VOUCHER
                        WHERE  (Emp_cCodigo = '003') 
                        AND (Pan_cAnio = '" +anio+ "') AND (Per_cPeriodo = '"+periodo+@"')  
                        AND (Lib_cTipoLibro = '06') AND (Pla_cCuentaContable = '42120')
                        AND ( right(Ase_cGlosa,2) = '001' or right(Ase_cGlosa,2) = '006' or right(Ase_cGlosa,2) = '007')";

                SqlDataReader reader = cn.consulta3(sql);
                SqlDataReader contaReader = cn1.consulta3(sql);
                if (reader.HasRows || contaReader.HasRows)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            separadas = reader.GetString(3).Split(',');

                            gastos.Add(new mGastos(reader.GetString(5), "", separadas[1],
                                             Convert.ToDecimal(reader.GetValue(4)), 0, separadas[0],
                                             reader.GetString(1), "Gastos: " + separadas));
                        }
                    }

                    if (contaReader.HasRows)
                    {
                        while (contaReader.Read())
                        {

                            separadas = reader.GetString(3).Split(',');

                            gastos.Add(new mGastos(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToDecimal(reader.GetValue(3)), 0,
                                                  reader.GetString(5), reader.GetString(6), reader.GetString(7)));

                            // en el ultimo campo hay que poner la serie

                        }
                    }

                    if (begin == end)
                    {
                       
                        vg.Anio = end.Year.ToString();
                        vg.Periodo = end.ToString("MM");

                        vg.Libro = "03";
                        vg.Glosa = "COMPRAS: " + "Nro. " + reader.GetString(5) + " Proveedor: " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4) + " C.C: " + reader.GetString(10);
                        crearCabecera(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, conex2, end.ToString("dd-MM-yyyy"), ref movi, ref vouc, 0);
                        sincronizarCompra(vg.Anio, vg.Periodo, vg.Libro, vg.Glosa, end.ToString("yyyyMMdd"), "", "", t, conex2, movi, vouc);
                        ComprasTotal.Clear();

                    }
                }
                
                cn.Cerrar();
            }
            catch (Exception e)
            {
                mc.Message = mv.ToStringAllExceptionDetails(e);
                mc.Caption = "Error sql";
                mc.mensajeria();

            }

        }
    }


}
