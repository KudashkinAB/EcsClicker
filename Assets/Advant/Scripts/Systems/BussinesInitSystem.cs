using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class BussinesInitSystem : IEcsInitSystem
{
    private Transform _uiRoot;
    private BusinessPanel _businessPanelPrefab;
    private Configuration _configuration;

    public BussinesInitSystem(Configuration configuration, BusinessPanel businessPanelPrefab, Transform uiRoot)
    {
        _businessPanelPrefab = businessPanelPrefab;
        _configuration = configuration;
        _uiRoot = uiRoot;
    }

    public void Init(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        EcsPool<Business> buisnessPool = world.GetPool<Business>();
        EcsPool<PanelComponent> progressPool = world.GetPool<PanelComponent>();
        EcsPool<BusinessTimeProgress> timeProgressPool = world.GetPool<BusinessTimeProgress>();
        List<Business> save = new List<Business>();
        if (PlayerPrefs.HasKey(SaveSystem.BusinessSaveKey))
        {
            save = JsonUtility.FromJson<SerializableList<Business>>(PlayerPrefs.GetString(SaveSystem.BusinessSaveKey)).List;
        }
        foreach(BusinessConfig config in _configuration.Businesses)
        {
            int entity = world.NewEntity();
            ref Business business = ref buisnessPool.Add(entity);
            string saveName = config.name;
            business.Config = config;
            business.Name = saveName;
            business.IncomeModifer = 1f;
            int loadIndex = save.FindIndex(f => f.Name == saveName);
            if(loadIndex < 0)
            {
                business.Level = config.BuyOnInit ? 1 : 0;
                business.Progress = 0f;
                business.Upgrades = new List<string>();
            }
            else
            {
                Business loadedBusiness = save[loadIndex];
                business.Level = loadedBusiness.Level;
                business.Progress = loadedBusiness.Progress;
                business.Upgrades = loadedBusiness.Upgrades;
                foreach(string upgradeName in business.Upgrades)
                {
                    BusinessUpgrade upgrade = business.Config.Upgrades.Find(f => f.name == upgradeName);
                    if(upgrade != null)
                    {
                        upgrade.Upgrade(ref business);
                    }
                }
            }

            BusinessPanel businessPanel = GameObject.Instantiate(_businessPanelPrefab, _uiRoot);
            businessPanel.SetBusiness(business);
            ref PanelComponent progressUI = ref progressPool.Add(entity);
            progressUI.BusinessPanel = businessPanel;

            timeProgressPool.Add(entity);
        }
    }
}
