using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlataformerGenerator : MonoBehaviour
{
    [SerializeField] RuleTile Solid, Unsolid;
    [SerializeField] Tilemap map;
    public Vector2Int size;
    public bool Exotic, Restrict;

    void Start()
    {

        Vector3Int[] positions = new Vector3Int[size.x * size.y];
        RuleTile[] tileArray = new RuleTile[positions.Length];
        Dictionary<Vector2, RuleTile> dictionary = new Dictionary<Vector2, RuleTile>();

        for (int index = 0; index < positions.Length; index++)
        {
            Vector3Int pos = new Vector3Int(index / size.y, index % size.y, 0);

            positions[index] = pos;
            tileArray[index] = null;

            if (pos.y < size.y / 2 && pos.x > size.x - 5)
            {
                tileArray[index] = Solid;
            }
            else if (pos.x == 0 || pos.x >= size.x-1)
            {
                tileArray[index] = Solid;
            }
            else if (pos.y < 3)
            {
                tileArray[index] = Solid;
            }
            else if (pos.x > 5 && pos.x < size.x-5)
            {

                var prev = dictionary[new Vector2(pos.x, pos.y - 1)];
                var prev2 = dictionary[new Vector2(pos.x, pos.y - 2)];
                var prev3 = dictionary[new Vector2(pos.x, pos.y - 3)];

                var side = dictionary[new Vector2(pos.x - 1, pos.y)];
                var side2 = dictionary[new Vector2(pos.x - 2, pos.y)];
                var side3 = dictionary[new Vector2(pos.x - 3, pos.y)];

                /*
                if (prev == Solid)
                {
                    if (pos.y < 6)
                    {
                        tileArray[index] = Random.Range(0, pos.y) >= 3 ? null : Solid;

                        dictionary.Add(new Vector2(pos.x, pos.y), tileArray[index]);
                        Debug.Log(dictionary[new Vector2(pos.x, pos.y)]);
                        continue;
                    }

                }*/
                if (prev == null)
                {
                    if (prev2 == null)
                    {
                        if (prev3 == null)
                        {
                            tileArray[index] = Random.Range(0, pos.y) >= 2 ? null : Solid;
                        }
                    }
                }
                else if (prev == Solid)
                {
                    if (Exotic)
                    {
                        if (prev2 == Solid)
                        {
                            if (prev3 == Solid)
                            {
                                tileArray[index] = Random.Range(0, pos.y) >= 3 ? null : Solid;
                            }
                            else
                            {
                                tileArray[index] = null;
                            }
                        }
                        else
                        {
                            tileArray[index] = null;
                        }
                        if (Restrict)
                        {
                            dictionary.Add(new Vector2(pos.x, pos.y), tileArray[index]);
                            continue;
                        }
                    }
                    else
                    {
                        if (pos.y < 6)
                        {
                            tileArray[index] = Random.Range(0, pos.y) >= 3 ? null : Solid;

                            if (Restrict)
                            {
                                dictionary.Add(new Vector2(pos.x, pos.y), tileArray[index]);
                                continue;
                            }
                        }
                    }
                }

                if (side == Solid && pos.y > 6)
                {
                    if (side2 == Solid)
                    {
                        if (side3 == Solid)
                        {
                            tileArray[index] = Random.Range(0, pos.y) >= 3 ? null : Solid;
                        }
                        else
                        {
                            tileArray[index] = Random.Range(0, pos.y) >= 3 ? Solid : null;
                        }
                    }
                    else
                    {
                        tileArray[index] = Solid;
                    }
                }

            }
            dictionary.Add(new Vector2(pos.x, pos.y), tileArray[index]);
            Debug.Log(dictionary[new Vector2(pos.x, pos.y)]);
        }

        for (int index = positions.Length-1; index > 0; index--)
        {
            Vector3Int pos = new Vector3Int(index / size.y, index % size.y, 0);

            if (pos.y < size.y-1)
            {
                Debug.Log(pos);

                var up = dictionary[new Vector2(pos.x, pos.y + 1)];
                var cur = dictionary[new Vector2(pos.x, pos.y)];
                Debug.Log(cur);
                Debug.Log(up);
                if (cur == null)
                {
                    if (up == Solid || up == Unsolid)
                    {
                        tileArray[index] = Unsolid;
                        dictionary[new Vector2(pos.x, pos.y)] = Unsolid;
                    }
                }
            }
        }


        map.SetTiles(positions, tileArray);

        map.SetTile(new Vector3Int(5, 4, 0), Solid);
        map.SetTile(new Vector3Int(5, 3, 0), Solid);
        map.SetTile(new Vector3Int(4, 3, 0), Solid);
        map.SetTile(new Vector3Int(0, 0, 0), Solid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
