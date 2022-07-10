using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylife : MonoBehaviour, IDamaged
{
    [SerializeField] int score = 10;
    [SerializeField] int hintpoint = 1;

    public void Start()
    {
        FindObjectOfType<RenderManager>().Add(this.gameObject);
    }

    public void dead()
    {
        ScoreManager.ChangeScore(score);
        FindObjectOfType<RenderManager>().Remove(this.gameObject);
    }

    public void Heal(int hp)
    {
        hintpoint += hp;
    }

    public void TakeDamage(int dmg)
    {
        hintpoint -= dmg;
    }

}
