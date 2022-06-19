using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Seller : MonoBehaviour
{
    [SerializeField] private Transform sellerPosition;

    private GoldManager goldManager;
    private UiManager uiManager;
    private Inventory playerInventory;
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inventory))
        { 
            goldManager = other.GetComponent<GoldManager>();
            uiManager = other.GetComponent<UiManager>();
            playerInventory = inventory;

            StartCoroutine(SellItems(playerInventory.harvestItems));
            inventory.harvestItems = new List<HarvestItem>();
            inventory.currentInventoryCount = 0;
        }
    }

    private IEnumerator SellItems(List<HarvestItem> items)
    {
       var currentItems = items.Count;
       foreach(var item in items)
       {
            item.transform.parent = null;
            item.transform.DOMove(sellerPosition.position, 1f);
            goldManager.AddGold(item.ItemCost);
            
            currentItems--;
            uiManager.UpdateWheatText(currentItems.ToString(),playerInventory.MaxInventoryCount.ToString());
            
            yield return new WaitForSeconds(1f);
       }
    }
}
