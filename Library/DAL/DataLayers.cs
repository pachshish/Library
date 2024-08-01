using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace myFriends.DAL

{   //יצירת שכבת חיבור בין כל הקונספט שמתחברת לדאטא בייס
    //קלאס דאטאלאיירס שיורש מקלאס דאטאבייס קונטקס, שמשמש חיבור בין הדאטאביס לאפליקצייה
    public class DataLayers : DbContext
    {
        //קונסקטרקטור שמקבל את הסטרינג של החיבור לדאטא בייס ומעביר אותו לקונסטרקטור האב
        public DataLayers(string connectionString) : base(GetOptions(connectionString))
        {
            //מוודא שנוצר דאטא בייס
            Database.EnsureCreated();

            //להכניס נתונים ראשוניים לדאטא בייס
            seadToLibrary();
            //seadToBooks();
        }



        private void seadToLibrary()
        {
            //הנתונים יכנסו רק אם הטבלה ריקה
            if (Libraries.Any())
            {
                return;
            }
            LibraryModel firstLibrary = new LibraryModel
            {
                Name = "בית שוש",
                Genre = "הלכה",
            };

            firstLibrary.Shelfses = AddShelf(firstLibrary);

            Libraries.Add(firstLibrary);
            SaveChanges();
        }

        private List<Shelf> AddShelf(LibraryModel lib)
        {


            if (lib.Shelfses.Any())
            {
                return lib.Shelfses;
            }
            List<Shelf> shelves = new List<Shelf>();
            Shelf s = new Shelf();
            s.height = 20;
            s.width = 20;
            s.numShelf = 1;
            shelves.Add(s);
            return shelves;

        }

        //public void seadToBooks()
        //{
        //    if (Books.Any())
        //    {
        //        return;
        //    }
        //    Books firstBooks = new Books
        //    {
        //        Name = "שולחן ערוך",
        //        Genre = "הלכה",
        //        Height = 20,
        //        Width = 2,
        //        Count = 1,
        //        shelf = AddToShelf(),

        //    };
        //    Books.Add(firstBooks);
        //    SaveChanges();
        //}
        //private Shelf AddToShelf(Books book)
        //{

        //}


        public DbSet<LibraryModel> Libraries { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Books> Books { get; set; }



        //פונקצייה שמחזירה את האפשרויות חיבור לדאטא בייס
        //הפונקצייה מוגדרת סטטיק כדי שנוכל להשתמש איתה ללא יצירת מופע חדש של הקלאס
        public static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}

