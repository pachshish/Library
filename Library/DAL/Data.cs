namespace myFriends.DAL
{
    //מחלקה לניהול החברים
    public class Data
    {
        //משתנה סטטי לשמירת מופע יחיד של המחלקה
        static Data GetData;
        
        string connectionString = "" +
            "server=DESKTOP-SM9G199\\SQLEXPRESS; " +
            "initial catalog=Library ; " +
            "user id=sa ; " +
            "password=1234 ; " +
            "TrustServerCertificate=Yes ";

        //קונסטרקטור פרטי לשמירת מופע יחיד של המחלקה
        private Data()
        {
            Layer = new DataLayers (connectionString);
        }

        //מאפיין סטטי לקבלת הנתונים
        public static DataLayers Get 
        { 
            get
            {
                if (GetData == null)
                {
                    GetData = new Data ();                    
                }
                return GetData.Layer;
            }
        }

        public DataLayers Layer { get; set; }
    }
   
}
