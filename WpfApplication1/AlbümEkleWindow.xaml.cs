using Microsoft.Win32;
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
    /// Interaction logic for AlbümEkleWindow.xaml
    /// </summary>
    public partial class AlbümEkleWindow : Window
    {
        public AlbümEkleWindow()
        {
            InitializeComponent();
            
        }

        private void btnafişekle_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = " Resim Dosyaları | *.jpg;*.png;*.bmp;*"
            };
            if (ofd.ShowDialog() == true)
            {
                imgafiş.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
            }
        }

        private void btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            Albüm yenialbüm = new Albüm() { Afiş = imgafiş.Source as BitmapImage, AlbümAdı = tbalbümadı.Text, Sanatçı = cmbSanatçı.SelectedItem as Sanatçı , ÇıkışTarihi=tbçıkıştarihi.Text };
            Veriler.Db.Albümler.Add(yenialbüm);
            Veriler.Db.SaveChanges();
            Close();
        }
    }
}
