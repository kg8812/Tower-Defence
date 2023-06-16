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
        Unit_Enemy enm = FactoryManager.Instance.Enemy.CreateRandom();
        enm.transform.position = startPoint.transform.position;
        enm.transform.SetParent(transform);
        enm.wayPoints = wayPoints;
    }
}
