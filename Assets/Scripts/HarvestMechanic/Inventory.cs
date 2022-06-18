using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxInventoryCount;

    public int MaxInventoryCount { get { return maxInventoryCount; } }

    public int currentInventoryCount { get; private set; }

    public void AddItem<T>(T item) where T : HarvestItem
    {
        if (CheckForEmptySlot())
        {
            HideObject(item);
            currentInventoryCount++;
        }
    }

    private bool CheckForEmptySlot()
    {
        return currentInventoryCount < maxInventoryCount;
    }

    private void HideObject<T>(T item) where T : HarvestItem
    {
        item.gameObject.SetActive(false);
    }

    private void TryUpdateUI()
    {
        //if (UpdateUI != null)
        //    UpdateUI(dimensionIndex, slotId, isUsed);
    }

    public void SellItem()
    {
        currentInventoryCount--;
    }
}
