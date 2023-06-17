using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2 worldPoint;
    [SerializeField] Tilemap tilemap;
    readonly IDictionary<Vector3Int, Unit_Ally> towerDict = new Dictionary<Vector3Int, Unit_Ally>();
    TowerCreator creator = new();

    Vector3Int? lastClickedTile = null;

    private void Start()
    {        
        foreach(Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            tilemap.RemoveTileFlags(pos, TileFlags.LockColor);
        }
        
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
                        if (towerDict.ContainsKey(tpos))
                        {

                        }
                        else
                        {
                            if (GameManager.Instance.Gold >= 100)
                            {
                                Unit_Ally tower = creator.CreateTower(UnitRank.Normal);
                                tower.transform.position = pos;
                                towerDict.Add(tpos, tower);
                                tower.transform.SetParent(transform);                                
                            }
                        }                        
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

    
    
}