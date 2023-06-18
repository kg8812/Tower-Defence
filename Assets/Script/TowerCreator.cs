using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class TowerCreator : IObserver
{
    List<Unit_Ally> normalTowers;
    List<Unit_Ally> rareTowers;
    List<Unit_Ally> epicTowers;
    List<Unit_Ally> uniqueTowers;
    
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

    public void Notify(Subject subject)
    {
        TowerManager tm = subject.GetComponent<TowerManager>();
        normalTowers = tm.NormalTowers;
        rareTowers = tm.RareTowers;
        epicTowers = tm.EpicTowers;
        uniqueTowers = tm.UniqueTowers;
    }

    public void Upgrade(ref Unit_Ally tower)
    {
        if (tower.UnitRank == UnitRank.Unique) return;

        Object.Destroy(tower.gameObject);

        switch (tower.UnitRank)
        {
            case UnitRank.Normal:
                tower = Object.Instantiate(RandomRare);
                break;
            case UnitRank.Rare:
                tower = Object.Instantiate(RandomEpic);
                break;
            case UnitRank.Epic:
                tower = Object.Instantiate(RandomUnique);
                break;          
        }
    }

}
