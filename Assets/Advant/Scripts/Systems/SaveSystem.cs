using UnityEngine;
using Leopotam.EcsLite;

public static class SaveSystem
{
    public const string BusinessSaveKey = "business_save_system";

    public static void Save(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        var filter = world.Filter<Business>().End();
        EcsPool<Business> buisnessPool = world.GetPool<Business>();
        SerializableList<Business> activeBusinesses = new SerializableList<Business>();
        foreach (int entity in filter)
        {
            ref Business business = ref buisnessPool.Get(entity);
            activeBusinesses.List.Add(business);
        }
        PlayerPrefs.SetString(BusinessSaveKey, JsonUtility.ToJson(activeBusinesses));
        Debug.Log("Game Saved");
    }
}
