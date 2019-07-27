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
using WpfApplication1.models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for TürEkleWindow.xaml
    /// </summary>
    public partial class TürEkleWindow : Window
    {
        public TürEkleWindow()
        {
            InitializeComponent();
        }

        private void btntamam_Click(object sender, RoutedEventArgs e)
        {
            Tür yenitür = new Tür() { Türü = tbtüradı.Text, Parça = cmbparçalar.SelectedItem as Parça };
            Veriler.Db.Türler.Add(yenitür);
            Veriler.Db.SaveChanges();
            Close();
          
        }
    }
}
