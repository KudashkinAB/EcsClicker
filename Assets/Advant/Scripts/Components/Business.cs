using System.Collections.Generic;
using System;

[System.Serializable]
public struct Business 
{
    public string Name;
    public int Level;
    public float Progress;
    public List<string> Upgrades;
    [NonSerialized] public float IncomeModifer;
    [NonSerialized] public BusinessConfig Config;
}
