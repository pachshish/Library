using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "שם הספר")]
        public string Name { get; set; }

        [Display(Name = "ז'אנר")]
        public string Genre { get; set; }

        [Display(Name = "גובה הספר")]
        public int Height { get; set; }

        [Display(Name = "רוחב הספר")]
        public int Width { get; set; }

        [Display(Name = "כמות הספרים")]
        public int Count { get; set; }

        [Display(Name = "מספר מדף")]
        public Shelf shelf { get; set; }

    }
}


