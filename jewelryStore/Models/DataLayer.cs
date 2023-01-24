using System.Data.Entity;
using System.Text.RegularExpressions;

namespace jewelryStore.Models
{
    public class DataLayer:DbContext
    {
        private static DataLayer data;
        private DataLayer() : base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JewelryMVC;Data Source=localhost\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());

            //כאשר מסד הנתונים ריק, נפעיל את הפונקציה הזורעת
            if (Groups.Count() == 0) seed();
        }

        public static DataLayer Data
        { get
            
            {
                if(data == null) data = new DataLayer();
                return data; 
            } 
        }

        private void seed()
        {
            //קבוצה ראשית
            Group group = new Group { Name = "חנות תכשיטים" };
            Groups.Add(group);

            //מחיר ברירת מחדל
            Price price = new Price { MyPrice = 150000, End=DateTime.Now.AddYears(20) };
            Prices.Add(price);

            SaveChanges();
        }
        //פונקציה המחזירה את הקבוצות עם כל הטעינה שלהם
        public List<Group> GroupsAllIncludes
        {
            get
            {
                List<Item> items = DataLayer.data.Items.Include(i=>i.Prices).Include(i=>i.Images).Include(i=>i.Group).ToList();
                return Data.Groups.Include(g=>g.Items).Include(g=>g.SubGroups).ToList();
            }
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
