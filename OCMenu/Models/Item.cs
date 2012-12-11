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
        public Dictionary<string, string> properties { get; set; }

        public Item()
        {
            properties = new Dictionary<string, string>();
        }
        

        public Item(String name)
        {
            itemName = name;
            foodName = name;
            properties = new Dictionary<string, string>();
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
                    if (propName == "foodServingSize")
                        propName = "Serving Size";
                    else if (propName == "foodCalories")
                        propName = "Calories";
                    else if (propName == "foodFat")
                        propName = "Fat";
                    else if (propName == "foodCholestorol")
                        propName = "Cholesterol";
                    else if (propName == "foodSodium")
                        propName = "Sodium";
                    else if (propName == "foodPotassium")
                        propName = "Potassium";
                    else if (propName == "foodCarbhyrate")
                        propName = "Carbohydrates";
                    else if (propName == "foodProtein")
                        propName = "Protein";

                    properties.Add(propName, amount);
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