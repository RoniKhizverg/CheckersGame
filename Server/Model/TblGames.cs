using System;

namespace Server.Model
{
    public class TblGames
    {
        public int id { get; set; }
        public string Winner { get; set; }

        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int DurationGame { get; set; }
    }
}
