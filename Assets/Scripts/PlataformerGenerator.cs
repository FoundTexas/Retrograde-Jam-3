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
        RuleTile[] tileArray = new RuleTile[positions.Length];
        Dictionary<Vector2, RuleTile> dictionary = new Dictionary<Vector2, RuleTile>();

        for (int index = 0; index < positions.Length; index++)
        {
            Vector3Int pos = new Vector3Int(index / size.y, index % size.y, 0);

            Debug.Log(pos);

            if (pos.x == 0 || pos.x == positions.Length-1)
            {
                positions[index] = pos;
                tileArray[index] = Solid;
            }
            else if (pos.y == 0)
            {
                positions[index] = pos;
                tileArray[index] = Solid;
            }
            else if (pos.x > 5 && pos.x < positions.Length - 1)
            {
                if (Random.Range(0, 5) >= 3)
                {
                    if (dictionary[new Vector2(pos.x, pos.y - 1)] == null)
                    {
                        positions[index] = pos;
                        tileArray[index] = Random.Range(0, 5) >= 3 ? Solid : Unsolid;
                    }
                }
            }
            dictionary.Add(new Vector2(pos.x, pos.y), tileArray[index]);
            Debug.Log(dictionary[new Vector2(pos.x, pos.y)]);


        }

        map.SetTile(new Vector3Int(0, 0, 0), Unsolid);
        map.SetTiles(positions, tileArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
