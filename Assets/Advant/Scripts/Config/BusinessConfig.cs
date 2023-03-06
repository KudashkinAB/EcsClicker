using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Business", menuName = "Advant/Business", order = 1)]
public class BusinessConfig : ScriptableObject
{
    [SerializeField, Tooltip("�������� �������")] private string _businessName = "[Business Name]";
    [SerializeField, Tooltip("�������� �� ������ ��� �������������")] private bool _buyOnInit = false;
    [SerializeField, Tooltip("�������� ������")] private float _incomeDelay = 5f;
    [SerializeField, Tooltip("������� ���������")] private float _baseCost = 10f;
    [SerializeField, Tooltip("������� �����")] private float _baseIncome = 10f;
    [SerializeField, Tooltip("��������� ���������")] private List<BusinessUpgrade> _upgrades = new List<BusinessUpgrade>();

    public string BusinessName => _businessName;
    public bool BuyOnInit => _buyOnInit;
    public float IncomeDelay => _incomeDelay;
    public List<BusinessUpgrade> Upgrades => new List<BusinessUpgrade>(_upgrades);

    public virtual float GetIncome(Business business)
    {
        return Mathf.Max(business.Level, 1) * _baseIncome * business.IncomeModifer;
    }

    public virtual float GetCost(Business business)
    {
        return (business.Level + 1) * _baseCost;
    }
}
