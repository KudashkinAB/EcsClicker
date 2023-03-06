using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BusinessUpgrade : ScriptableObject
{
    [SerializeField, Tooltip("Название улучшения")] private string _upgradeName = "[Upgrade Name]";
    [SerializeField, Tooltip("Стоимость улучшения")] private float _upgradeCost = 10f;

    public string UpgradeName => _upgradeName;
    public float UpgradeCost => _upgradeCost;

    public virtual void Upgrade(ref Business business)
    {
        Debug.Log($"{business.Name} upgraded -> {name}");
    }

    public virtual string GetUpgradeDesc()
    {
        return "[Upgrade Desc]";
    }
}
