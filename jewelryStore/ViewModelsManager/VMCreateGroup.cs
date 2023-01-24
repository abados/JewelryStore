using jewelryStore.Models;
using System.ComponentModel.DataAnnotations;

namespace jewelryStore.ViewModels
{
    public class VMCreateGroup
    {
        public VMCreateGroup()
        { 
            Group = new Group(); Groups = new List<Group>();
            Item = new Item(); Price = new Price();
            


        }

        public List<Group> Groups { get; set; }
        [Display(Name ="בחירת קבוצה")]
        public int ParentID { get; set; }
        public Group Parent { get; set; }
        public Group Group { get; set; }

        [Display(Name = "הוספת תמונה")]
        public IFormFile GroupFile { get; set; }

        public Item Item { get; set; }

        public Price Price { get; set; }
        [Display(Name = " הוספת תמונה לפריט")]
        public IFormFile ItemFile { get; set; }
     
    }
}
