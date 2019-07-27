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
    /// Interaction logic for PuanWindow.xaml
    /// </summary>
    public partial class PuanWindow : Window
    {
        public PuanWindow()
        {
            InitializeComponent();
        }

        private void btnpuanla_Click(object sender, RoutedEventArgs e)
        {

            ParçaTürWindow ptw = (ParçaTürWindow)Owner;
            Parça seçılıparça = (Parça)ptw.dgParçalar.SelectedItem;
            
            if (Convert.ToInt32(tbpuan.Text) > 5)
            {
                MessageBox.Show("En fazla 5 puan verilebilir");
            }
            else if (Convert.ToInt32(tbpuan.Text) <= 0)
            {
                MessageBox.Show("En az 1 puan verilebilir");
            }
            else
            {
                seçılıparça.ToplamPuan += Convert.ToInt32(tbpuan.Text);
                seçılıparça.OyVerenS++;
                Veriler.Db.SaveChanges();
            }
            
            Close();

        }
    }
}
