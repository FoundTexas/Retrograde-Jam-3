using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollide : MonoBehaviour
{

    [SerializeField]
    private List<string> tags;
    public bool inCollision;

    private CatLives catLives;
    // Start is called before the first frame update

    void Start()
    {
        catLives = gameObject.GetComponent<CatLives>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(tags.Exists(x => x.Equals(coll.gameObject.tag)))
        {
            inCollision = true;
        }

        if(coll.gameObject.tag == "Projectile")
        {
            //catLives.ProjectileDamage();
            Destroy(coll.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(tags.Exists(x => x.Equals(coll.gameObject.tag)))
        {
            inCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if(tags.Exists(x => x.Equals(coll.gameObject.tag)))
        {
            inCollision = false;
        }
    }

    public bool inCollide()
    {
        return (inCollision);
    }




}
