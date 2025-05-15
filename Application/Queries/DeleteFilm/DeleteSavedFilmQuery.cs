using MediatR;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeleteFilm
{
    public class DeleteSavedFilmQuery : IRequest<ResponceResultBase>
    {
        public int FilmId { get; set; }
    }
}
