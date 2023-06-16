using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2 worldPoint;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Unit_Ally [] towerPrefabs;

    readonly IDictionary<Vector3Int,Unit_Ally> towerDict = new Dictionary<Vector3Int,Unit_Ally>();

    TileBase[] tiles;
    private void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        tiles = tilemap.GetTilesBlock(bounds);
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
            foreach (Vector3Int cellpos in tilemap.cellBounds.allPositionsWithin)
            {
                tilemap.SetColor(cellpos, Color.white);
            }

            if (hit.collider != null)
            {               
                
                Vector3Int tpos = tilemap.WorldToCell(hit.point);

                TileBase tile = tilemap.GetTile(tpos);

                Vector3 pos = tilemap.GetCellCenterWorld(tpos);

                if (tile != null&& !towerDict.ContainsKey(tpos))
                {
                    tilemap.SetTileFlags(tpos, TileFlags.None);
                    Unit_Ally tower = CreateTower(pos);
                    tilemap.SetColor(tpos, Color.red);
                    towerDict.Add(tpos, tower);
                }
            }
        }
    }

    Unit_Ally CreateTower(Vector3 pos)
    {
        int rand = Random.Range(0,towerPrefabs.Length);
        Unit_Ally tower = Instantiate(towerPrefabs[rand],pos,Quaternion.identity);
        tower.transform.SetParent(transform);
        return tower;
    }
}
