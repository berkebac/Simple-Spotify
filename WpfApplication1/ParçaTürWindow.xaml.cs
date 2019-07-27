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
    /// Interaction logic for ParçaTürWindow.xaml
    /// </summary>
    public partial class ParçaTürWindow : Window
    {
        public ParçaTürWindow()
        {
            InitializeComponent();
        }
        private void Listele()
        {
            AlbümlerWindow aw = (AlbümlerWindow)Owner;
            Albüm seçılıalbüm = (Albüm)aw.lbAlbümler.SelectedItem;
            dgParçalar.ItemsSource = seçılıalbüm.Parçalar.ToArray();
            
            
        }
        private void btnparçaekle_Click(object sender, RoutedEventArgs e)
        {
            AlbümlerWindow mw = (AlbümlerWindow)Owner;
            ParçaEkleWindow pew = new ParçaEkleWindow() { Owner=this};
            
            Albüm seçilialbum = (Albüm)mw.lbAlbümler.SelectedItem;
            pew.cmbalbüm.ItemsSource = seçilialbum.Sanatçı.Albümler;
            pew.cmbalbüm.SelectedItem = seçilialbum;
            pew.tbsanatçı.Text = seçilialbum.Sanatçı.SanatçıAdı;
            pew.ShowDialog();
            Listele();
        }

        private void menuitempuanver_Click(object sender, RoutedEventArgs e)
        {
            PuanWindow pw = new PuanWindow() { Owner = this };
            pw.ShowDialog();
            Listele(); ;
        }

        private void btntürekle_Click(object sender, RoutedEventArgs e)
        {
            AlbümlerWindow mw = (AlbümlerWindow)Owner;
            TürEkleWindow tew = new TürEkleWindow();
            tew.cmbparçalar.ItemsSource = dgParçalar.ItemsSource;
            Albüm seçılısan = (Albüm)mw.lbAlbümler.SelectedItem;
            tew.tbsanatçı.Text = seçılısan.Sanatçı.SanatçıAdı;
            Albüm seçilialbüm = (Albüm)mw.lbAlbümler.SelectedItem;
            tew.tbalbümadı.Text = seçilialbüm.AlbümAdı;
            tew.ShowDialog();
            Listele();
            dgParçalar.SelectedIndex = -1;
        }

        private void menuitemsil_Click(object sender, RoutedEventArgs e)
        {
            Parça seçiliparça = (Parça)dgParçalar.SelectedItem;
            Veriler.Db.Parçalar.Remove(seçiliparça);
            Veriler.Db.SaveChanges();
            Listele();
        }
    }
}
