using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class LevelUpSystem : IEcsInitSystem
{
    private EcsWorld _world;

    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();
        var filter = _world.Filter<Business>().Inc<PanelComponent>().End();
        var pool = _world.GetPool<PanelComponent>();
        foreach (int entity in filter)
        {
            ref PanelComponent panelComponent = ref pool.Get(entity);
            panelComponent.BusinessPanel.LevelUpButton.OnLevelUp += OnLevelUpClick;
        }
    }

    private void OnLevelUpClick(string leveledBusiness)
    {
        var filter = _world.Filter<Business>().End();
        var businessPool = _world.GetPool<Business>();
        var panelPool = _world.GetPool<PanelComponent>();
        foreach (int entity in filter)
        {
            ref Business business = ref businessPool.Get(entity);
            if (business.Name != leveledBusiness || Cash.TryToSpend(business.Config.GetCost(business)) == false)
                continue;
            business.Level++;
            Debug.Log($"{business.Name} Level Up -> {business.Level}");
            if (panelPool.Has(entity))
            {
                ref PanelComponent panelComponent = ref panelPool.Get(entity);
                panelComponent.BusinessPanel.SetBusiness(business);
            }
        }
    }
}
