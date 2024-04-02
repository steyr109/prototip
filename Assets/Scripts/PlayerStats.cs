using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int lvl = 1;
    public int experience = 0;

    int expNeedFor2 = 2;

    public Quest quest;

    public void GainEXP(int exp)
    {
        experience += exp;
        if(exp >= expNeedFor2)
        {
            lvl += 1;
            Debug.Log("Уровень повышен!");
        }
    }
}
