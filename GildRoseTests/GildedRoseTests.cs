using System;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildRoseTests;

public class Tests
{
    private Program prog;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCreation()
    { 
        prog = Program.CreateProgram();
       Assert.IsTrue(TestSpecificCreation("+5 Dexterity Vest", 10, 20));
       Assert.IsTrue(TestSpecificCreation("Aged Brie", 2, 0));
       Assert.IsTrue(TestSpecificCreation("Elixir of the Mongoose", 5, 7));
       Assert.IsTrue(TestSpecificCreation("Sulfuras, Hand of Ragnaros", 0, 80));
       Assert.IsTrue(TestSpecificCreation("Backstage passes to a TAFKAL80ETC concert", 15, 20));
       Assert.IsTrue(TestSpecificCreation("Conjured Mana Cake", 3, 6));
    }

    [Test]
    public void TestOneDayPassing()
    {
        prog = Program.CreateProgram();
        prog.UpdateQuality();
        Assert.IsTrue(TestSpecificCreation("+5 Dexterity Vest", 9, 19));
        Assert.IsTrue(TestSpecificCreation("Aged Brie", 1, 1));
        Assert.IsTrue(TestSpecificCreation("Elixir of the Mongoose", 4, 6));
        Assert.IsTrue(TestSpecificCreation("Sulfuras, Hand of Ragnaros", 0, 80));
        Assert.IsTrue(TestSpecificCreation("Backstage passes to a TAFKAL80ETC concert", 14, 21));
        Assert.IsTrue(TestSpecificCreation("Conjured Mana Cake", 2, 4));
    }
    
    [Test]
    public void TestFiveDayPassing()
    {
        prog = Program.CreateProgram();
        for (int i = 0; i < 5; i++)
        {
            prog.UpdateQuality();    
        }
        
        Assert.IsTrue(TestSpecificCreation("+5 Dexterity Vest", 5, 15));
        Assert.IsTrue(TestSpecificCreation("Aged Brie", -3, 8));
        Assert.IsTrue(TestSpecificCreation("Elixir of the Mongoose", 0, 2));
        Assert.IsTrue(TestSpecificCreation("Sulfuras, Hand of Ragnaros", 0, 80));
        Assert.IsTrue(TestSpecificCreation("Backstage passes to a TAFKAL80ETC concert", 10, 25));
        Assert.IsTrue(TestSpecificCreation("Conjured Mana Cake", -2, 0));
    }
    
    [Test]
    public void TestTenDayPassing()
    {
        int day = 10;
        prog = Program.CreateProgram();
        for (int i = 0; i < day; i++)
        {
            prog.UpdateQuality();    
        }
        
        Assert.IsTrue(TestSpecificCreation("+5 Dexterity Vest", 0, 10));
        Assert.IsTrue(TestSpecificCreation("Aged Brie", -8, 18));
        Assert.IsTrue(TestSpecificCreation("Elixir of the Mongoose", -5, 0));
        Assert.IsTrue(TestSpecificCreation("Sulfuras, Hand of Ragnaros", 0, 80));
        Assert.IsTrue(TestSpecificCreation("Backstage passes to a TAFKAL80ETC concert", 5, 35));
        Assert.IsTrue(TestSpecificCreation("Conjured Mana Cake", -7, 0));
    }
    
    private bool TestSpecificCreation(string itemName, int sellIn, int quality)
    {
        var item = prog.Items.FirstOrDefault(item => item.Name.Equals(itemName));
        if (item == null) return false;
        if (item.SellIn != sellIn) return false;
        if (item.Quality != quality) return false;
        return true;
    }
}