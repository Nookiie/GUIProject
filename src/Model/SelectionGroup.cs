using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class SelectionGroup
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int numberOfShapes;
        public int NumberOfShapes
        {
            get { return numberOfShapes; }
            set { numberOfShapes = value; }
        }

        private List<Shape> selections;
        public List<Shape> Selections
        {
            get { return selections; }
            set { selections = value; }
        }

        public SelectionGroup(string name, List<Shape> selections)
        {
            this.Name = name;
            this.NumberOfShapes = Selections.Count;
            this.Selections = selections;
        }
    }
}