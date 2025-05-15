using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Services
{
    public class MovieHub : Hub
    {
        private static int _movieCount = 0; 

        public async Task GetMovieCount()
        {
            await Clients.All.SendAsync("ReceiveMovieCount", _movieCount);
        }

        public async Task AddMovie()
        {
            _movieCount++;
            await Clients.All.SendAsync("ReceiveMovieCount", _movieCount);
        }
    }
}
