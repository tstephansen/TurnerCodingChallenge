using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Entities
{
    public class SwapiResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Film> results { get; set; }
    }
}
