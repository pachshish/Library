
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LibraryModel
    {
       
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספרייה")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "ז'אנר")]
        public string Genre { get; set; } = string.Empty;
        [Display(Name = "מספר מדף")]
        public List<Shelf> Shelfses { get; set; } = new List<Shelf>();
    }
}
