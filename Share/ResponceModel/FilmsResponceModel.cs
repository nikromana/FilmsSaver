using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponceModel
{
    public class FilmsResponceModel
    {
        public Film Films { get; set; }
        public string Errors { get; set; }

        public bool HasErrors()
        {
            return !string.IsNullOrWhiteSpace(Errors);
        }
    }
}
