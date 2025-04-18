using System;
using GildedRoseKata.Interfaces.Updaters;

namespace GildedRoseKata.Models.Updaters
{
    public class DefaultItemUpdater : IItemUpdater
    {
        public virtual void Update(Item item)
        {
            DecreaseQuality(item, 1);
            item.SellIn--;

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, 1);
            }
        }

        protected void DecreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}
