using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : ScriptableObject
{
    [SerializeField] private List<BusinessConfig> _businesses = new List<BusinessConfig>();

    public List<BusinessConfig> Businesses => new List<BusinessConfig>(_businesses);
}
