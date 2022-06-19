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

    public bool AddItem<T>(T item) where T : HarvestItem
    {
        if (CheckForEmptySlot() && !harvestItems.Contains(item))
        {
            TakeCorpStack(item);
            harvestItems.Add(item);
            currentInventoryCount++;
            return true;
        }

        return false;
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
    }

    private void TryUpdateUI()
    {
        //if (UpdateUI != null)
        //    UpdateUI(dimensionIndex, slotId, isUsed);
    }
}
