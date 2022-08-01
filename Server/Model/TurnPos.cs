using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Server.Model
{
    public class TurnPos
    {
        public int x { get; set; }
        public int y { get; set; }
        public int status { get; set; }


        public List<(int, int)> CheckPossibleSteps(dynamic data)
        {
            var annonymousObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Convert.ToString(data));
            List<(int, int)> freePos = new List<(int, int)>();
            for (int x = 0; x < annonymousObject.board.Count; x++)
            {
                for (int y = 0; y < annonymousObject.board.Count; y++)
                {
                    if (annonymousObject.board[x][y] == 3)
                    {
                        freePos.Add((x, y));
                    }
                }
            }
            return freePos;
        }
    }
}
    

