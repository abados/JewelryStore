using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace jewelryStore.Models
{
    public class Group
    {
        public Group() {
            SubGroups = new List<Group>();
            Items = new List<Item>();
        }

        [Key]
        public int ID { get; set; }

        [Required, Display(Name="שם קבוצה")]
        public string Name { get; set;  }

        [ Display(Name = "תאור")]
        public string Description { get; set; }

        [Display(Name="תמונה")]
        public byte[] Image { get; set; }

        public Group Parent { get; set; }

        public List<Group> SubGroups { get; set; }

        public List<Item> Items { get; set; }




        //פונקציה של הוספת תת קבוצה
        public Group AddSubGroup(string name)
        {
            Group group = new Group { Name = name, Parent = this };
            return AddSubGroup(group);
        }
        public Group AddSubGroup(string name, string description)
        {
            Group group = new Group { Name = name, Description = description, Parent = this };
            return AddSubGroup(group);
        }
        public Group AddSubGroup(string name, string description,IFormFile image)
        {
            Group group = new Group { Name = name, Description = description, SetImage = image, Parent = this };
            return AddSubGroup(group);
        }
        public Group AddSubGroup(Group subGroup)
        {
            SubGroups.Add(subGroup);
            return subGroup;
        }
        //פונקציה של הוספת פריט
        public Item AddItem(string name, string description, decimal price,DateTime start,DateTime end, IFormFile image)
        {
            Item item = new Item { Name = name, Description = description,Group=this };
            item.AddPrice(price);
            item.addImage(image);
            return AddItem(item);
        }
        public Item AddItem(string name, string description, decimal price, List<IFormFile> images)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price);
            foreach (IFormFile image in images)
            {
                item.addImage(image);
            }
            return AddItem(item);
        }

        public Item AddItem(string name, string description, decimal price)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price);
            return AddItem(item);
        }
        public Item AddItem(Item item)
        {
            Items.Add(item);
            return item;
        }
        


        //פונקציה של הכנסת תמונה
        public IFormFile SetImage
        {
            set
            {
                if (value == null) return;
                MemoryStream stream = new MemoryStream();
                value.CopyTo(stream);
                Image = stream.ToArray();
            }
        }
    }


}

