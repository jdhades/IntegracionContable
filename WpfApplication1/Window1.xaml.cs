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


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : MetroWindow
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

       
        
        private void wTest_Activated(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            cmbFecha.Items.Clear();
            ComboBoxItem tab = new ComboBoxItem();
            DateTime inicio = DateTime.Parse(dpFecha1.Text);
            DateTime final = DateTime.Parse(dpFecha2.Text);
            for (DateTime i = inicio; i <= final; i = i.AddDays(1))
            {
               
                cmbFecha.Items.Add(i.ToShortDateString().ToString());
                //cmb.DataContext = tab;
                //tcGeneral.SelectedIndex = 0;
                
            }
        }

         
      
       
       
       
    }
}
