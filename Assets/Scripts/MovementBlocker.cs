using StarterAssets;
using UnityEngine;

public class MovementBlocker : MonoBehaviour
{
    private ThirdPersonController playerController;
    private StarterAssetsInputs playerInputs;


    public void Start()
    {
        try
        {
            playerController = GetComponent<ThirdPersonController>();
            playerInputs = GetComponent<StarterAssetsInputs>();

        }
        catch
        {
            Debug.Log("There are no controller/inputs on player");
        }
    }

    public void StopMovement()
    {
        playerInputs.move = Vector2.zero;
        playerController.enabled = false; 
    }

    public void ResetMovement()
    {
        playerController.enabled = true;
    }
}
