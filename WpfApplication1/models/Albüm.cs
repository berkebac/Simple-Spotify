using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.ComponentModel.DataAnnotations.Schema;
namespace WpfApplication1.models
{
    public class Albüm
    {
        public Albüm()
        {
            Parçalar = new HashSet<Parça>();
        }
        public int Id { get; set; }
        public string AlbümAdı { get; set; }
        public string ÇıkışTarihi { get; set; }
        [ForeignKey("Sanatçı")]
        public int SanatçıId { get; set; }
        public virtual Sanatçı Sanatçı { get; set; }
        public virtual ICollection<Parça> Parçalar { get; set; }

        [NotMapped]
        public BitmapSource Afiş { get; set; }

        public byte[] Afişveri
        {
            get
            {
                byte[] afişVeri = null;

                if (Afiş != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var kodlayıcı = new JpegBitmapEncoder();
                        kodlayıcı.Frames.Add(BitmapFrame.Create(Afiş));
                        kodlayıcı.Save(stream);
                        afişVeri = stream.ToArray();
                    }
                }
                return afişVeri;
            }
            set
            {
                if (value == null)
                {
                    Afiş = null;
                }
                else
                {
                    using (var stream = new MemoryStream(value))
                    {
                        var kodÇözücü = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        Afiş = kodÇözücü.Frames[0];
                    }
                }
            }
        }
    }
}
