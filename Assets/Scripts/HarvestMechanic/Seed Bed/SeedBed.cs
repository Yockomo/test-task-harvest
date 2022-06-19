using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SeedBed : MonoBehaviour
{
    [SerializeField] private GameObject currentCrop;
    [SerializeField] private float timeToRaiseCrop;
    [SerializeField] private int defaultCorpYScale;

    private Harvest playerHarvest;
    public bool isCropReady { get; private set; } = true;
    private bool isSeedHarvesting;
    private int countToHarvest;

    public void Update()
    {
        if (isSeedHarvesting && isCropReady)
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
        isCropReady = false;
        StartCoroutine(CreateCrop());
        yield return new WaitForSeconds(timeToRaiseCrop / 2);
        ScaleCorpByY(defaultCorpYScale, timeToRaiseCrop/2);
        yield return new WaitForSeconds(timeToRaiseCrop/2);
        isCropReady = true;
        countToHarvest = 0;
    }

    private void ScaleCorpByY(int scaleValue, float timeToScale)
    {
        currentCrop.transform.DOScaleY(scaleValue, timeToScale);
    }

    private IEnumerator CreateCrop()
    {
        if (countToHarvest == 0)
        {
            var crop = Instantiate(currentCrop, transform.position, Quaternion.identity);
            crop.transform.DOMove(transform.position + new Vector3(0.5f,0.5f,0.5f), 1f);
            countToHarvest++;
            yield return new WaitForSeconds(1f);
            crop.GetComponent<Collider>().enabled = true;
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
