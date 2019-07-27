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
    /// Interaction logic for ParçaEkleWindow.xaml
    /// </summary>
    public partial class ParçaEkleWindow : Window
    {
        public ParçaEkleWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Parça yeniparça = new Parça() { ParçaAdı = tbparçaadı.Text, Albüm = cmbalbüm.SelectedItem as Albüm , ParçaSüresi =Convert.ToInt32(tbparçasüresi.Text)};
            Veriler.Db.Parçalar.Add(yeniparça);
            Veriler.Db.SaveChanges();
            ParçaTürWindow ptw = (ParçaTürWindow)Owner;

            ptw.dgParçalar.Items.Refresh();
            Close();
        }

        
    }
}
