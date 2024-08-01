using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Shelf
    {
            [Key]
            public int Id { get; set; }

            [Display(Name = "מספר מדף")]
            public int numShelf { get; set; }

            [Display(Name = "גובה המדף")]
            public int height { get; set; }

            [Display(Name = "רוחב המדף")]
            public int width { get; set; }
            public LibraryModel library { get; set; }
            public List<Books> Books { get; set; } = new List<Books>();

    }
}


