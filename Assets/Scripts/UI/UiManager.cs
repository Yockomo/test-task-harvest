using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI wheatText;
    
    public void UpdateGoldUi(string text)
    {
        goldText.text = text;
    }

    public void UpdateWheatText(string currentStacks, string maxStacks)
    {
        wheatText.text = $"Wheat count {currentStacks} / {maxStacks}";
    }
}
