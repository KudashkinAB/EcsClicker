using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    private string _businessName;
    public TextMeshProUGUI Text => _text;
    public Action<string> OnLevelUp;

    public void SetBusiness(Business business)
    {
        _businessName = business.Name;
        _text.SetText($"LVL UP\n{business.Config.GetCost(business)}$");
    }

    public void LevelUp()
    {
        OnLevelUp?.Invoke(_businessName);
    }
}
