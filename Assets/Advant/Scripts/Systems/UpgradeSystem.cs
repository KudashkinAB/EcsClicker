using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class UpgradeSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private UpgradeButton _upgradeButtonPrefab;

    public UpgradeSystem(UpgradeButton upgradeButtonPrefab)
    {
        _upgradeButtonPrefab = upgradeButtonPrefab;
    }

    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();
        var filter = _world.Filter<Business>().Inc<PanelComponent>().End();
        var businessPool = _world.GetPool<Business>();
        var panelPool = _world.GetPool<PanelComponent>();
        foreach (int entity in filter)
        {
            ref PanelComponent panelComponent = ref panelPool.Get(entity);
            ref Business business = ref businessPool.Get(entity);
            foreach(BusinessUpgrade upgrade in business.Config.Upgrades)
            {
                UpgradeButton upgradeButton = GameObject.Instantiate(_upgradeButtonPrefab, panelComponent.BusinessPanel.UpgradeRoot);
                upgradeButton.SetUpgrade(business, upgrade);
                upgradeButton.OnUpgrade += OnUpgradeClick;
                if (business.Upgrades.Contains(upgrade.name))
                {
                    upgradeButton.Lock();
                }
            }
        }
    }

    public void OnUpgradeClick(UpgradeButton upgradeButton, string businessName, BusinessUpgrade upgrade)
    {
        var filter = _world.Filter<Business>().Inc<PanelComponent>().End();
        var businessPool = _world.GetPool<Business>();
        var panelPool = _world.GetPool<PanelComponent>();
        foreach (int entity in filter)
        {
            ref Business business = ref businessPool.Get(entity);
            ref PanelComponent panel = ref panelPool.Get(entity);
            if (business.Name != businessName)
                continue;
            if(business.Config.Upgrades.Contains(upgrade) == false)
            {
                Debug.LogError($"Missing upgrade: {businessName} {upgrade.name}");
                return;
            }
            if (business.Upgrades.Contains(upgrade.name))
            {
                upgradeButton.Lock();
                return;
            }
            if (Cash.TryToSpend(upgrade.UpgradeCost) == false)
            {
                return;
            }
            upgrade.Upgrade(ref business);
            panel.BusinessPanel.SetBusiness(business);
            business.Upgrades.Add(upgrade.name);
            Debug.Log($"Upgrade {business.Name} : {upgrade.name}");
            upgradeButton.Lock();
        }
    }
}
