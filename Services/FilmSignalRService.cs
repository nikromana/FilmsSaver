using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FilmsSaverDbContext;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class MovieHub(FilmsSaverDbContext.FilmsSaverDbContext _context, UserContextService _userContextService) : Hub
    {
        private static int _movieCount = 0; 

        public async Task GetMovieCount()
        {
            var userId = _userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                await Clients.Caller.SendAsync("ReceiveMovieCount", 0);
                return;
            }

            var count = await _context.Films
                .Where(f => f.User.Id == userId)
                .CountAsync();

            await Clients.All.SendAsync("ReceiveMovieCount", _movieCount);
        }

        public async Task AddMovie()
        {
            _movieCount++;
            await Clients.All.SendAsync("ReceiveMovieCount", _movieCount);
        }

        public async Task DeleteMovie()
        {
            _movieCount--;
            await Clients.All.SendAsync("ReceiveMovieCount", _movieCount);
        }
    }
}
