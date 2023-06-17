using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class TowerCreator
{
    [SerializeField] List<Unit_Ally> normalTowers = new();
    [SerializeField] List<Unit_Ally> rareTowers = new();
    [SerializeField] List<Unit_Ally> epicTowers = new();
    [SerializeField] List<Unit_Ally> uniqueTowers = new();

    public Unit_Ally RandomNormal
    {
        get
        {
            if (normalTowers.Count == 0) return null;

            int rand = Random.Range(0, normalTowers.Count);

            return normalTowers[rand];
        }
    }
    public Unit_Ally RandomRare
    {
        get
        {
            if (rareTowers.Count == 0) return null;

            int rand = Random.Range(0, rareTowers.Count);

            return rareTowers[rand];
        }
    }
    public Unit_Ally RandomEpic
    {
        get
        {
            if (epicTowers.Count == 0) return null;

            int rand = Random.Range(0, epicTowers.Count);

            return epicTowers[rand];
        }
    }
    public Unit_Ally RandomUnique
    {
        get
        {
            if (uniqueTowers.Count == 0) return null;

            int rand = Random.Range(0, uniqueTowers.Count);

            return uniqueTowers[rand];
        }
    }
    public Unit_Ally CreateTower(UnitRank rank)
    {
        Unit_Ally tower = null;

        switch (rank)
        {
            case UnitRank.Normal:
                tower = Object.Instantiate(RandomNormal);
                break;
            case UnitRank.Rare:
                tower = Object.Instantiate(RandomRare);
                break;
            case UnitRank.Epic:
                tower = Object.Instantiate(RandomEpic);

                break;
            case UnitRank.Unique:
                tower = Object.Instantiate(RandomUnique);

                break;
        }        
        
        GameManager.Instance.AddGold(-100);
        return tower;
    }

    public void Upgrade(Unit_Ally tower)
    {
        switch (tower.UnitRank)
        {
            case UnitRank.Normal:
                Object.Instantiate(RandomNormal);
                break;
            case UnitRank.Rare:
                Object.Instantiate(RandomRare);
                break;
            case UnitRank.Epic:
                Object.Instantiate(RandomEpic);

                break;
            case UnitRank.Unique:
                Object.Instantiate(RandomUnique);
                break;
        }
    }

}
