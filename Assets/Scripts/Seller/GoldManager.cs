using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public float CurrentGold { get; private set; }

    private UiManager uiManager;

    public void Start()
    {
        try
        {
            uiManager = GetComponent<UiManager>();
        }
        catch
        {
            Debug.Log("There is no Ui Manager component");
        }
    }

    public void AddGold(float amount)
    {
        uiManager.UpdateGoldUi(CurrentGold,amount);
        CurrentGold += amount;
    }

    public void TakeGold(float amount)
    {
        uiManager.UpdateGoldUi(CurrentGold,amount);
        CurrentGold -= amount;
    }
}
