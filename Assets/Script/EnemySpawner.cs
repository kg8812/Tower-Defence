using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Unit_Enemy enemy;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform[] wayPoints;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 1);
    }
    void Spawn()
    {
        Unit_Enemy enm = Instantiate(enemy, startPoint.transform.position, Quaternion.identity);
        enm.wayPoints = wayPoints;
    }
}
