using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class MainWindowsViewModel
    {
        private int _selectedTabIndex;
        public int SelectedTabIndex {
            get { return _selectedTabIndex; }
            set{_selectedTabIndex = value;}
        }

        public MainWindowsViewModel()
        {
            SelectedTabIndex = 0;
        }
    }
}
