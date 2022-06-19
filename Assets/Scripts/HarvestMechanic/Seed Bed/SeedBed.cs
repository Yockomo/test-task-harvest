using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SeedBed : MonoBehaviour
{
    [SerializeField] private GameObject currentCrop;
    [SerializeField] private float timeToRaiseCrop;
    [SerializeField] private int defaultCorpYScale;

    private Harvest playerHarvest;
    private bool isCropReady = true;
    private bool isSeedHarvesting;
    private int countToHarvest;

    public void Update()
    {
        if (isSeedHarvesting)
            HarvestSeedBed();
    }

    public void HarvestSeedBed()
    {
        isSeedHarvesting = false;
        StartCoroutine(RaiseCorp());
    }

    private IEnumerator RaiseCorp() 
    {
        ScaleCorpByY(1, 1f);
        StartCoroutine(CreateCrop());
        yield return new WaitForSeconds(timeToRaiseCrop);
        ScaleCorpByY(defaultCorpYScale, timeToRaiseCrop);
        countToHarvest = 0;
    }

    private void ScaleCorpByY(int scaleValue, float timeToScale)
    {
        isCropReady = !isCropReady;
        currentCrop.transform.DOScaleY(scaleValue, timeToScale);
    }

    private IEnumerator CreateCrop()
    {
        if (countToHarvest == 0)
        {
            var crop = Instantiate(currentCrop, transform.position, Quaternion.identity);
            crop.transform.DOMove(transform.position + new Vector3(0.5f,0.5f,0.5f), 2f);
            countToHarvest++;
            yield return new WaitForSeconds(2f);
            crop.GetComponent<Collider>().isTrigger = true;
        }
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
        playerHarvest.isCloseToSeedBed = value;
    }

    public void StartHarvestingSeed()
    {
        isSeedHarvesting = true;
    }
}
