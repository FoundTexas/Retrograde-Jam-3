using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class LeaderBoardService : MonoBehaviour
{
    static FirebaseFirestore db;
    [SerializeField] TextMeshProUGUI[] Names, Sacores;
    [SerializeField] TMP_InputField nickName;
    [SerializeField] GameObject NickNameMenu, loading;
    
   public List<ScoreDTO> top10;
    public bool valid = false, load = true, update = false;

    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        RefreshView();
    }
    private void Update()
    {
        NickNameMenu.SetActive(valid);
        loading.SetActive(load);

        if (update)
        {
            update = false;
            top10.Sort(
            delegate (ScoreDTO p1, ScoreDTO p2)
            {
                return p2.score.CompareTo(p1.score);
            }
            );

            for (int i = 0; i < 10; i++)
            {
                if (top10.Count > i)
                {
                    Names[i].text = top10[i].nickName;
                    Sacores[i].text = top10[i].score.ToString();
                }
                else
                {
                    Names[i].text = "";
                    Sacores[i].text = "0";
                }
            }
        }
    }

    void RefreshView()
    {
        Debug.Log("Started");
        top10.Clear();

        int score = ScoreManager.GetScore();

        CollectionReference citiesRef = db.Collection("Scores");
        Query firstQuery = citiesRef.OrderByDescending("score").Limit(15);

        Debug.Log("Started2");

        firstQuery.GetSnapshotAsync().ContinueWith((task) =>
        {
            var Leaderboardsnapshot = task.Result.Documents;
            foreach (DocumentSnapshot documentSnapshot in Leaderboardsnapshot)
            {
                Debug.Log(string.Format("Added document with ID: {0}.", documentSnapshot.Id));

                ScoreDTO tmp = new ScoreDTO(
                    documentSnapshot.Id,
                    documentSnapshot.GetValue<string>("nickName"),
                    documentSnapshot.GetValue<int>("score")
                    );

                Debug.Log(tmp.nickName);

                if (!valid && tmp.score < score)
                {
                    valid = true;
                }
                Debug.Log(string.Format("Added document with ID: {0}.", tmp.score));
                top10.Add(tmp);
            }

            if (!valid && top10.Count < 10)
            {
                valid = true;
            }

            load = false;
            update = true;
            Debug.Log(valid);
            Debug.Log("Refreshed");
        });
    }


    public void SubmmitNewHighScore()
    {
        load = true;
        int score = ScoreManager.GetScore();
        ScoreDTO scoreDTO = new ScoreDTO("", nickName.text,score);

        if (top10.Count > 10)
        {
            ScoreDTO delete = top10[top10.Count];
            DeleteLast(delete);
        }

        db.Collection("Scores").AddAsync(scoreDTO).ContinueWithOnMainThread(task => {
            DocumentReference addedDocRef = task.Result;
            Debug.Log(string.Format("Added document with ID: {0}.", addedDocRef.Id));

            top10.Add(scoreDTO);

            update = true;

            valid = false;

            load = false;
        });
    }

    void DeleteLast(ScoreDTO last)
    {
        DocumentReference docRef = db.Collection("Scores").Document(last.id);
        docRef.DeleteAsync();
        top10.Remove(last);
    }
}
