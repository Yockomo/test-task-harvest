using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    public void Start()
    {
        this.transform.DOMove(targetPos.position,10f);
    }
}
