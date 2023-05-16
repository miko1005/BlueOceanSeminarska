using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using BlueOceanSeminarska.App_Start;
using BlueOceanSeminarska.Models;

namespace BlueOceanSeminarska.Controllers
{
    public class LeaderboardController : Controller
    {
        private BlueOceanDBEntities db = new BlueOceanDBEntities();

        // GET: Leaderboard
        public ActionResult top10(DateTime? startDate, DateTime? endDate)
        {
            var topTenPlayers = db.PoslaniPodatki
                    .Where(p => p.DatumZapisa >= startDate && p.DatumZapisa <= endDate) // filter by dates
                    .GroupBy(p => p.remote_id)
                    .Select(g => new TopPlayersViewModel { RemoteId = g.Key, SumAmount = Math.Round(g.Sum(p => p.amount) ?? 0, 2) })
                    .OrderByDescending(g => g.SumAmount)
                    .Take(10)
                    .ToList();
            return View(topTenPlayers);
        }
        public ActionResult tournament()
        {
            var negativeAmounts = db.PoslaniPodatki
                .Where(p => p.amount < 0M)
                .GroupBy(p => p.remote_id)
                .Select(g => new
                {
                    RemoteId = g.Key,
                    RemoteIdCount = g.Count()
                })
                .ToList()
                .Select(x => new Spins
                {
                    remoteid = x.RemoteId,
                    spincount = x.RemoteIdCount
                })
                .OrderByDescending(g => g.spincount)
                .Take(10)
                .ToList();


            var biggestwins = db.PoslaniPodatki
                .Where(p => p.amount > 0) // only consider positive amounts as wins
                .GroupBy(p => p.remote_id)
                .ToList()
                .Select(g => new BiggestWins { RemoteId = g.Key, MaxAmount = g.Max(p => p.amount) })
                .OrderByDescending(g => g.MaxAmount)
                .Take(10)
                .ToList();

            var viewModel = new TournamentViewModel
            {
                Spins = negativeAmounts,
                BiggestWins = biggestwins
            };



            return View(viewModel);
        }


    }
}
