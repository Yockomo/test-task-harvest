using UnityEngine;

public abstract class HarvestItem : MonoBehaviour
{
    [SerializeField] private float itemCost;

    private Harvest playerHarvest;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inventory))
        {
            playerHarvest = other.GetComponent<Harvest>();
            IsPlayerCloseToHarvest(true);
            inventory.AddItem(this);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (playerHarvest != null)
            IsPlayerCloseToHarvest(false);
    }

    private void IsPlayerCloseToHarvest(bool value)
    {
        playerHarvest.isCloseToHarvestItem = value;
    }
}
