using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    internal class Game
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public DateTime Date { get; set; }
        public string Board { get; set; }
    }
}
