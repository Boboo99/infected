using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace Infected_Shop
{
    class ShopInventory
    {
        private List<Item> _itemList = new List<Item>();
             
        public void AddItem(Item i)
        {
            _itemList.Add(i);
        }   

        public void RemoveItem(Item i)
        {
            _itemList.Remove(i);
        }

        public bool Contains(string nameOfItem)
        {
            bool Contains = false;
            foreach (Item x in _itemList)
            {
                if (x.Name == nameOfItem)
                {
                    Contains = true;
                    break;
                }
            }
            return Contains;
        }

        public Item GetItem(string nameOfItem)
        {
            Item i = null;
            foreach (Item x in _itemList)
            {
                if (x.Name == nameOfItem)
                {
                    i = x;
                    break;
                }
            }
            return i;
        }

        private void BuyingAlgorithmus(Entity e,Item i)
        {
            if (e.GetMoney() >= i.Price)
            {
                e.RemoveMoney(i.Price);
                e.IPrintLnBold("^2You bought the item:" + i.Name);
                i.Action.Invoke(e);
            }
            else
            {
                e.IPrintLnBold("^1Not enough money to buy the item:" + i.Name);
            }
            HudHandler.UpdateHudMoney(e);
        }

        public void Buy(Entity e,Item i)
        {
            if(i.ItemTeam == Enums.ItemTeam.BOTH)
            {
                BuyingAlgorithmus(e, i);
            }
            else if(i.ItemTeam == Enums.ItemTeam.ALLIES)
            {
                if(e.GetTeam() == Enums.PlayerTeam.AXIS)
                {
                    e.IPrintLnBold("^1You are not allowed to buy the item:" + i.Name);
                    return;
                }
                BuyingAlgorithmus(e, i);
            }
            else if(i.ItemTeam == Enums.ItemTeam.AXIS)
            {
                if(e.GetTeam() == Enums.PlayerTeam.ALLIES)
                {
                    e.IPrintLnBold("^1You are not allowed to buy the item: " + i.Name);
                    return;
                }
                BuyingAlgorithmus(e, i);
            }
            return;
        }

        public void ShowItems(Entity e)
        {
            int i = 0;
            Enums.ItemTeam PlayerTeamAsItemTeam;

            if (e.GetTeam() == Enums.PlayerTeam.ALLIES)
                PlayerTeamAsItemTeam = Enums.ItemTeam.ALLIES;
            else if (e.GetTeam() == Enums.PlayerTeam.AXIS)
                PlayerTeamAsItemTeam = Enums.ItemTeam.AXIS;
            else
            {
                e.IPrintLnBold("^1You can't see the items without joining the game");
                return;
            }


            e.OnInterval(1500, ent =>
            {
                if (i == _itemList.Count)
                    return false;

                if(_itemList[i].ItemTeam == Enums.ItemTeam.BOTH)
                {
                    Utilities.RawSayTo(ent,"^1Item:^8" + _itemList[i].Name + " ^3Price: ^4" + _itemList[i].Price);
                }
                else if(_itemList[i].ItemTeam == PlayerTeamAsItemTeam)
                {
                    Utilities.RawSayTo(ent, "^1Item:^8" + _itemList[i].Name + " ^3Price: ^4" + _itemList[i].Price);
                }
                i++;
                return true;
            });
        }


    }
}
