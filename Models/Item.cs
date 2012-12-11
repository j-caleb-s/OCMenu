using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;

namespace OCMenu.Models
{
    public class Item
    {
        public String itemName { get; set; }
        public String foodName { get; set; }
        public Dictionary<string, int> properties { get; set; }

        public Item()
        {
            properties = new Dictionary<string, int>();
        }

        public Item(String name)
        {
            itemName = name;
            foodName = name;
            properties = new Dictionary<string, int>();
        }

        public void addProperty(string propName, string amount)
        {
            if (propName == "itemName")
            {
                itemName = amount;
            }
            else if (propName == "foodName")
            {
                foodName = amount;
            }
            else if (!(amount == "Not Available" || amount == "?"))
            {
                try
                {
                    properties.Add(propName, int.Parse(amount));
                }
                catch(Exception e)
                {
                    //Do Nothing, do not add the property
                }
            }
            //Otherwise, we don't have any information on this property, so why show it?
        }

    }
}