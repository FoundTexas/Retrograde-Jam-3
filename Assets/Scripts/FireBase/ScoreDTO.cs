using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;

[System.Serializable]
[FirestoreData]
public class ScoreDTO
{
    [SerializeField]
    public string id { get; set; }

    [FirestoreProperty]
    public string nickName { get; set; }
    [FirestoreProperty]
    public int score { get; set; }

    public ScoreDTO() { }

    public ScoreDTO(string id, string nickName, int score)
    {
        this.id = id;
        this.nickName = nickName;
        this.score = score;
    }
}
