using Leopotam.EcsLite;

public class BusinessIncomeSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        var filter = world.Filter<Business>().End();
        var businesses = world.GetPool<Business>();

        foreach(int entity in filter)
        {
            ref Business business = ref businesses.Get(entity);
            if(business.Progress >= 1f)
            {
                business.Progress -= 1f;
                Cash.PlayerCash += business.Config.GetIncome(business);
            }
        }
    }
}
