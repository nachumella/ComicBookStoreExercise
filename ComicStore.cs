using System.Reflection;

namespace ComicBookStore;

/// <summary>
/// מחלקת חנות ספרי הקומיקס - מכילה את האוספים והפעולות שהתלמידים יידרשו לממש.
/// </summary>
public class ComicStore
{
    // רשימת חוברות הקומיקס בחנות
    public List<ComicBook> Inventory { get; private set; }

    public ComicStore()
    {
        Inventory = new List<ComicBook>();
        InitializeInventory();
    }

    /// <summary>
    /// אתחול החנות עם 20 חוברות קומיקס שונות (כולל חוברות עם מלאי 0)
    /// </summary>
    private void InitializeInventory()
    {
        Inventory.Add(new ComicBook("The Amazing Spider-Man #300", 1988, "Spider-Man", 5));
        Inventory.Add(new ComicBook("Batman: The Dark Knight Returns", 1986, "Batman", 0));
        Inventory.Add(new ComicBook("Superman: Action Comics #1000", 2018, "Superman", 12));
        Inventory.Add(new ComicBook("X-Men #1", 1991, "X-Men", 8));
        Inventory.Add(new ComicBook("Wonder Woman #1", 2016, "Wonder Woman", 0));
        Inventory.Add(new ComicBook("Deadpool: Kills the Marvel Universe", 2012, "Deadpool", 3));
        Inventory.Add(new ComicBook("Iron Man: Demon in a Bottle", 1979, "Iron Man", 2));
        Inventory.Add(new ComicBook("The Flash: Flashpoint", 2011, "The Flash", 7));
        Inventory.Add(new ComicBook("Thor: God of Thunder #1", 2012, "Thor", 0));
        Inventory.Add(new ComicBook("Captain America: Winter Soldier", 2005, "Captain America", 4));
        Inventory.Add(new ComicBook("Spider-Man: Blue", 2002, "Spider-Man", 10));
        Inventory.Add(new ComicBook("Batman: Year One", 1987, "Batman", 6));
        Inventory.Add(new ComicBook("Wolverine: Weapon X", 1991, "Wolverine", 0));
        Inventory.Add(new ComicBook("Black Panther: A Nation Under Our Feet", 2016, "Black Panther", 9));
        Inventory.Add(new ComicBook("Spider-Gwen #1", 2015, "Spider-Man", 1));
        Inventory.Add(new ComicBook("Doctor Strange: The Way of the Weird", 2015, "Doctor Strange", 4));
        Inventory.Add(new ComicBook("Fantastic Four #48", 1966, "Fantastic Four", 0));
        Inventory.Add(new ComicBook("Daredevil: Born Again", 1986, "Daredevil", 3));
        Inventory.Add(new ComicBook("Venom: Lethal Protector", 1993, "Venom", 11));
        Inventory.Add(new ComicBook("Harley Quinn: Mad Love", 1994, "Harley Quinn", 0));
    }

    // =========================================================================
    // מתודות מיועדות לתרגול התלמידים (מגיעות כרגע עם מימוש ריק / מחזירות ערך ברירת מחדל)
    // =========================================================================

    /// <summary>
    /// משימה 1: הוספת חוברת קומיקס חדשה לחנות.
    /// אם החוברת כבר קיימת (לפי שם), יש להגדיל את המלאי בכמות שמתקבלת.
    /// אם החוברת לא קיימת, יש להוסיף אותה לרשימה.
    /// </summary>
    public void AddOrUpdateComic(ComicBook newComic)
    {
        foreach (ComicBook comic in Inventory)
        {
            if (comic.Title == newComic.Title)
            {
                comic.StockQuantity += newComic.StockQuantity;
                return;
            }
        }

        Inventory.Add(newComic);
    }

    public bool UpdateStock(string title, int newQuantity)
    {
        foreach (ComicBook comic in Inventory)
        {
            if (comic.Title == title)
            {
                comic.StockQuantity = newQuantity;
                return true;
            }
        }

        return false;
    }

    public List<ComicBook> SearchByHero(string heroName)
    {
        return Inventory.Where(c => c.Hero == heroName).ToList();
    }

    public bool IsInStock(string title)
    {
        foreach (ComicBook comic in Inventory)
        {
            if (comic.Title == title && comic.StockQuantity > 0)
            {
                return true;
            }
        }

        return false;
    }

    public Dictionary<string, int> GetStockDictionary()
    {
        Dictionary<string, int> stockDictionary = new Dictionary<string, int>();

        foreach (ComicBook comic in Inventory)
        {
            stockDictionary[comic.Title] = comic.StockQuantity;
        }

        return stockDictionary;
    }

    public int GetQuantityFromDictionary(string title)
    {
        Dictionary<string, int> stockDictionary = GetStockDictionary();

        if (stockDictionary.ContainsKey(title))
        {
            return stockDictionary[title];
        }

        return -1;
    }

    public string GetHeroWithMostComics()
    {
        Dictionary<string, int> heroes = new Dictionary<string, int>();

        foreach (ComicBook comic in Inventory)
        {
            if (heroes.ContainsKey(comic.Hero))
            {
                heroes[comic.Hero]++;
            }
            else
            {
                heroes[comic.Hero] = 1;
            }
        }

        string heroName = "";
        int max = 0;

        foreach (string hero in heroes.Keys)
        {
            if (heroes[hero] > max)
            {
                max = heroes[hero];
                heroName = hero;
            }
        }

        return heroName;
    }