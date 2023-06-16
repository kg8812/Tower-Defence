using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit_Ally : Unit
{
    float atkTime = 0;
    public IDamage IDmg { get; private set; }

    private void Start()
    {
        switch (AtkType)
        {
            case AtkType.Concussive:
                IDmg = new Concussive();
                break;
            case AtkType.Normal:
                IDmg = new Normal();
                break;
            case AtkType.Explosive:
                IDmg = new Explosive();
                break;
            case AtkType.Magic:
                IDmg = new Magic();
                break;
        }
    }
    private void Update()
    {        
        atkTime += Time.deltaTime;

        if (atkTime > 1 / AtkSpeed)
        {           
            Collider2D target = Physics2D.OverlapCircle(transform.position, AtkRange + 1, LayerMask.GetMask("Enemy"));
            if (target != null)
            {
                Attack(target.gameObject);
                atkTime = 0;
            }
        }
    }

    public abstract void Attack(GameObject target);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AtkRange + 1);
    }  
}
