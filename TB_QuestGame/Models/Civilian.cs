using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Civilian : NPC, ISpeak, ILook, ISuplex
    {
        public override int ID { get; set; }
        public override int Level { get; set; }
        public override string Description { get; set; }
        public override bool Barter { get; set; }
        public List<string> Messages { get; set; }
        public List<string> Looks { get; set; }
        public List<string> Suplexes { get; set; }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        public string Look()
        {
            if (this.Looks != null)
            {
                return GetLook();
            }
            else
            {
                return "";
            }
        }

        public string Suplex()
        {
            if (this.Suplexes != null)
            {
                return GetSuplex();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        private string GetLook()
        {
            Random r = new Random();
            int lookIndex = r.Next(0, Looks.Count());
            return Looks[lookIndex];
        }

        private string GetSuplex()
        {
            Random r = new Random();
            int suplexIndex = r.Next(0, Suplexes.Count());
            return Suplexes[suplexIndex];
        }
    }
}
