using Application.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Model;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.Queries.SaveFilm
{
    public class SaveFilmsQueryHandler(OmdbApiService _omdbApi, 
        UserManager<User> _userManager,
        UserContextService userContextService) : IRequestHandler<SaveFilmQuery, string>
    {
        public async Task<string> Handle(SaveFilmQuery request, CancellationToken cancellationToken)
        {
            var film = await _omdbApi.SearchFilms(request.FilmName);

            if( film.HasErrors())
            {
                return film.Errors;
            }
            var parsedFilm = JsonConvert.DeserializeObject<Film>(film.Films);

            var qwe = userContextService.User;

            return null;
        }
    }
}
