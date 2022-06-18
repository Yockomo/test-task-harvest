using StarterAssets;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private StarterAssetsInputs playersInputs;
    private AnimatorManager animatorManager;
    private MovementBlocker movementBlocker;

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
        if (playersInputs.interact)
            TryHarvest(1);
    }

    private void TryHarvest(int value)
    {
        bool boolValue = value <= 0  ? false : true;

        if (boolValue)
            movementBlocker.StopMovement();
        else
            movementBlocker.ResetMovement();

        animatorManager.Interact(boolValue);
    }
}
