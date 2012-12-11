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
        public Meal breakfast {get; set;}
        public Meal lunch { get; set; }
        public Meal dinner { get; set; }
        public List<Meal> meals { get; set; }

        public Cafeteria()
        {
            //int a = 3;
        }

        public void readXML()
        {
            //Read Breakfast, lunch, or dinner.
            try
            {
                string breakURL = "http://otmobapp.com/udapp/API_s/Breakfast.xml";

                XmlDocument breakDoc = new XmlDocument();
                breakDoc.Load(breakURL);

                breakfast = new Meal("Breakfast");

                XmlNode LineNode =
                    breakDoc.SelectSingleNode("/Breakfast");

                XmlNodeList ListNodeList = LineNode.SelectNodes("Line");
                readLines(ListNodeList, breakfast);
                //Finished Reading Breakfast.
            }
            catch (Exception e)
            {
                breakfast = new Meal("Breakfast Not Available");
            }
            
            //Start reading lunch
            try
            {
                string lunchURL = "Lunch.xml";

                XmlDocument lunchDoc = new XmlDocument();
                lunchDoc.Load(lunchURL);

                lunch = new Meal("Lunch");

                XmlNode lunchLineNode =
                    lunchDoc.SelectSingleNode("/Lunch");

                XmlNodeList lunchListNodeList = lunchLineNode.SelectNodes("Line");
                readLines(lunchListNodeList, lunch);
                //End Reading Lunch
            }
            catch (Exception e)
            {
                lunch = new Meal("Lunch Not Available");
            }


            try
            {
                //Start Reading Dinner.
                string dinnerURL = "http://otmobapp.com/udapp/API_s/Dinner.xml";

                XmlDocument dinnerDoc = new XmlDocument();
                dinnerDoc.Load(dinnerURL);

                dinner = new Meal("Dinner");

                XmlNode dinnerLineNode =
                    dinnerDoc.SelectSingleNode("/Dinner");

                XmlNodeList dinnerListNodeList = dinnerLineNode.SelectNodes("Line");
                readLines(dinnerListNodeList, dinner);
            }
            catch (Exception e)
            {
                dinner = new Meal("Dinner not available");
            }

            //int b = 3;
            meals = new List<Meal>();
            meals.Add(breakfast);
            meals.Add(lunch);
            meals.Add(dinner);
            //foreach 

        }

        public void readLines(XmlNodeList ListNodeList, Meal m)
        {
            foreach (XmlNode lnode in ListNodeList)
            {
                Line line;
                try
                {
                    line = new Line(lnode.SelectSingleNode("LineName").InnerText);
                    m.lines.Add(line);

                    XmlNodeList ItemNodeList = lnode.SelectNodes("item");
                    //XmlNode ItemNodeList = ItemNode.SelectNodes("items");

                    foreach (XmlNode node in ItemNodeList)
                    {
                        Item i = new Item();
                        try
                        {
                            XmlNodeList properties = node.ChildNodes;
                            foreach (XmlNode pNode in properties)
                            {
                                try
                                {
                                    i.addProperty(pNode.Name, pNode.InnerText);
                                }
                                catch (Exception e)
                                { }
                            }
                            line.Add(i);
                        }
                        catch (Exception e)
                        {
                            i.foodName = "Item Not Available";
                            i.itemName = "Item Not Available";
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

    }
}