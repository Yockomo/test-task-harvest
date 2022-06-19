using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public float CurrentGold { get; private set; }

    public void AddGold(float amount)
    {
        CurrentGold += amount;
        Debug.Log(CurrentGold);
    }

    public void TakeGold(float amount)
    {
        CurrentGold -= amount;
    }
}
