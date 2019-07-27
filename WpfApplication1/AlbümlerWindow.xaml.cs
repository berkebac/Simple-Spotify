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
    /// Interaction logic for AlbümlerWindow.xaml
    /// </summary>
    public partial class AlbümlerWindow : Window
    {
        public AlbümlerWindow()
        {
            InitializeComponent();
        }
        private void Listele()
        {
            MainWindow mw = (MainWindow)Owner;
            Sanatçı seçsan = (Sanatçı)mw.lbsanatçılar.SelectedItem;
            lbAlbümler.ItemsSource = seçsan.Albümler;
        }
        private void btnalbumekle_Click(object sender, RoutedEventArgs e)
        {
            AlbümEkleWindow aew = new AlbümEkleWindow();
            aew.cmbSanatçı.ItemsSource = Veriler.Db.Sanatçılar.ToArray();
            aew.ShowDialog();
            lbAlbümler.Items.Refresh();
            
        }

        private void lbAlbümler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ParçaTürWindow ptw = new ParçaTürWindow() { Owner = this };
            Albüm seçılıalbüm = (Albüm)lbAlbümler.SelectedItem;
            ptw.dgParçalar.ItemsSource = seçılıalbüm.Parçalar.ToArray();
            ptw.tbalbumadı.Text = seçılıalbüm.AlbümAdı;
            ptw.ShowDialog();
            Listele();
            
        }
    }
}
