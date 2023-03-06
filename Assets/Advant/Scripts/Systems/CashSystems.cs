using System;
using Leopotam.EcsLite;

public class CashSystems : IEcsInitSystem
{
    private CashUI _cashUI;

    public CashSystems(CashUI cashUI)
    {
        _cashUI = cashUI;
    }

    public void Init(IEcsSystems systems)
    {
        Cash.OnCashChanged += _cashUI.ChangeCash;
        _cashUI.ChangeCash(Cash.PlayerCash);
    }
}
