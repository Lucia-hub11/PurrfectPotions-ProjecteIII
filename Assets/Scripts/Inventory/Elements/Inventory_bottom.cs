using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_bottom 
{
    private List<Item> itemList;

    public Inventory_bottom()
    {
        itemList = new List<Item>();

        AddItem(new Item { _itemType = Item.ItemType.Diamant });
        AddItem(new Item { _itemType = Item.ItemType.Cubo });


    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List <Item> GetItemList()
    {
        return itemList;
    }
}
