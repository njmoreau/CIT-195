using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new PlayerObject
            {
                ID = 1,
                Name = "Bag of Gold",
                LocationID = 2,
                Description = "A small leather pouch filled with 10 gold",
                Type = PlayerObjectType.Treasure,
                Value = 100,
                CanInventory = true,
                IsConsumable = true,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 2,
                Name = "Crest of Oyorra",
                LocationID = 1,
                Description = "A pendant bearing the insignia of your village.",
                Type = PlayerObjectType.Treasure,
                Value = 10,
                CanInventory = true,
                IsConsumable = true,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 3,
                Name = "Mysterious Potion",
                LocationID = 3,
                Description = "A small vial containing a strage concoction... it looks unappetizing.",
                Type = PlayerObjectType.Medicine,
                Value = 150,
                CanInventory = true,
                IsConsumable = true,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 4,
                Name = "Strange Berries",
                LocationID = 3,
                Description = "Odd purple berries growing on an orange shrub. Looks edible.",
                Type = PlayerObjectType.Medicine,
                Value = 1,
                CanInventory = true,
                IsConsumable = true,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 5,
                Name = "Ancient Tome",
                LocationID = 1,
                Description = "It's a piece of thin parchment with writing on it." + "\n" + 
                 "You cannot comprehend what it says, but it seems to show the location of a hidden room.",
                Type = PlayerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 6,
                Name = "Water",
                LocationID = 2,
                Description = "Water from the river. It appeas to be glowing green. If you had a bucket, you'd be able to carry some.",
                Type = PlayerObjectType.Medicine,
                Value = 0,
                CanInventory = false,
                IsConsumable = true,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 8,
                Name = "Sigil of Tracking",
                LocationID = 0,
                Description = "A magical artifact that tracks your location.",
                Type = PlayerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisable = true
            },

            new PlayerObject
            {
                ID = 9,
                Name = "Hardtack",
                LocationID = 0,
                Description = "A cheap, cracker-like food. Does not look very tasty.",
                Type = PlayerObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisable = true
            },
        };
    }
}
