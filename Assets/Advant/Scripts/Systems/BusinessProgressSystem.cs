using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class BusinessProgressSystem : IEcsRunSystem
{
    private TimeService _ts;

    public BusinessProgressSystem(TimeService ts)
    {
        _ts = ts;
    }

    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        var filter = world.Filter<Business>().Inc<BusinessTimeProgress>().End();
        var businesses = world.GetPool<Business>();
        foreach(int entity in filter)
        {
            ref Business business = ref businesses.Get(entity);
            if (business.Level <= 0)
                continue;
            business.Progress += 1f / business.Config.IncomeDelay * _ts.DeltaTime;
        }
    }
}
