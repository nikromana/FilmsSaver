using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SaveFilm
{
    public class SaveFilmQuery : IRequest<string>
    {
        public string FilmName {  get; set; }
    }
}
