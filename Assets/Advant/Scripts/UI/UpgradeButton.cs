using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    private BusinessUpgrade _upgrade;
    private Business _business;

    public Action<UpgradeButton, string, BusinessUpgrade> OnUpgrade;

    public void SetUpgrade(Business business, BusinessUpgrade upgrade)
    {
        _business = business;
        _upgrade = upgrade;
        _text.SetText($"{upgrade.GetUpgradeDesc()}\nЦена: {upgrade.UpgradeCost}$");
    }

    public void Lock()
    {
        _button.interactable = false;
        _text.SetText($"{_upgrade.GetUpgradeDesc()}\nКуплено");
    }

    public void Upgrade()
    {
        if (_upgrade == null)
            return;
        OnUpgrade?.Invoke(this, _business.Name, _upgrade);
    }
}
