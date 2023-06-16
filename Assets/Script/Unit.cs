using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Small,
    Medium,
    Large
}

public enum AtkType
{
    Concussive,
    Normal,
    Explosive,
    Magic
}

public abstract class Unit : MonoBehaviour,IOnHit
{
    [SerializeField] float maxHp;
    [SerializeField] float curHp;
    [SerializeField] UnitType unitType;
    [SerializeField] AtkType atkType;
    [SerializeField] float atk;
    [SerializeField] float def;
    [SerializeField] float atkSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float atkRange;

    int upgrade;

    public float MaxHp { get { return maxHp; } }
    public float CurHp { get { return curHp; }
        set
        {
            if (value > MaxHp) curHp = MaxHp;
            else if (value < 0) curHp = 0;
            else curHp = value;
        }
    }
    public UnitType UnitType { get { return unitType; } }
    public AtkType AtkType { get { return atkType; } }
    public float Atk { get { return atk + upgrade * atk * 0.1f; } }
    public float AtkSpeed { get { return atkSpeed; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AtkRange { get { return atkRange * 2; } }

    public virtual void OnHit(float dmg, AtkType type)
    {
        CurHp -= dmg;
        if (CurHp == 0) Destroy(gameObject);
    }
    
}
