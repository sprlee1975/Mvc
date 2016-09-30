using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootHelloWord.Models
{
    //public class Menu
    //{
    //    public Menu()
    //    {
    //        Children = new List<Menu>();
    //    }

    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public string Action { get; set; }
    //    public string Controller { get; set; }

    //    public List<Menu> Children { get; set; }
    //}

    public class Menu
    {
        public Menu()
        {
            Controller = "Home";
            Action = "Index";
        }
            

        public int MenuId { get; set; }

        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int Status { get; set; }

        public string RouteValues { get; set; }

        public int? OrderSerial { get; set; }

        //public List<Menu> Children { get; set; }
    }
}