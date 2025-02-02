using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Constants
{
   public static class Errors
    {
        public static class Auth
        {
            public static string LOGIN_NOT_FOUND = "Current login was not found.";
        }

        public static class Films 
        {
            public static string FILM_NOT_FOUND = "Searched film was not found.";
        }
    }
}
