﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpbar;

    public void SetHP(int hp)
    {
        hpbar.fillAmount = (float)hp / 100f;
    }
}
