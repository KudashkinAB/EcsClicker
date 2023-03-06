using Leopotam.EcsLite;
using UnityEngine;

public class TimeSystem : IEcsRunSystem
{
    private TimeService _ts;

    public TimeSystem(TimeService ts)
    {
        _ts = ts;
    }

    public void Run(IEcsSystems systems)
    {
        _ts.Time = Time.time;
        _ts.DeltaTime = Time.deltaTime;
    }
}
