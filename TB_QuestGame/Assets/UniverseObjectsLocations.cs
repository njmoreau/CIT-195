using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static partial class UniverseObjects
    {
        public static List<Location> Locations = new List<Location>()
        {
            new Location
            {
                CommonName = "Oyorra Village",
                LocationID = 1,
                UniversalDate = 131,
                UniversalLocation = "Civilization",
                Description = "The village of Oyorra lies on the Southern edge of the continent " +
                    "with the Illiac Sea several miles further South and the port town of " +
                    "Dorna far to the East. \n\nNearby to the West is a large river, which now lies polluted.\n" +
                    "\n" +
                    "To the North is the expansive woodland, where most wild game has disappeared, and what\n" +
                    "creatures remain are cursed.",
                GeneralContents = "Lookin round the village.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "River Valley",
                LocationID = 2,
                UniversalDate = 131,
                UniversalLocation = "Oyorran Wildlands",
                Description = "The river was a common destination for fishers.",
                GeneralContents = "Lookin round the valley.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Cursed Forest",
                LocationID = 3,
                UniversalDate = 131,
                UniversalLocation = "Oyorran Wildlands",
                Description = "The forest was a common destination for hunters.",
                GeneralContents = "Lookin round the forest.",
                Accessable = true,
                ExperiencePoints = 20
            },

            new Location
            {
                CommonName = "Ancient Ruins - Exterior",
                LocationID = 4,
                UniversalDate = 131,
                UniversalLocation = "Exterior of Ruins",
                Description = "Ancient ruins. They look pretty old.",
                GeneralContents = "Lookin round the outside of the ruins.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Ancient Ruins - Interior",
                LocationID = 5,
                UniversalDate = 131,
                UniversalLocation = "Exterior of Ruins",
                Description = "Ancient ruins. They look pretty old.",
                GeneralContents = "Lookin round the outside of the ruins.",
                Accessable = false,
                ExperiencePoints = 10
            }
        };
    }
}
