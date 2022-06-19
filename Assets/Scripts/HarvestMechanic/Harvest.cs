using StarterAssets;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public SeedBed CurrentSeedBed { get; set; }

    private StarterAssetsInputs playersInputs;
    private AnimatorManager animatorManager;
    private MovementBlocker movementBlocker;

    public bool isCloseToHarvestItem { get; set; }
    
    public void Start()
    {
        try
        {
            playersInputs = GetComponent<StarterAssetsInputs>();
            animatorManager = GetComponent<AnimatorManager>();
            movementBlocker = GetComponent<MovementBlocker>();
        }
        catch
        {
            Debug.Log("There are no inputSystem/AnimatorManager/MovementBlocker on player");
        }
    }

    
    public void Update()
    {
        if (playersInputs.interact && isCloseToHarvestItem)
            TryHarvest(1);
    }

    private void TryHarvest(int value)
    {
        bool boolValue = value <= 0  ? false : true;

        if (boolValue)
        {
            movementBlocker.StopMovement();
            CurrentSeedBed.StartHarvestingSeed();
            //TODO ADD DOTWEEN ANIMATION
            transform.LookAt(CurrentSeedBed.gameObject.transform);
        }
        else
        {
            movementBlocker.ResetMovement();
        }

        animatorManager.Interact(boolValue);
    }
}
