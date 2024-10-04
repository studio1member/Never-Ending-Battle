using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : StatusPlayerVirtual
{
    private void Reset()
    {
        max_HP = 500f;
        current_HP = 500f;
        hpSpeed = 2f;

        current_MP = 200f;
        max_MP = 200f;
        mpSpeed = 3f;

        damage = 20f;
        magical_damage = 0f;
    }
}
