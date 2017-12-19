using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    class mCobros
    {
        public mCobros(string account, string serial, string number, decimal due, decimal have, string tPago)
        {
            cuenta = account;
            serie = serial;
            numero = number;
            debe = due;
            haber = have;
            fPago = tPago;
        }

        public string cuenta { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public string fPago { get; set; }
        
    }
}
