using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBed : MonoBehaviour
{
    [SerializeField] private GameObject currentCrop;

    private Harvest playerHarvest;
    private bool isCropReady = true;
    private bool isSeedHarvesting;

    public void Update()
    {
        if (isSeedHarvesting)
            HarvestSeedBed();
    }

    public void HarvestSeedBed()
    {
        isSeedHarvesting = false;
        //TODO DoTweend Scale Y parameter to 1 and start timer
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Harvest>(out Harvest harvest) && isCropReady)
        {
            playerHarvest = harvest;
            harvest.CurrentSeedBed = this;
            IsPlayerCloseToHarvest(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (playerHarvest != null)
        {
            playerHarvest.CurrentSeedBed = null;
            IsPlayerCloseToHarvest(false);
        }
    }

    private void IsPlayerCloseToHarvest(bool value)
    {
        playerHarvest.isCloseToHarvestItem = value;
    }

    public void StartHarvestingSeed()
    {
        isSeedHarvesting = true;
    }
}
