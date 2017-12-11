using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        MissionSetup,
        LookAround,
        Travel,

        PlayerMenu,
        PlayerInfo,
        Inventory,
        LocationsVisited,

        ObjectMenu,
        LookAt,
        PickUp,
        PutDown,

        NonPlayerCharacterMenu,
        TalkTo,
        LookAtNPC,
        Suplex,

        AdminMenu,
        ListLocations,
        ListGameObjects,
        ListNonPlayerCharacters,

        ReturnToMainMenu,
        Exit
    }
}
/*
PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,

            PlayerInventory,
        PlayerTreasure,

            ListLocations,
    ListItems,
        ListTreasures,
        */