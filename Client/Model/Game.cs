using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public DateTime Date { get; set; }
        public int Board { get; set; }
        public string GameID { get; set; }

    }
}
