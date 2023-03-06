using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BusinessPanel : MonoBehaviour
{
    private Business business;
    [SerializeField] private TextMeshProUGUI _businessName;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _income;
    [SerializeField] private LevelUpButton _levelUpButton;
    [SerializeField] private Transform _upgradeRoot;

    public Slider Slider => _slider;
    public LevelUpButton LevelUpButton => _levelUpButton;
    public Transform UpgradeRoot => _upgradeRoot;

    public void SetBusiness(Business business)
    {
        _businessName.text = business.Config.BusinessName;
        _level.text = $"LVL\n{business.Level}";
        _income.text = $"Доход\n{business.Config.GetIncome(business).ToString("0")}$";
        LevelUpButton.SetBusiness(business);
    }
}
