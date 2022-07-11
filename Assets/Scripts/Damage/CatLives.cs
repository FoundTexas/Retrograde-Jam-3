using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLives : MonoBehaviour, IDamaged
{
    [SerializeField] GameObject[] lives;
    [SerializeField] SpriteRenderer sr;

    [SerializeField]
    private float tickTime;

    private float curTickTime;

    bool dmg;


    // Start is called before the first frame update
    void Start()
    {
        curTickTime = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        DamagedTime();
    }

    private void DamagedTime()
    {
        if(dmg)
        {
            if(curTickTime >= tickTime)
            {
                sr.color = new Color(1, 1, 1, 1);
                dmg = false;
                curTickTime = 0;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                curTickTime += Time.deltaTime;
            }
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < lives.Length; i++)
        {
            if (i+1 > GameManager.Getlives())
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }
    }

    public void Heal(int hp)
    {
        GameManager.UpdateLives(+1);
        UpdateUI();
    }

    public void TakeDamage(int dm)
    {
        if (!dmg)
        {
            GameManager.UpdateLives(-1);
            dmg = true;
            UpdateUI();
        }
    }

    public void dead()
    {
        throw new System.NotImplementedException();
    }

}
