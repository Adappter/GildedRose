using System;
using GildedRoseKata.Interfaces.Updaters;

namespace GildedRoseKata.Models.Updaters
{
    public class BackstagePassUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.SellIn > 10)
            {
                IncreaseQuality(item, 1);
            }
            else if (item.SellIn > 5)
            {
                IncreaseQuality(item, 2);
            }
            else if (item.SellIn > 0)
            {
                IncreaseQuality(item, 3);
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

        private void IncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(50, item.Quality + amount);
        }
    }
}
