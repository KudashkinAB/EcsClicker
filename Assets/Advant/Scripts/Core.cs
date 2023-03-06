using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private Configuration _configuration;
    [SerializeField] private UISettings _uiSettings;
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        TimeService ts = new TimeService();
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems
            .Add(new CashSystems(_uiSettings.CashUI))
            .Add(new BussinesInitSystem(_configuration, _uiSettings.BusinessPanelPrefab, _uiSettings.UiRoot))
            .Add(new LevelUpSystem())
            .Add(new UpgradeSystem(_uiSettings.UpgradeButton))
            .Add(new BusinessProgressSystem(ts))
            .Add(new BusinessIncomeSystem())
            .Add(new BusinessPanelSystem())
            .Add(new TimeSystem(ts))
            .Add(new BusinessProgressSystem(ts))
            .Init();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }
        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }

    private void OnApplicationPause()
    {
        if(_systems != null)
            SaveSystem.Save(_systems);
    }

    private void OnApplicationQuit()
    {
        if (_systems != null)
            SaveSystem.Save(_systems);
    }
}
