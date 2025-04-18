using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = InitializeItems();
        var app = new GildedRose(items);

        int days = ParseDaysFromArgs(args);

        RunSimulation(app, items, days);
    }

    private static IList<Item> InitializeItems()
    {
        return new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };
    }

    private static int ParseDaysFromArgs(string[] args)
    {
        if (args.Length > 0 && int.TryParse(args[0], out int days))
        {
            return days + 1;
        }
        return 2;
    }

    private static void RunSimulation(GildedRose app, IList<Item> items, int days)
    {
        for (var i = 0; i < days; i++)
        {
            PrintDayHeader(i);
            PrintItems(items);
            app.UpdateQuality();
        }
    }

    private static void PrintDayHeader(int day)
    {
        Console.WriteLine($"-------- day {day} --------");
        Console.WriteLine("name, sellIn, quality");
    }

    private static void PrintItems(IList<Item> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
        }
        Console.WriteLine();
    }
}