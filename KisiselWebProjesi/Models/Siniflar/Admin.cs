using System.ComponentModel.DataAnnotations;

namespace KisiselWebProjesi.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        public string kullaniciadi { get; set; }

        public string sifre { get; set; }
    }
}