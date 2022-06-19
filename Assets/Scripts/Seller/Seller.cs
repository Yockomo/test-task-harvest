using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Seller : MonoBehaviour
{
    [SerializeField] private Transform sellerPosition;

    private GoldManager goldManager;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inventory))
        { 
            goldManager = other.GetComponent<GoldManager>();
            StartCoroutine(SellItems(inventory.harvestItems));
            inventory.harvestItems = new List<HarvestItem>();
            inventory.currentInventoryCount = 0;
        }
    }

    private IEnumerator SellItems(List<HarvestItem> items)
    {
       foreach(var item in items)
       {
            item.transform.parent = null;
            item.gameObject.SetActive(true);
            item.transform.DOMove(sellerPosition.position, 1f);
            goldManager.AddGold(item.ItemCost);
            yield return new WaitForSeconds(1f);
            item.gameObject.SetActive(false);
       }
    }
}