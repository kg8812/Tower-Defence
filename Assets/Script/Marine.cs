using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marine : Unit_Ally
{
    public override void Attack(GameObject target)
    {
        IOnHit hit = target.GetComponent<IOnHit>();

        hit?.OnHit(Atk,AtkType);
        Debug.Log("АјАн");
    } 
}
