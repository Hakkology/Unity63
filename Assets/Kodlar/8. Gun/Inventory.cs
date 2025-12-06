using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    public int quantity;

    public Item(string name, string desc, int qty)
    {
        itemName = name;
        description = desc;
        quantity = qty;
    }
}

[CreateAssetMenu(fileName = "Inventory", menuName = "RPG/Inventory", order = 2)]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;

        // Envanter listesindeki her öðe için döngü
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemToAdd.itemName)
            {
                // Eðer eþya bulunursa, miktarýný artýr
                items[i].quantity += itemToAdd.quantity;
                itemExists = true;
                break;
            }
        }

        // Eðer eþya bulunamazsa, yeni olarak listeye ekle
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemToRemove.itemName && items[i].description == itemToRemove.description)
            {
                // Eþyanýn miktarýný azalt
                if (items[i].quantity < itemToRemove.quantity)
                {
                    Debug.Log("Git oradan yok öyle þey");
                    return;
                }

                items[i].quantity -= itemToRemove.quantity;

                // Eðer miktar 0 veya daha az ise, listeden çýkar
                if (items[i].quantity <= 0)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

        Debug.Log("Bedavacý git odun topla");
    }
}