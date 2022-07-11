using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattacks : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject projectilePartent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.X))
      {
          CatShot();
      }
    }

    private void CatShot()
    {
        Instantiate(projectile, projectilePartent.transform.position, this.transform.rotation);
    }
}
