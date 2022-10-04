using System.ComponentModel.DataAnnotations;

namespace SMStore.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Üst Menu?")]
        public bool IsTopMenu { get; set; }
        [Display(Name = "Üst Kategori")]
        public int ParentId { get; set; }
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }

        [Display(Name = "Ekleme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual ICollection<Product> Products { get; set; } // 1 kategorinin birden den cok ürün alabilir.1 e cok ilişki kurduk
        public Category()
        {
            Products = new List<Product>();
        }

    }
}
