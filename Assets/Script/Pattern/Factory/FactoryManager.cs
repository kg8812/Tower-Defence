using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager Instance;
    private void Awake()
    {
        Instance = this;
        Enemy = new Factory_Enemy(enemies);
    }

    [SerializeField] Unit_Enemy[] enemies;
    [SerializeField] Unit_Ally[] allies;

    public Factory_Enemy Enemy { get; private set; }
    

}
