using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwiaciarnia
{
    internal class Flower
    {
        public int flowerId { get; set; }

        private string name;
        private double price;

        public string Name { get { return name; } set { name = value; } }

        public double Price { get { return price; } set { price = value; } }

        public Flower() { }

        public Flower(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}