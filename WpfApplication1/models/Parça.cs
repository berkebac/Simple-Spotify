using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace WpfApplication1.models
{
    public class Parça
    {
        public Parça()
        {
            Türler = new HashSet<Tür>();
        }

        public int Id { get; set; }
        public string ParçaAdı { get; set; }
        public int ParçaSüresi { get; set; }
        public double ToplamPuan { get; set; }
        public double OyVerenS { get; set; }
        [NotMapped]
        public double Puan
        {
            get
            {
                if (ToplamPuan == 0 && OyVerenS == 0)
                {
                    return 0;
                }
                else
                {
                    return ToplamPuan / OyVerenS;
                }
            }
        }

        public virtual ICollection<Tür> Türler { get; set; }

        [ForeignKey("Albüm")]
        public int AlbümId { get; set; }
        public Albüm Albüm { get; set; }

        public BitmapSource Görsel
        {
            get
            {
                if (Puan >= 5) { return new BitmapImage(new Uri("resim/5.png", UriKind.Relative)); }
                else if (Puan >= 4.5 && Puan < 5) { return new BitmapImage(new Uri("resim/4.5.png", UriKind.Relative)); }
                else if (Puan >= 4 && Puan < 4.5) { return new BitmapImage(new Uri("resim/4.png", UriKind.Relative)); }
                else if (Puan >= 3.5 && Puan < 4) { return new BitmapImage(new Uri("resim/3.5.png", UriKind.Relative)); }
                else if (Puan >= 3 && Puan < 3.5) { return new BitmapImage(new Uri("resim/3.png", UriKind.Relative)); }
                else if (Puan >= 2.5 && Puan < 3) { return new BitmapImage(new Uri("resim/2.5.png", UriKind.Relative)); }
                else if (Puan >= 2 && Puan < 2.5) { return new BitmapImage(new Uri("resim/2.png", UriKind.Relative)); }
                else if (Puan >= 1.5 && Puan < 2) { return new BitmapImage(new Uri("resim/1.5.png", UriKind.Relative)); }
                else if (Puan >= 1 && Puan < 1.5) { return new BitmapImage(new Uri("resim/1.png", UriKind.Relative)); }
                else { return new BitmapImage(new Uri("resim/0.5.png", UriKind.Relative)); }
            }
        }

    
    }
}
