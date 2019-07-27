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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Listele();
        }
        private void Listele()
        {
            lbsanatçılar.ItemsSource = Veriler.Db.Sanatçılar.ToArray();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            SanatçıEkleWindow sew = new SanatçıEkleWindow();
            sew.ShowDialog();
            Listele();
        }

        private void lbsanatçılar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AlbümlerWindow aw = new AlbümlerWindow() { Owner = this };
            Sanatçı seçsan = (Sanatçı)lbsanatçılar.SelectedItem;
            aw.lbAlbümler.ItemsSource = seçsan.Albümler;
            aw.ShowDialog();
        }
    }
}
