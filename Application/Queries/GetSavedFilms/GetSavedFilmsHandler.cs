using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetSavedFilms
{
    public class GetSavedFilmsHandler
        (FilmsSaverDbContext.FilmsSaverDbContext _context,
        UserContextService _userContextService) : IRequestHandler<GetSavedFilmsQuery, GetSavedFilmsResult>
    {
        public async Task<GetSavedFilmsResult> Handle(GetSavedFilmsQuery request, CancellationToken cancellationToken)
        {
            var films = new GetSavedFilmsResult();
            try
            {
                var userId = _userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier);

                films.UserFilms = await _context.Films.Where(x => x.User.Id == userId).ToListAsync(cancellationToken);
            }
            catch (Exception ex) 
            {
                films.Errors = ex.ToString();
            }

            return films;
        }
    }
}
