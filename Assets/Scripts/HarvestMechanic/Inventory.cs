using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxInventoryCount;
    [SerializeField] private Transform backpackPosition;

    public int MaxInventoryCount { get { return maxInventoryCount; } }
    public int currentInventoryCount { get; set; }

    public List<HarvestItem> harvestItems { get; set; } = new List<HarvestItem>();

    public void AddItem<T>(T item) where T : HarvestItem
    {
        if (CheckForEmptySlot() && !harvestItems.Contains(item))
        {
            TakeCorpStack(item);
            harvestItems.Add(item);
            currentInventoryCount++;
        }
    }

    private bool CheckForEmptySlot()
    {
        return currentInventoryCount < maxInventoryCount;
    }

    private void TakeCorpStack(HarvestItem item)
    {
        var timeToMove = 0.5f;
        item.transform.SetParent(backpackPosition);
        item.transform.DOLocalMove(Vector3.zero,timeToMove);
        
        if(currentInventoryCount > 1)
            item.gameObject.SetActive(false);
    }

    private void TryUpdateUI()
    {
        //if (UpdateUI != null)
        //    UpdateUI(dimensionIndex, slotId, isUsed);
    }
}
