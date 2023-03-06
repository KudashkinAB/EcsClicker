using UnityEngine;

[System.Serializable]
public class UISettings
{
    [SerializeField] private Transform _uiRoot;
    [SerializeField] private BusinessPanel _businessPanelPrefab;
    [SerializeField] private CashUI _cashUI;
    [SerializeField] private UpgradeButton _upgradeButton;

    public Transform UiRoot { get => _uiRoot; }
    public BusinessPanel BusinessPanelPrefab { get => _businessPanelPrefab; }
    public CashUI CashUI { get => _cashUI; }
    public UpgradeButton UpgradeButton { get => _upgradeButton; }
}
