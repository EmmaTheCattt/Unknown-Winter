using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;

    [SerializeField] InventorySlot[] inventorySlots;

    [SerializeField] Transform dragablesTransform;
    [SerializeField] InventoryItem itemPrefab;

    [SerializeField] Item[] items;
    [SerializeField] Button giveItemBtn;

    private void Awake()
    {
        Singleton = this;
        giveItemBtn.onClick.AddListener( delegate { SpawnInventoryItem(); });
    }

    public void SpawnInventoryItem(Item item = null)
    {
        Item _item = item;
        if (_item == null)
        {
            int random = Random.Range(0, items.Length);
            _item = items[random];
        }

        for (int i = 0; i < inventorySlots.Length; i++) 
        {
            if(inventorySlots[i] == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform);
                break;
            }
        }
    }

    private void Update()
    {
        if(carriedItem == null)
        {
            carriedItem.transform.position = Input.mousePosition;
        }
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            if (item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag) return;
            item.activeSlot.SetItem(carriedItem);
        }

        

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(dragablesTransform);
        
    }

    


}
