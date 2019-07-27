using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.models
{
    public class Tür
    {
        public int Id { get; set; }
        public string Türü { get; set; }

        [ForeignKey("Parça")]
        public int ParçaId { get; set; }
        public Parça Parça { get; set; }
        
    }
}
