using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Model;

namespace Server.Pages
{
    public class QueriesModel : PageModel
    {
        private readonly ServerContext _usersServerContext;
        private readonly ServerContext1 _gamesServerContext;

        public QueriesModel(ServerContext usersServerContext, ServerContext1 gamesServerContext)
        {
            _usersServerContext = usersServerContext;
            _gamesServerContext = gamesServerContext;
        }
        [BindProperty]
        public TblUsers User { get; set; }
        [BindProperty]
        public TblGames Game { get; set; }
        public IList<TblUsers> PlayersList { get; set; }
        [BindProperty(SupportsGet = true)]
        public IList<TblGames> GamesList { get; set; }
        public SelectList PlayersNames { get; set; }
        [BindProperty(SupportsGet = true)]
        public IList<TblUsers> DescPlayers { get; set; }
        [BindProperty(SupportsGet = true)]
        public TblUsers SelectedUser { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedUserName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }
        [BindProperty(SupportsGet = true)]
        public int GameID { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<TblGames> PlayerGames { get; set; }

        public IList<TblUsers> SortAscPlayers { get; set; }

        public IList<TblUsers> SortDescPlayers { get; set; }

        public IList<TblGames> gamesWithoutDuplicate { get; set; }


       public IList<userWithDate> playersWithLastGamesPlay { get; set; }

        public string Name { get; set; }

        public DateTime date { get; set; }

        public IList<DateTime> allDates { get; set; }


        public async Task OnGetAsync()
        {
            var query = from m in _usersServerContext.TblUsers
                        select m.Name;
            
            if (!string.IsNullOrEmpty(SelectedUserName))
            {
                SelectedUser = await _usersServerContext.TblUsers.FirstOrDefaultAsync(s => s.Name == SelectedUserName);
            }
            PlayersNames = new SelectList(await query.ToListAsync());
            PlayersList = await _usersServerContext.TblUsers.ToListAsync();
            GamesList = await _gamesServerContext.TblGames.ToListAsync();
            SortAscPlayers = PlayersList.OrderBy(p => p.Name.ToLower()).ToList();
            SortDescPlayers = PlayersList.OrderByDescending(p => p.Name.ToLower()).ToList();
            DescPlayers = PlayersList.OrderByDescending(p => p.NumOfGames).ToList();
            gamesWithoutDuplicate = GamesList.Distinct(new myEq()).ToList();
            playersWithLastGamesPlay = Q().ToList();
           playersWithLastGamesPlay = playersWithLastGamesPlay.OrderByDescending(an => an.Name.Trim(), StringComparer.Ordinal).ToList();
            foreach (TblGames g in GamesList)
            {
                if (g.UserId == SelectedUser.Id)
                {
                    PlayerGames.Add(g);
                }
            }
            
        }

        public IList<userWithDate>Q()
        {
            var x =
                 from g in GamesList
                 group g by g.UserName into p
                 select new userWithDate { Name = p.Key, date = p.Max(p=>p.Date) };
            return x.ToList();
        }
    

        public async Task OnGetPlayerAsync(string SelectedUserName)
        {

            if (SelectedUserName == null)
            {
                Console.WriteLine("No Selected UserName");
            }

            SelectedUser = await _usersServerContext.TblUsers.FirstOrDefaultAsync(s => s.Name == SelectedUserName);

            if (SelectedUser == null)
            {
                Console.WriteLine("User not found");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }

            User = await _usersServerContext.TblUsers.FindAsync(UserID);

            if (User != null)
            {
                _usersServerContext.TblUsers.Remove(User);
                await _usersServerContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostGameDeleteAsync(int? GameID)
        {
            if (GameID == null)
            {
                return NotFound();
            }

            Game = await _gamesServerContext.TblGames.FindAsync(GameID);

            if (User != null)
            {
                _gamesServerContext.TblGames.Remove(Game);
                await _gamesServerContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _usersServerContext.Attach(User).State = EntityState.Modified;

            try
            {
                await _usersServerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage();
        }

        private bool UserExists(int id)
        {
            return _usersServerContext.TblUsers.Any(e => e.Id == id);
        }
    }

    
    internal class myEq : IEqualityComparer<TblGames>
    {
        public bool Equals(TblGames game1, TblGames game2)
        {
            return game1.UserId == game2.UserId;
        }
        public int GetHashCode(TblGames game)
        {
            return game.UserId.GetHashCode();

        }
    }
    public class userWithDate
    {
        public string Name { get; set; }
        public DateTime date { get; set; }
    }
}
