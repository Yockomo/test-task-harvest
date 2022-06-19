using DG.Tweening;
using UnityEngine;

public abstract class HarvestItem : MonoBehaviour
{
    [SerializeField] private float itemCost;

    public float ItemCost { get { return itemCost; } }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inventory))
        {
            if(inventory.AddItem(this))
                transform.DOShakeScale(3f, 5f).SetLoops(-1);
        }
    }
}
