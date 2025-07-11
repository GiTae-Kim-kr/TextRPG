using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace TextRPG
{
    internal class SaveData
    {
        public Player Player { get; set; } // 플레이어 정보
        public List<Item> Inventory { get; set; } // 플레이어 인벤토리
        //public Shop ShopItems { get; set; } // 상점 아이템 목록
        //public MainGame Game { get; set; } // 게임 정보
        //public Shop Shop { get; set; } // 상점 정보
        
        public void SaveGame(Player player, List<Item> inventory)
        {

            SaveData data = new SaveData
            {
                Player = player,
                Inventory = inventory,
                
                //Game = game,
                //Shop = shop
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("save.json", json);
            Console.WriteLine("게임이 저장되었습니다!");

        }

        public SaveData LoadGame()
        {
            if (!File.Exists("save.json"))
            {
                Console.WriteLine("저장된 게임이 없습니다.");
                return null;
            }
            string json = File.ReadAllText("save.json");
            SaveData data = JsonConvert.DeserializeObject<SaveData>(json);
            Console.WriteLine("게임을 불러왔습니다!");
            return data;
        }



    }
}
