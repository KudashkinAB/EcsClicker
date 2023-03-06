using UnityEngine;
using TMPro;

public class CashUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _cashText;

    public void ChangeCash(float cash)
    {
        _cashText.SetText(cash.ToString("0") + "$");
    }
}
