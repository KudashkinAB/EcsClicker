using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Income Upgrade", menuName = "Advant/Upgrade/Income Upgrade", order = 2)]
public class IncomeModiferUpgrade : BusinessUpgrade
{
    [SerializeField, Min(0.01f), Tooltip("Модификатор дохода")] private float _incomeModifer = 0.5f;

    public override void Upgrade(ref Business business)
    {
        base.Upgrade(ref business);
        business.IncomeModifer += _incomeModifer;
    }

    public override string GetUpgradeDesc()
    {
        return $"{UpgradeName}\nДоход + {(_incomeModifer * 100f).ToString("0")}%";
    }
}
