using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wheat : HarvestItem
{
    [Header("Animations parameters")]
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrenght;
    [SerializeField] private int shakeVibration;
    [SerializeField] private float shakeRandomness;
    
    private void FixedUpdate()
    {
        if (this.enabled)
        {
            //var seq = DOTween.Sequence();
            //seq.Append(transform.DOMoveY(0.5f, 2));
            //seq.AppendInterval(0.5f);
            //seq.Join(transform.DOMoveY(-0.5f, 2));
        }    
            /*transform.DOShakePosition(shakeDuration, shakeStrenght, shakeVibration, shakeRandomness);*/
    }
}
