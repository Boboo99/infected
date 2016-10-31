using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace Infected_Shop
{
    class HudHandler
    {
        private static Dictionary<int, HudElem> _hudDicMoney = new Dictionary<int, HudElem>();
        private static Dictionary<int, HudElem> _hudDicHealth = new Dictionary<int, HudElem>();
        public static void CreateHud(Entity e)
        {
            HudElem h_money = HudElem.CreateFontString(e,"hudsmall", 0.9f);
            HudElem h_health = HudElem.CreateFontString(e, "hudsmall", 0.9f);

            h_money.SetText("^1Money:" + e.GetMoney());
            h_health.SetText("^1Health: " + e.Health);

            h_money.SetPoint("topright","topright", -2);
            h_health.SetPoint("topright","topright", -2,20);

            if (_hudDicMoney.ContainsKey(e.EntRef))
                _hudDicMoney.Remove(e.EntRef);
            if (_hudDicHealth.ContainsKey(e.EntRef))
                _hudDicHealth.Remove(e.EntRef);

            _hudDicMoney.Add(e.EntRef, h_money);
            _hudDicHealth.Add(e.EntRef, h_health);
        }

        public static void UpdateHudMoney(Entity e)
        {
            _hudDicMoney[e.EntRef].SetText("^1Money:" + e.GetMoney().ToString());
        }

        public static void UpdateHudHealth(Entity e)
        {
            _hudDicHealth[e.EntRef].SetText("^1Health: " + e.Health);
        }

        public static void CreateFlyingScore(Entity e,int score)
        {
            HudElem h = HudElem.CreateFontString(e, "hudsmall", 1.0f);
            h.Call("setvalue", score);
            h.SetField("x", 640 / 2);
            h.SetField("y", 480 / 2);
            h.Call("moveovertime", 1f);
            h.SetField("x", 640);
            h.SetField("y", 0);
            e.AfterDelay(1000, ent =>
             {
                 h.Call("destroy");
                 UpdateHudMoney(e);
             });

        }
    }
}
