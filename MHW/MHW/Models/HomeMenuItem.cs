using System;
using System.Collections.Generic;
using System.Text;

namespace MHW.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Database
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
