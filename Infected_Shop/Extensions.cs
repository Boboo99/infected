using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
namespace Infected_Shop
{
    static class Extensions
    {
        public static int GetMoney(this Entity e)
        {
            return e.GetField<int>("inf_money");
        }

        public static void SetMoney(this Entity e,int value)
        {
            e.SetField("inf_money", value);
        }

        public static void AddMoney(this Entity e, int value)
        {
            e.SetField("inf_money", e.GetField<int>("inf_money") + value);
        }

        public static void RemoveMoney(this Entity e,int value)
        {
            e.SetField("inf_money", e.GetField<int>("inf_money") - value);
        }

        public static Enums.PlayerTeam GetTeam(this Entity e)
        {
            if (e.GetField<string>("sessionteam") == "axis")
                return Enums.PlayerTeam.AXIS;
            else if (e.GetField<string>("sessionteam") == "allies")
                return Enums.PlayerTeam.ALLIES;
            else
                return Enums.PlayerTeam.SPECTATOR;   
        }

        public static void IPrintLnBold(this Entity e,string text)
        {
            e.Call("iprintlnbold", text);
        }
    }
}
