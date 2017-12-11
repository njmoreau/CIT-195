using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    interface ISuplex
    {
        List<string> Suplexes { get; set; }
        string Suplex();
    }
}
