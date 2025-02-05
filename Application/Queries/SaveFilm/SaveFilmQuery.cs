using MediatR;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SaveFilm
{
    public class SaveFilmQuery : IRequest<ResponceResultBase>
    {
        public string FilmName {  get; set; }
    }
}
