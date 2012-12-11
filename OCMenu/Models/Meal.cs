using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMenu.Models
{
    public class Meal
    {
        public String name {get; set; }
	    public List<Line> lines {get; set; }
	
	    public Meal()
	    {
            lines = new List<Line>();
	    }

        public Meal(String name1)
        {
            name = name1;
            lines = new List<Line>();
        }
    }
}