using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;
using System.IO;

namespace Infected_Shop
{
    class InfectedBank
    {
        private Dictionary<long, int> _bankEntrys = new Dictionary<long, int>();
        private string pathFile = "Infected_Shop_Bank.txt";
        public void AddEntry(Entity e)
        {
            if (!_bankEntrys.ContainsKey(e.GUID))
                _bankEntrys.Add(e.GUID, e.GetMoney());
            else
                _bankEntrys[e.GUID] = e.GetMoney();
        }

        public bool GetEntry(Entity e)
        {
            if (_bankEntrys.ContainsKey(e.GUID))
            {
                e.SetMoney(_bankEntrys[e.GUID]);
                return true;
            }
            else
                return false;
        }

        public bool Contains(Entity e)
        {
            if (_bankEntrys.ContainsKey(e.GUID))
                return true;
            else
                return false;
        }

        public void SaveToFile()
        {
            try
            {
                File.WriteAllText(pathFile, string.Empty);
                foreach (var line in _bankEntrys)
                    File.AppendAllText(pathFile, line.Key + "|" + line.Value + Environment.NewLine);
            }
            catch(Exception e)
            {
                Log.Write(LogLevel.All, e.Message);
            }
        }

        public void ReadFromFile()
        {
            _bankEntrys.Clear();
            if (!File.Exists(pathFile))
                return;
            try
            {
                foreach(string line in File.ReadAllLines(pathFile))
                {
                    string[] tmp = line.Split('|');
                    try
                    {
                        long tmp_guid = long.Parse(tmp[0]);
                        int tmp_money = int.Parse(tmp[1]);
                        _bankEntrys.Add(tmp_guid, tmp_money);
                    }
                    catch(Exception e)
                    {
                        Log.Write(LogLevel.All, e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(LogLevel.All, e.Message);
            }
        }
    }
}
