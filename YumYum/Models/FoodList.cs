using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumYum.Models
{
    public class FoodList
    {

        //public List<FoodList> FoodType { get; set; }
        //public List<FoodList> FoodItem { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDetail { get; set; }
        public int MeatId { get; set; }
        public string MeatOpt { get; set; }
        public int FoodCateId { get; set; }
        public string FoodCate { get; set; }
        public int PriceId { get; set; }
        public int HotId { get; set; }
        public string HotOpt { get; set; } 
        public int Quantity { get; set; }
    }
}