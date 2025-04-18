using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void NormalItem()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }


    //Once the sell by date has passed, Quality degrades twice as fast
    [Test]
    public void NormalItem_QualityDegradesTwiceAsFast_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(8));

    }

    //The Quality of an item is never negative
    [Test]
    public void Quality_NeverGoesBelowZero()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(4));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void Quality_DoesNotGoNegative_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 1 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    //Aged Brie actually increases in Quality the older it gets
    [Test]
    public void AgedBrie_IncreasesInQuality()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(1));
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }

    //The Quality of Aged Brie is never more than 50
    [Test]
    public void AgedBrie_QualityNeverMoreThan50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(1));
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void AgedBrie_QualityNeverMoreThan50_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    //Sulfuras, being a legendary item, never has to be sold or decreases in Quality
    [Test]
    public void Sulfuras_NeverHasToBeSoldOrDecreasesInQuality()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void Sulfuras_NeverHasToBeSoldOrDecreasesInQuality_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    //Backstage passes, like aged brie, increases in Quality as its SellIn value approaches;
    //Quality increases by 2 when there are 10 days or less
    [Test]
    public void BackstagePasses_IncreasesInQuality_10DaysOrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }

    //Backstage passes, like aged brie, increases in Quality as its SellIn value approaches;
    //Quality increases by 3 when there are 5 days or less
    [Test]
    public void BackstagePasses_IncreasesInQuality_5DaysOrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(4));
        Assert.That(items[0].Quality, Is.EqualTo(23));
    }

    //Backstage passes, like aged brie, increases in Quality as its SellIn value approaches;
    //Quality drops to 0 after the concert
    [Test]
    public void BackstagePasses_QualityDropsTo0_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    //Conjured items degrade in Quality twice as fast as normal items
    [Test]
    public void ConjuredItem_QualityDegradesTwiceAsFast()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(2));
        Assert.That(items[0].Quality, Is.EqualTo(4));
    }
}