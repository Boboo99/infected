using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace Infected_Shop
{
    class Item
    {
        public int Price
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public Action<Entity> Action
        {
            get;
            private set;
        }

        public Enums.ItemTeam ItemTeam
        {
            get;
            private set;
        }

        public Item(string _name,int _price, Enums.ItemTeam _itemTeam,Action<Entity> _action)
        {
            Price = _price;
            Name = _name;
            Action = _action;
            ItemTeam = _itemTeam;
        }

    }
}
