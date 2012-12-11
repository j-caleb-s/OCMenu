using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace OCMenu.Models
{
    public class Cafeteria
    {
        //public Meal breakfast;
        //public Meal lunch;
        //public Meal dinner;

        public Cafeteria()
        {
            //int a = 3;
        }

        public void readXML()
        {
            //Read Breakfast, lunch, or dinner.

            string breakURL = "http://otmobapp.com/udapp/API_s/Breakfast.xml";

            XmlDocument breakDoc = new XmlDocument();
            breakDoc.Load(breakURL);

            Meal breakfast = new Meal("Breakfast");

            XmlNode LineNode =
                breakDoc.SelectSingleNode("/Breakfast");

            XmlNodeList ListNodeList = LineNode.SelectNodes("Line");
            readLines(ListNodeList, breakfast);
            //Finished Reading Breakfast.
            
            //Start reading lunch
            string lunchURL = "http://otmobapp.com/udapp/API_s/Lunch.xml";

            XmlDocument lunchDoc = new XmlDocument();
            lunchDoc.Load(lunchURL);

            Meal lunch = new Meal("Lunch");

            XmlNode lunchLineNode =
                lunchDoc.SelectSingleNode("/Lunch");

            XmlNodeList lunchListNodeList = lunchLineNode.SelectNodes("Line");
            readLines(lunchListNodeList, lunch);
            //End Reading Lunch

            //Start Reading Dinner.
            string dinnerURL = "http://otmobapp.com/udapp/API_s/Dinner.xml";

            XmlDocument dinnerDoc = new XmlDocument();
            dinnerDoc.Load(dinnerURL);

            Meal dinner = new Meal("Dinner");

            XmlNode dinnerLineNode =
                dinnerDoc.SelectSingleNode("/Dinner");

            XmlNodeList dinnerListNodeList = dinnerLineNode.SelectNodes("Line");
            readLines(dinnerListNodeList, dinner);

            int b = 3;
            //foreach 

        }

        public void readLines(XmlNodeList ListNodeList, Meal m)
        {
            foreach (XmlNode lnode in ListNodeList)
            {
                Line line = new Line(lnode.SelectSingleNode("LineName").InnerText);
                m.lines.Add(line);

                XmlNodeList ItemNodeList = lnode.SelectNodes("item");
                //XmlNode ItemNodeList = ItemNode.SelectNodes("items");

                foreach (XmlNode node in ItemNodeList)
                {
                    Item i = new Item();
                    XmlNodeList properties = node.ChildNodes;
                    foreach (XmlNode pNode in properties)
                    {
                        //i.itemName = node.SelectSingleNode("itemName").InnerText;
                        //i.foodName = node.SelectSingleNode("foodName").InnerText;
                        //i.addProperty(node.SelectSingleNode("foodServingSize").Name, node.SelectSingleNode("foodServingSize").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodCalories").Name, node.SelectSingleNode("foodCalories").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodFat").Name, node.SelectSingleNode("foodFat").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodCholesterol").Name, node.SelectSingleNode("foodCholesterol").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodSodium").Name, node.SelectSingleNode("foodSodium").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodPotassium").Name, node.SelectSingleNode("foodPotassium").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodCarbhyrate").Name, node.SelectSingleNode("foodCarbhyrate").InnerText);
                        //i.addProperty(node.SelectSingleNode("foodProtein").Name, node.SelectSingleNode("foodProtein").InnerText);
                        i.addProperty(pNode.Name, pNode.InnerText);
                        //i.properties.Add(ItemNode.Name, ItemNode.InnerText);
                    }
                    line.Add(i);
                }
            }
        }

    }
}