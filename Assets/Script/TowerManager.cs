using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : Subject
{
    RaycastHit2D hit;
    Vector2 worldPoint;
    [SerializeField] Tilemap tilemap;
    readonly IDictionary<Vector3Int, Unit_Ally> towerDict = new Dictionary<Vector3Int, Unit_Ally>();
    readonly TowerCreator creator = new();

    Vector3Int? lastClickedTile = null;

    [field: SerializeField] public List<Unit_Ally> NormalTowers { get; private set; }
    [field:SerializeField] public List<Unit_Ally> RareTowers{get;private set;}
    [field:SerializeField] public List<Unit_Ally> EpicTowers{get;private set;}
    [field:SerializeField] public List<Unit_Ally> UniqueTowers{get;private set;}
    private void Start()
    {
        Attach(creator);
        foreach(Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            tilemap.RemoveTileFlags(pos, TileFlags.LockColor);
        }
        NotifyAll();
    }
    private void Update()
    {
        worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(worldPoint, Vector2.down);
            ColorReset();

            if (hit.collider != null)
            {               
                
                Vector3Int tpos = tilemap.WorldToCell(hit.point);

                TileBase tile = tilemap.GetTile(tpos);

                Vector3 pos = tilemap.GetCellCenterWorld(tpos);

                if (tile != null)
                {                    
                    if (lastClickedTile.HasValue && tpos == lastClickedTile.Value)
                    {
                        Unit_Ally tower;

                        if (towerDict.ContainsKey(tpos))
                        {
                            tower = towerDict[tpos];

                            if (tower.UnitRank == UnitRank.Unique) return;

                            Unit_Ally consumer = FindSameTower(tower);

                            if(consumer != null)
                            {
                                RemoveTower(consumer);
                                creator.Upgrade(ref tower);
                                towerDict[tpos] = tower;
                                tower.transform.position = pos;
                                tower.transform.SetParent(transform);
                            }                                                
                        }
                        else
                        {
                            if (GameManager.Instance.Gold >= 100)
                            {
                                tower = creator.CreateTower(UnitRank.Normal);
                                towerDict.Add(tpos, tower);
                                tower.transform.position = pos;
                                tower.transform.SetParent(transform);                                
                            }
                        }
                        lastClickedTile = null;
                    }
                    else
                    {
                        lastClickedTile = tpos;
                        tilemap.SetColor(tpos, Color.red);
                    }
                }
                else
                {
                    lastClickedTile = null;
                }
            }
            else
            {
                lastClickedTile = null;
            }
        }
    }
    
    void ColorReset()
    {
        foreach (Vector3Int cellpos in tilemap.cellBounds.allPositionsWithin)
        {
            tilemap.SetColor(cellpos, Color.white);
        }
    }      

    Unit_Ally FindSameTower(Unit_Ally tower)
    {
        List<Unit_Ally> list = new (towerDict.Values);

        list.Remove(tower);

        foreach (Unit_Ally item in list)
        {
            if (item.name == tower.name)
            {
                return item;
            }
        }

        return null;
    }

    void RemoveTower(Unit_Ally tower)
    {
        foreach(KeyValuePair<Vector3Int,Unit_Ally> item in towerDict)
        {
            if(item.Value == tower)
            {
                towerDict.Remove(item.Key);
                break;
            }
        }

        Destroy(tower.gameObject);
    }
}