using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    class mGastos

    {
        public mGastos(string account, string ente, string number, decimal due, decimal have, string tipo_doc, string centroCosto, string gGlosa)
        {
            cuenta = account;//cuenta contable
            entidad = ente;// codigo de proveedro solo para factura
            numero = number;// numero del documento
            debe = due;//debe
            haber = have;//haber
            serie_doc = tipo_doc;// serie del document
            cCosto = centroCosto;// tienda a la que pertenece
            gastoGlosa = gGlosa;
        }

        public string cuenta { get; set; }
        public string entidad { get; set; }
        public string numero { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public string serie_doc { get; set; }
        public string cCosto { get; set; }
        public string gastoGlosa { get; set; }



    }
}

