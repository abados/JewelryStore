﻿using System.ComponentModel.DataAnnotations;

namespace jewelryStore.Models
{
    public class Item
    {
        public Item() {
        
            Images = new List<Image>();
            Prices = new List<Price>();
        }
        [Key]
        public int Id { get; set; }

        [Required,Display(Name="שם פריט")]
        public string Name { get; set; }

        [Required, Display(Name = "תיאור פריט")]
        public string Description { get; set; }

        public Group Group { get; set; }

        public List<Image> Images { get; set; }

        public List<Price> Prices { get; set; }

        //פונקציה של הוספת תמונה

        public void addImage(IFormFile file)
        {
            if (file == null) return;
            Images.Add(new Image { Item = this,SetImage=file }) ;
        }



        //פונקציה של הוספת מחיר
        public Price AddPrice(decimal myPrice)
        {
          return AddPrice(new Price { MyPrice= myPrice });
        }
        public Price AddPrice(decimal myPrice,DateTime end)
        {
            return AddPrice(new Price { MyPrice = myPrice, End=end });
        }
        public Price AddPrice(decimal myPrice, DateTime start, DateTime end)
        {
            return AddPrice(new Price { MyPrice = myPrice,Start=start, End = end });
        }
        public Price AddPrice(Price price)
        {
            Prices.Add(price);
            return price;
        }
    }
}
