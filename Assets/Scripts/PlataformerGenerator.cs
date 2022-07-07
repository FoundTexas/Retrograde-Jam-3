using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlataformerGenerator : MonoBehaviour
{
    [SerializeField] RuleTile Solid, Unsolid;
    [SerializeField] Tilemap map;
    public Vector2Int size;

    void Start()
    {

        Vector3Int[] positions = new Vector3Int[size.x * size.y];
        TileBase[] tileArray = new TileBase[positions.Length];

        for (int index = 0; index < positions.Length; index++)
        {
            positions[index] = new Vector3Int(index % size.x, index / size.y, 0);
            tileArray[index] = index % 2 == 0 ? Solid : Unsolid;
        }

        map.SetTile(new Vector3Int(0, 0, 0), Unsolid);
        map.SetTiles(positions, tileArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
