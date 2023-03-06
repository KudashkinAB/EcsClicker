using System;
using UnityEngine;

public static class Cash
{
    private static float s_cash = -1;
    public static Action<float> OnCashChanged;
    const string _cashKey = "advant_cash_key";

    public static float PlayerCash
    {
        get
        {
            if(s_cash < 0)
            {
                if(PlayerPrefs.HasKey(_cashKey))
                {
                    s_cash = PlayerPrefs.GetFloat(_cashKey);
                }
                else
                {
                    PlayerCash = 0f;
                }
            }
            return s_cash;
        }
        set
        {
            s_cash = Mathf.Max(value, 0);
            PlayerPrefs.SetFloat(_cashKey, s_cash);
            OnCashChanged?.Invoke(s_cash);
        }
    }

    public static bool TryToSpend(float amountToSpend)
    {
        if(PlayerCash >= amountToSpend)
        {
            PlayerCash -= amountToSpend;
            return true;
        }
        else
        {
            return false;
        }
    }
}
