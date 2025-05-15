using FilmsSaverDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeleteFilm
{
    public class DeleteSavedFilmHandler(FilmsSaverDbContext.FilmsSaverDbContext _context,
        UserContextService _userContextService) : IRequestHandler<DeleteSavedFilmQuery, ResponceResultBase>
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

            return result;
        }
    }
}
