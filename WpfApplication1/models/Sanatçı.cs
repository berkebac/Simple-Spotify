using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApplication1.models
{
    public class Sanatçı
    {
        public Sanatçı()
        {
            Albümler = new HashSet<Albüm>();
        }
        public int Id { get; set; }
        public string SanatçıAdı { get; set; }
        public virtual ICollection<Albüm> Albümler { get; set; }

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
