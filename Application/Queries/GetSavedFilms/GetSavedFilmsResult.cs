using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace Application.Queries.GetSavedFilms
{
    public class GetSavedFilmsResult : ResponceResultBase
    {
        public List<Film> UserFilms { get; set; }
    }
}
