using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemlist;

    public Inventory()
    {
        itemlist = new List<Item>();
        AddItem(new Item { itemtype = Item.ItemType.FlareGun, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.FlareAmmo, amount = 4 });
        AddItem(new Item { itemtype = Item.ItemType.HealthKit, amount = 2 });
        Debug.Log(itemlist.Count);
    }

    public void AddItem(Item item)
    {
        itemlist.Add(item);
    }

    public List<Item> GetItems()
    {
        return itemlist;
    }
}
