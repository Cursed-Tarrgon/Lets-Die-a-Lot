using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeTillEndText;

    public void Update()
    {
        timeText.text = GameStateManager.Instance.timeInGame.ToString("0:00.00");
        timeTillEndText.text = GameStateManager.Instance.timeTillEnd.ToString("0:00.00");
    }
}
