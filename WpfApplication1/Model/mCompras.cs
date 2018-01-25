using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    class mCompras
    {
        public mCompras(string account, string ente, string number, decimal due, decimal have, string tipo_doc)
        {
            cuenta = account;
            entidad = ente;
            numero = number;
            debe = due;
            haber = have;
            serie_doc = tipo_doc;
           
        }

        public string cuenta { get; set; }
        public string entidad { get; set; }
        public string numero { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public string serie_doc { get; set; }
       

    }
}
