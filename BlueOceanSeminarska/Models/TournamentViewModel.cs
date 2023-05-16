using BlueOceanSeminarska.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueOceanSeminarska.Models
{
    public class TournamentViewModel
    {
        public IEnumerable<Spins> Spins { get; set; }
        public IEnumerable<BiggestWins> BiggestWins { get; set; }
    }
}