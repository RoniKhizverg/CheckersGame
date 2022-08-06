using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Model
{
    public class TblGames
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Winner { get; set; }

        public int UserId { get; set; }
        public int DurationGame { get; set; }
        [Display(Name="Player Name")]
        public string UserName { get; set; }

    }
}
