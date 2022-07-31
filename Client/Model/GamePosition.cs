using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class GamePosition
    {
        public int ID { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int status { get; set; }

        public string GameID { get; set; }

    }
}
