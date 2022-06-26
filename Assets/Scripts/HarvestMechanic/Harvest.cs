using StarterAssets;
using UnityEngine;
using System.Collections;

public class Harvest : MonoBehaviour
{
    public SeedBed CurrentSeedBed { get; set; }
    public bool isCloseToSeedBed { get; set; }

    private StarterAssetsInputs playersInputs;
    private AnimatorManager animatorManager;
    private MovementBlocker movementBlocker;
    private bool delay;
    [SerializeField] private GameObject scythe;


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
        if (playersInputs.interact && isCloseToSeedBed && !animatorManager.GetInteract() && !delay &&CurrentSeedBed.isCropReady)
            TryHarvest(1); 
    }

    private void TryHarvest(int value)
    {
        bool boolValue = value <= 0  ? false : true;

        if (boolValue)
        {
            movementBlocker.StopMovement();
            scythe.SetActive(true);
            delay = true;
        }
        else
        {
            movementBlocker.ResetMovement();
            scythe.SetActive(false);
            StartCoroutine(Delay(0.1f));
        }

        animatorManager.Interact(boolValue);
    }

    private IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        delay = false;
    }


    public void HarvestSeed()
    {
        if (CurrentSeedBed != null && CurrentSeedBed.isCropReady)
            CurrentSeedBed.StartHarvestingSeed();
    }

    public void EndHarvest()
    {
        TryHarvest(0);
        movementBlocker.ResetMovement();
    }
}
