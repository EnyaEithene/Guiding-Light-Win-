using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItem : MonoBehaviour, IItem
{
    public int healAmount = 1;
    public static event Action<int> OnHealthCollect;
    public void Collect()
    {
        OnHealthCollect.Invoke(healAmount);
        Destroy(gameObject);
    }
}
