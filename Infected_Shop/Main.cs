using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
using System.IO;

/*
 * Wanted to take a note that IS 1.0 is messed up as hell and I had to use some "non-beautiful" approaches because it was bugging too bad
 * */
namespace Infected_Shop
{
    public class InfectedShop : BaseScript
    {
        ShopInventory Shop = new ShopInventory();
        InfectedBank Bank = new InfectedBank();
        public InfectedShop() : base()
        {
            //Init the bank
            Bank.ReadFromFile();
            //la le lu
            Shop.AddItem(new Item("speed", 500, Enums.ItemTeam.AXIS, (Entity) => { Entity.Call("setmovespeedscale", 2); }));
            Shop.AddItem(new Item("javelin", 2700, Enums.ItemTeam.BOTH, (Entity) => { Entity.GiveWeapon("javelin_mp"); }));
            Shop.AddItem(new Item("jugg", 2500, Enums.ItemTeam.AXIS, (Entity) => { Entity.Health += 1000; }));
            Shop.AddItem(new Item("riot", 200, Enums.ItemTeam.AXIS, (Entity) => { Entity.GiveWeapon("riotshield_mp"); }));
            //Primary
            Shop.AddItem(new Item("acr", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_acr_mp_camo11"); }));
            Shop.AddItem(new Item("ak47", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_ak47_mp_camo11"); }));
            Shop.AddItem(new Item("m16", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_m16_mp_camo11"); }));
            Shop.AddItem(new Item("fad", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_fad_mp_camo11"); }));
            Shop.AddItem(new Item("type95", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_type95_mp_camo11"); })); ;
            Shop.AddItem(new Item("mk14", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mk14_mp_camo11"); }));
            Shop.AddItem(new Item("scar", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_scar_mp_camo11"); }));
            Shop.AddItem(new Item("g36c", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_g36c_mp_camo11"); }));
            Shop.AddItem(new Item("cm901", 1000, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_cm901_mp_camo11"); }));
            //Sub Machine Guns
            Shop.AddItem(new Item("mp5", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mp5_mp_camo11"); }));
            Shop.AddItem(new Item("mp7", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mp7_mp_camo11"); }));
            Shop.AddItem(new Item("pm9", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_m9_mp_camo11"); }));
            Shop.AddItem(new Item("p90", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_p90_mp_camo11"); }));
            Shop.AddItem(new Item("pp90m1", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_pp90m1_mp_camo11"); }));
            Shop.AddItem(new Item("cm901", 500, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_ump45_mp_camo11"); }));
            //snipers
            Shop.AddItem(new Item("barrett", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_barrett_mp_barrettscope"); }));
            Shop.AddItem(new Item("rsass", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_rsass_mp_rsassscope"); }));
            Shop.AddItem(new Item("dragunov", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_dragunov_mp_dragunovscope"); }));
            Shop.AddItem(new Item("l96a1", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_l96a1_mp_l96a1scope"); }));
            Shop.AddItem(new Item("as50", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_as50_as50scope"); }));
            Shop.AddItem(new Item("msr", 800, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_msr_mp_msrscope"); }));
            //Shotguns
            Shop.AddItem(new Item("ksg", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_ksg_mp_camo11"); }));
            Shop.AddItem(new Item("1887", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_1887_mp_camo11"); }));
            Shop.AddItem(new Item("striker", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_striker_mp_camo11"); }));
            Shop.AddItem(new Item("aa12", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_aa12_mp_camo11"); }));
            Shop.AddItem(new Item("usas12", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_usas12_mp_camo11"); }));
            Shop.AddItem(new Item("spas12", 200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_spas12_mp_camo11"); }));
            //Light Machine Guns
            Shop.AddItem(new Item("m60", 1200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_m60_mp_camo11"); }));
            Shop.AddItem(new Item("mk46", 1200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mk46_mp_camo11"); }));
            Shop.AddItem(new Item("pecheneg", 1200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_pecheneg_mp_camo11"); }));
            Shop.AddItem(new Item("sa80", 1200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_sa80_mp_camo11"); }));
            Shop.AddItem(new Item("mg36", 1200, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mg36_mp_camo11"); }));
            //Pistols
            Shop.AddItem(new Item("44magnum", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_44magnum_mp"); }));
            Shop.AddItem(new Item("uso45", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_usp45_mp"); }));
            Shop.AddItem(new Item("deserteagle", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_deserteagle_mp"); }));
            Shop.AddItem(new Item("mp412", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mp412_mp"); }));
            Shop.AddItem(new Item("p99", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_p99_mp"); }));
            Shop.AddItem(new Item("fiveseven", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_fnfiveseven_mp"); }));
            //Machine Pistols
            Shop.AddItem(new Item("g18", 300, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_g18_mp"); }));
            Shop.AddItem(new Item("g18akimbo", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_g18_mp_akimbo"); }));
            Shop.AddItem(new Item("fmg9", 300, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_fmg9_mp"); }));
            Shop.AddItem(new Item("fmg9akimbo", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_fmg9_mp_akimbo"); }));
            Shop.AddItem(new Item("mp9", 300, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mp9_mp"); }));
            Shop.AddItem(new Item("mp9akimbo", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_mp9_mp_akimbo"); }));
            Shop.AddItem(new Item("skorpion", 300, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_skorpion_mp"); }));
            Shop.AddItem(new Item("skorpionakimbo", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("iw5_skorpion_mp_akimbo"); }));
            //Launchers
            Shop.AddItem(new Item("xm25", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("xm25_mp"); }));
            Shop.AddItem(new Item("rpg", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("rpg_mp"); }));
            Shop.AddItem(new Item("javelin", 350, Enums.ItemTeam.ALLIES, (Entity) => { Entity.GiveWeapon("javelin_mp"); }));
            //perks 1
            Shop.AddItem(new Item("sprint", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_longersprint", true, true); }));
            Shop.AddItem(new Item("fastreload", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_fastreload", true, true); }));
            Shop.AddItem(new Item("scavenger", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_scavenger", true, true); }));
            Shop.AddItem(new Item("blindeye", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_blindeye", true, true); }));
            Shop.AddItem(new Item("paint", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_paint", true, true); }));
            //Perks 2
            Shop.AddItem(new Item("hardline", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_hardline", true, true); }));
            Shop.AddItem(new Item("coldblooded", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_coldblooded", true, true); }));
            Shop.AddItem(new Item("quickdraw", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_quickdraw", true, true); }));
            Shop.AddItem(new Item("assists", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_assists", true, true); }));
            Shop.AddItem(new Item("blastshield", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_blastshield", true, true); }));
            //perks 3
            Shop.AddItem(new Item("detectexplosive", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_detectexplosive", true, true); }));
            Shop.AddItem(new Item("autospot", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_autospot", true, true); }));
            Shop.AddItem(new Item("bulletaccuracy", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_bulletaccuracy", true, true); }));
            Shop.AddItem(new Item("quieter", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_quieter", true, true); }));
            Shop.AddItem(new Item("stalker", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.SetPerk("specialty_stalker", true, true); }));
            //Equipement
            //Special
            Shop.AddItem(new Item("ammo", 100, Enums.ItemTeam.ALLIES, (Entity) => { Entity.Call("givemaxammo", Entity.CurrentWeapon); }));
            Shop.AddItem(new Item("hp", 500, Enums.ItemTeam.BOTH, (Entity) => { Entity.Health += 100; }));
            Shop.AddItem(new Item("riot", 200, Enums.ItemTeam.BOTH, (Entity) => { Entity.GiveWeapon("riotshield_mp"); }));
            PlayerConnected += InfectedShop_PlayerConnected;
            PlayerDisconnected += InfectedShop_PlayerDisconnected;
        }

        private void InfectedShop_PlayerDisconnected(Entity obj)
        {
            Bank.AddEntry(obj);
        }

        private void InfectedShop_PlayerConnected(Entity obj)
        {
            if (!Bank.GetEntry(obj))
            {
                File.AppendAllText("PlayerConnected_Dump.txt", obj.Name + "|" + obj.GUID + "|" + obj.GetMoney() + "| Does not contain" + Environment.NewLine);
                obj.SetMoney(1000);
            }

            HudHandler.CreateHud(obj);
            obj.OnInterval(100, ent =>
            {
                HudHandler.UpdateHudHealth(ent);
                return true;
            });
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            if (!message.StartsWith("/"))
                return EventEat.EatNone;

            if (message.ToLower().StartsWith("/b"))
            {
                string[] splitmsg = message.Split(' ');
                if (splitmsg.Length <= 1)
                {
                    Utilities.RawSayTo(player, "!buy <item>");
                    return EventEat.EatGame;
                }

                if (!Shop.Contains(splitmsg[1]))
                {
                    player.IPrintLnBold("^1Item was not found use /showshop to show all items");
                    return EventEat.EatGame;
                }
                Shop.Buy(player, Shop.GetItem(splitmsg[1]));
            }
            else if (message.ToLower().StartsWith("/showshop"))
            {
                Shop.ShowItems(player);
            }
            return EventEat.EatGame;
        }

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {

            if (player == attacker) //Checking if the player isn't suiciding
                return;


            if (attacker.GetTeam() == Enums.PlayerTeam.ALLIES)
            {
                if (hitLoc == "j_head") //if the human kills with headshots 200$
                {
                    attacker.AddMoney(200);
                    HudHandler.CreateFlyingScore(attacker, 200);
                }
                else //100$ for the human
                {
                    attacker.AddMoney(100);
                    HudHandler.CreateFlyingScore(attacker, 100); //Updating the hud in the CreateFlyingHud to sync it
                }
            }

            if (player.GetTeam() == Enums.PlayerTeam.AXIS) //If a zombie dies give him 50$
            {
                player.AddMoney(50); //adding 50$
                HudHandler.UpdateHudMoney(player); //Updating the hud
            }

        }

        ~InfectedShop()
        {
            Bank.SaveToFile();
        }
    }
}
