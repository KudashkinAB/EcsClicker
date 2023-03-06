using UnityEngine;
using Leopotam.EcsLite;

public class BusinessPanelSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        var filter = world.Filter<Business>().Inc<PanelComponent>().End();
        var panels = world.GetPool<PanelComponent>();
        var businesses = world.GetPool<Business>();

        foreach(int entity in filter)
        {
            PanelComponent panel = panels.Get(entity);
            panel.BusinessPanel.Slider.value = businesses.Get(entity).Progress;
        }
    }
}
