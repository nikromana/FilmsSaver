using Application.Queries.Login;
using FilmsSaverDbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Model;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.Queries.SaveFilm
{
    public class SaveFilmsQueryHandler(OmdbApiService _omdbApi, 
        UserManager<User> _userManager,
        UserContextService _userContextService,
        FilmsSaverDbContext.FilmsSaverDbContext _context,
        IHubContext<MovieHub> _hubContext ) : IRequestHandler<SaveFilmQuery, ResponceResultBase>
    {
        public async Task<ResponceResultBase> Handle(SaveFilmQuery request, CancellationToken cancellationToken)
        {
            var result = new ResponceResultBase();

            try
            {
                var film = await _omdbApi.SearchFilms(request.FilmName);

                if (film.HasErrors())
                {
                    result.Errors = film.Errors;
                    return result;
                }
                var parsedFilm = film.Films;

                var userId = _userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var existedUser = await _userManager.FindByIdAsync(userId);

                existedUser.SavedFilms.Add(parsedFilm);

                await _context.SaveChangesAsync(cancellationToken);

                var movieCount = existedUser.SavedFilms.Count();

                await _hubContext.Clients.All.SendAsync("", movieCount);

            }
            catch (Exception ex)
            {
                result.Errors = ex.Message;
            }

            return result;
        }
    }
}
