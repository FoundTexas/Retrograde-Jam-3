using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLives : MonoBehaviour
{
    [SerializeField]
    private int lives;

    private AttackCollide attack;

    [SerializeField]
    private float tickTime;

    private float originalTickTime;


    // Start is called before the first frame update
    void Start()
    {
        attack = gameObject.GetComponent<AttackCollide>();
        originalTickTime = tickTime;
    }

    // Update is called once per frame
    void Update()
    {
        MeeleDamage();
    }

    private void MeeleDamage()
    {
        if(attack.inCollide())
        {
            tickTime -= Time.deltaTime;

            if(tickTime <= 0)
            {
                lives = (lives - 1);
                tickTime = originalTickTime;
            }
        }
        else
        {
            tickTime = 0;
        }
    }

    public void ProjectileDamage()
    {
        lives = (lives - 1);
    }

}
