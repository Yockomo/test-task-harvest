using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image goldIcon;
    [SerializeField] private TextMeshProUGUI wheatText;
    [SerializeField, Range(0f,1f)] private float textChangeTime;

    private float currentGold;
    private Vector3 defaultScale;

    public void UpdateGoldUi(float currentGold, float amount)
    {
        this.currentGold = currentGold;
        StartCoroutine(TextAnimation(amount));
    }

    private IEnumerator TextAnimation(float amount)
    {
        defaultScale = goldIcon.transform.localScale;
        goldIcon.transform.DOShakeScale(amount*textChangeTime);
        for(int i=0; i<amount; i++)
        {
            currentGold++;
            goldText.text = currentGold.ToString();
            yield return new WaitForSeconds(textChangeTime);
        }
        goldIcon.transform.localScale = defaultScale;
    }

    public void UpdateWheatText(string currentStacks, string maxStacks)
    {
        wheatText.text = $"Wheat count {currentStacks} / {maxStacks}";
    }
}
