using jewelryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using jewelryStore.ViewModels;

namespace jewelryStore.Controllers
{
    public class ManagerController : Controller
    {
        //הצגה של הקבוצות והפריטים של כל קבוצה
        public IActionResult Index(int? id)
        {
            if(id != null) {
                Group group = DataLayer.Data.GroupsAllIncludes.Find(g=>g.ID==id);
                if (group != null) return View(group);
            }
             
            Group groupAll = DataLayer.Data.GroupsAllIncludes.First();
            return View(groupAll);
        }

        //הוספת קבוצה
        public IActionResult Create(int? id)
        {
            List<Group> groups = DataLayer.Data.Groups.ToList();
            if (id != null)
            {
            Group parent = groups.Find(g=>g.ID== id);
            if(parent !=null) { return View(new VMCreateGroup { Groups= groups,Parent=parent,ParentID=id.Value }); }
            }
            return View(new VMCreateGroup { Groups = groups, Parent = groups.First(),ParentID=groups.First().ID }) ;
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(VMCreateGroup VM)
        {
            Group parent = DataLayer.Data.Groups.FirstOrDefault(g => g.ID == VM.ParentID);
            if (parent != null) {
                VM.Group.SetImage = VM.GroupFile;
                parent.AddSubGroup(VM.Group);
                if(VM.Item != null||VM.Item.Name!="")
                {
                    VM.Group.AddItem(VM.Item).AddPrice(VM.Price);
                    VM.Item.addImage(VM.ItemFile);
                }
                DataLayer.Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }


}
