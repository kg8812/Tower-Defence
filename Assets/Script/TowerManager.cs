using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2 worldPoint;
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject[] towerPrefabs;   

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
            foreach (Vector3Int cellpos in tilemap.cellBounds.allPositionsWithin)
            {
                tilemap.SetColor(cellpos, Color.white);
            }

            if (hit.collider != null)
            {
                
                
                Vector3Int tpos = tilemap.WorldToCell(hit.point);

                TileBase tile = tilemap.GetTile(tpos);

                Vector3 pos = tilemap.GetCellCenterWorld(tpos);

                if (tile != null)
                {
                    tilemap.SetTileFlags(tpos, TileFlags.None);
                    CreateTower(pos);
                    tilemap.SetColor(tpos, Color.red);
                }
            }
        }
    }

    void CreateTower(Vector3 pos)
    {
        int rand = Random.Range(0,towerPrefabs.Length);
        Instantiate(towerPrefabs[rand],pos,Quaternion.identity);
    }
}
