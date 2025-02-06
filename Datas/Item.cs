using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public class Item
    {
        public string name;
        public string description;
        public int value;
        public int price;

        public Item(string name, string description, int value, int price) 
        {
            this.name = name;
            this.description = description;
            this.value = value;
            this.price = price;
        }

        
    }
    public class Weapon : Item
    {
        public Weapon(string name, string description, int value, int price) : base(name, description, value, price)
        {
        }
    }

    public class Armor : Item
    {
        public Armor(string name, string description, int value, int price) : base(name, description, value, price)
        {
        }
    }
}

