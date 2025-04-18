using System;
using GildedRoseKata.Interfaces.Updaters;

namespace GildedRoseKata.Models.Updaters
{
    public class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            IncreaseQuality(item, 1);
            item.SellIn--;

            if (item.SellIn < 0)
            {
                IncreaseQuality(item, 1);
            }
        }

        private void IncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(50, item.Quality + amount);
        }
    }
}
