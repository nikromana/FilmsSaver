using FilmsSaverDbContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeleteFilm
{
    public class DeleteSavedFilmHandler(FilmsSaverDbContext.FilmsSaverDbContext _context,
        UserContextService _userContextService,
        UserManager<User> _userManager,
        IHubContext<MovieHub> _hubContext) : IRequestHandler<DeleteSavedFilmQuery, ResponceResultBase>
    {
        public async Task<ResponceResultBase> Handle(DeleteSavedFilmQuery request, CancellationToken cancellationToken)
        {
            var result = new ResponceResultBase();
            var userId = _userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _context.Films
                    .Where(x => x.Id == request.FilmId)
                    .Where(x => x.User.Id == userId)
                    .ExecuteDeleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                result.Errors = ex.ToString();
            }

            var existedUser = await _userManager.FindByIdAsync(userId);

            var movieCount = existedUser.SavedFilms.Count();
            await _hubContext.Clients.All.SendAsync("ReceiveMovieCount", movieCount);

            return result;
        }
    }
}
