using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<NPC> NPCs = new List<NPC>()
        {
            new Civilian
            {
                ID = 1,
                Name = "Sir Realism",
                LocationID = 2,
                Description = "An entity of oddity. An odd entity.",
                Messages = new List<string>
                {
                    "Hail, friend! What travels you this fine day?",
                    "Enjoy your walk! I hear the Brain Trees are quite docile this time of year.",
                    "Are you from the village? You certainly look the part."
                },
                Looks = new List<string>
                {
                    "You see an abstract concept.",
                    "You blink and faintly notice a man wearing a top hat and monocle."
                },
                Suplexes = new List<string>
                {
                    "You wrap your arms around Sir Realism and attempt to suplex him back into reality. \n \n You stand up, proud of your accomplishment, only to see Sir Realism proudly standing on his head."
                }
            },

            new Civilian
            {
                ID = 2,
                Name = "Brain Tree",
                LocationID = 2,
                Description = "It's a tree made of brains.",
                Messages = new List<string>
                {
                    "The tree hums at you. You question how it is doing so, and decide it is best you carry on.",
                    "As you attempt to speak to the main brain, you realize that it has no real method of communication."
                },
                Looks = new List<string>
                {
                    "It appears to be a tree... made of what appear to be brains. Looks harmless.",
                    "A strange smell assaults you... you hope it was the brain tree in front of you."
                },
                Suplexes = new List<string>
                {
                    "You can just barely wrap your arms around the tree. With all your might you attempt to lift... \n \n but no matter how hard you try, the tree does not budge."
                }
            },

            new Civilian
            {
                ID = 3,
                Name = "Villager Narg",
                LocationID = 1,
                Description = "A childhood friend of yours. A bit eccentric, but good natured.",
                Messages = new List<string>
                {
                    "Hey, how's it going?",
                    "Smells bad, man.",
                    "Check out my new hammer. Good for clobberin' Samsquanches."
                },
                Looks = new List<string>
                {
                    "It's your buddy Narg. He bows as he greets you.",
                    "A childhood friend of yours. A bit eccentric, but good natured."
                },
                Suplexes = new List<string>
                {
                    "You greet Narg with a friendly suplex, as is custom in your village. \n \n He stands, astounded by your moves."
                }
            },

            new Civilian
            {
                ID = 4,
                Name = "Warrior Chitsa",
                LocationID = 1,
                Description = "A guard for the village. She seems bored and hungry.",
                Messages = new List<string>
                {
                    "Stay out of trouble.",
                    "Somewhere there is a crime happening...",
                    "Let me know if you see anything suspicious."
                },
                Looks = new List<string>
                {
                    "A guard patrolling the village. She seems bored and hungry.",
                    "Clutching her spear, the warrior gives you a quick nod."
                },
                Suplexes = new List<string>
                {
                    "As you attempt to suplex the powerful warrior, she reverses it against you. \n \n You feel a wash of embarassment fall over you as your head hits the ground. Good job."
                }
            },

            new Civilian
            {
                ID = 5,
                Name = "Polycorn",
                LocationID = 3,
                Description = "A horse with multiple horns on its head.",
                Messages = new List<string>
                {
                    "No matter how persuasive you are, the Polycorn does not understand you."
                },
                Looks = new List<string>
                {
                    "The creature blinks at you in a threatening manner.",
                    "It's a... horse? It seems to have a lot of horns on its head."
                },
                Suplexes = new List<string>
                {
                    "You try your hardest, but you can't quite lift the Polycorn. \n \n It lets out a snort and pushes you back. You are dissapointed in both yourself and the creature."
                }
            },

            new Civilian
            {
                ID = 6,
                Name = "Daymare",
                LocationID = 3,
                Description = "A horrible being that tries it's hardest to scare travelers.",
                Messages = new List<string>
                {
                    "Who DARES trespass in MY territory?",
                    "Oh... did I give you a scare?",
                    "You hear the being let out a faint 'boo'"
                },
                Looks = new List<string>
                {
                    "The ghoul looks to you and lets out a faint wail. It looks pretty upset about something.",
                    "A ghastly image stands before you. It seems to be muttering to itself."
                },
                Suplexes = new List<string>
                {
                    "Seems to be incorporeal... You can't get a grip. \n \n ...neither on the ghost nor your own mental well-being."
                }
            },

            new Civilian
            {
                ID = 7,
                Name = "Festering Human",
                LocationID = 4,
                Description = "A zombie. Seems pretty nonplussed about his lot in life.",
                Messages = new List<string>
                {
                    "Manners seem to have left it in its old age.",
                    "The creature attempts to give you a high five, but misses spectacularly."
                },
                Looks = new List<string>
                {
                    "The zombie does not appear to have a mouth, but gives you a thumbs up! You feel encouraged.",
                    "The monster looks right back. Seems pretty chill."
                },
                Suplexes = new List<string>
                {
                    "The lightweight zombie accepts your sick moves. It does a flip midair and lands flat on its feet. \n \n You are quite impressed!"
                }
            },

            new Civilian
            {
                ID = 8,
                Name = "Gooey",
                LocationID = 4,
                Description = "It appears to be a user interface.",
                Messages = new List<string>
                {
                    "Huh? You're gonna hafta speak up, sonny.",
                    "A village? Polluted? Don't know nothin' about that, friend.",
                    "Talk with the other zombie. I'm not much for conversation. *He chuckles to himself*"
                },
                Looks = new List<string>
                {
                    "This zombie DOES have a mouth. What luck!",
                    "The monster waves you over. He looks preocupied, though."
                },
                Suplexes = new List<string>
                {
                    "Gooey doesn't seem to happy about it, but goes along anyways. \n \n He slams into the ground with a hearty thud, dusts himself off, and resumes work."
                }
            }
        };
    }
}