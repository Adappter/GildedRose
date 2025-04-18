using System;
using System.Collections.Generic;
using GildedRoseKata.Interfaces.Updaters;
using GildedRoseKata.Models.Updaters;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly Dictionary<string, IItemUpdater> _itemUpdaters;

    public GildedRose(IList<Item> items)
    {
        _items = items;
        _itemUpdaters = new Dictionary<string, IItemUpdater>
        {
            { "Aged Brie", new AgedBrieUpdater() },
            { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() },
            { "Sulfuras, Hand of Ragnaros", new SulfurasUpdater() },
            { "Conjured", new ConjuredItemUpdater() }
        };
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = GetUpdaterForItem(item);
            updater.Update(item);
        }
    }

    private IItemUpdater GetUpdaterForItem(Item item)
    {
        foreach (var key in _itemUpdaters.Keys)
        {
            if (item.Name.Contains(key, StringComparison.OrdinalIgnoreCase))
            {
                return _itemUpdaters[key];
            }
        }

        return new DefaultItemUpdater();
    }
}