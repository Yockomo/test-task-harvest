using StarterAssets;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator playerAnimator;
    private ThirdPersonController playerController;

    private readonly int interact = Animator.StringToHash("Interact");

    public void Start()
    {
        try
        {
            playerAnimator = GetComponent<Animator>();
            playerController = GetComponent<ThirdPersonController>();
        }
        catch
        {
            Debug.Log("There are no animator/controller script on player");
        }
    }

    public void Interact(bool value)
    {
        playerAnimator.SetBool(interact, value);
    }
}
