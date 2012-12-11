using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMenu.Models
{
    public class Line
    {
        public String lineName { get; set; }
        public List<Item> items { get; set; }

        public Line(String name, List<Item> allItems)
        {
            items = allItems;
            lineName = name;
        }

        public Line(String name)
        {
            lineName = name;
            items = new List<Item>();
        }

        public Line()
        {
            items = new List<Item>();
        }

        public void Add(Item i)
        {
            items.Add(i);
        }
    }
}