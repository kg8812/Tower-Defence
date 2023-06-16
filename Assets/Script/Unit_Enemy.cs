using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Enemy : Unit
{
    Transform nextPoint;
    public Transform[] wayPoints;
    int count = 0;
    private void Start()
    {       
        nextPoint = wayPoints[count++];
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, Time.deltaTime * MoveSpeed);

        if(Vector2.Distance(transform.position, nextPoint.position) < 0.1f)
        {
            transform.position = nextPoint.position;

            if (count < wayPoints.Length)
            {
                nextPoint = wayPoints[count++];
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
