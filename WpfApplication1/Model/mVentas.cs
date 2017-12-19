using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public class mVentas
    {
        public mVentas(string account, string serial, string number, decimal due, decimal have){
            cuenta = account;
            serie  = serial;
            numero = number;
            debe   = due;
            haber = have;
        }

       

       
        public string cuenta { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }

        
    }

}
