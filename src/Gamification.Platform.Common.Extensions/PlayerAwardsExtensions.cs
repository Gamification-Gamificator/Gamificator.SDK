using Gamification.Platform.Common.Display;
using System.Collections.Generic;
using System.Linq;

namespace Gamification.Platform.Common.Extensions
{
    /// <summary>
    /// The Coins you want a balance for
    /// </summary>
    public static class PlayerAwardsExtensions
    {
        public static List<CoinBalanceDisplay> ToBalance(this PlayerAwards item, Coins coins)
        {
            //TODO not expired etc
            return item.Where(e=>coins.Any(c=>c.EntityRefId.Equals(e.CoinRefId))).GroupBy(f => f.CoinRefId).Select(cl =>
                          new CoinBalanceDisplay
                          {
                              Coin = coins.FirstOrDefault(g => g.EntityRefId.Equals(cl.First().CoinRefId))?.ToDisplay(),
                              Balance = cl.Sum(s => s.Value),
                          }
                        ).ToList();
        }
    }
}
