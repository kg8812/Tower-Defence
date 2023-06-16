using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussive : IDamage
{
    public float CalculateDmgRatio(UnitType type)
    {
        float rate = 1;

        switch (type)
        {
            case UnitType.Small:
                rate = 1f;
                break;
                case UnitType.Medium:
                rate = 0.5f;
                break;
                case UnitType.Large:
                rate = 0.25f;
                break;
        }
        return rate;
    }

}

public class Explosive : IDamage
{
    public float CalculateDmgRatio(UnitType type)
    {
        float rate = 1;

        switch (type)
        {
            case UnitType.Small:
                rate = 0.5f;
                break;
            case UnitType.Medium:
                rate = 0.75f;
                break;
            case UnitType.Large:
                rate = 1f;
                break;
        }
        return rate;
    }
}

public class Normal : IDamage
{
    public float CalculateDmgRatio(UnitType type)
    {
        return 1;
    }
}

public class Magic : IDamage
{
    public float CalculateDmgRatio(UnitType type)
    {
        return 1;
    }
}
