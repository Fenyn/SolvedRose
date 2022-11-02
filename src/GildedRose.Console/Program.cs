using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = CreateProgram();

            app.UpdateQuality();

            System.Console.WriteLine("Press any key to exit...");

        }

        public static Program CreateProgram()
        {
            return new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }

            };
        }

        public void UpdateQuality()
        {           
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                //aged brie increases quality with age instead of decrease
                //if after its sellIn date, it gets an additional quality increase
                //quality never more than 50
                if (item.Name.ToLower().Equals("aged brie"))
                {
                    if(item.Quality < 50) item.Quality++;
                    item.SellIn--;
                    if (item.SellIn < 0 && item.Quality < 50) item.Quality++;
                }
                //backstage passes have unique logic
                //  normal day is quality++ like cheese
                //  quality += 2 when sellIn <= 10
                //  quality += 3 when sellIn <= 5
                //  quality = 0 when sellIn <= 0
                else if (item.Name.ToLower().Equals("backstage passes to a tafkal80etc concert"))
                {
                    if (item.SellIn <= 0) item.Quality = 0;
                    else if (item.SellIn <= 5) item.Quality += 3;
                    else if (item.SellIn <= 10) item.Quality += 2;
                    else item.Quality++;
                    item.SellIn--;
                }
                //sulfuras is legendary, it does not need to be sold and never decreases in quality
                else if (item.Name.ToLower().Equals("sulfuras, hand of ragnaros"))
                {
                    //do nothing
                } else if (item.Name.ToLower().Contains("conjured"))
                {
                    item.SellIn--;
                    item.Quality = item.Quality > 2 ? item.Quality - 2 : 0;
                }
                else
                {
                    item.SellIn--;
                    //quality never negative
                    if (item.Quality > 0) item.Quality--;
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
