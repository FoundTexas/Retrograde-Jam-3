using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneLoader : MonoBehaviour
{
    public static bool overRide = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ReandomScene()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings-2);
        int scene = Random.Range(
            1,
            SceneManager.sceneCountInBuildSettings - 1
            );

        LoadScene(scene);
    }

    public void LoadlastScene()
    {
        StartCoroutine(LoadRoutine(SceneManager.sceneCountInBuildSettings-1));
    }
    public void LoadScene(int scene)
    {
        if (!overRide)
        {
            overRide = true;
            anim.SetTrigger("event");
            StartCoroutine(LoadRoutine(scene));
        }
    }
    IEnumerator LoadRoutine(int scene)
    {
        yield return new WaitForSeconds(1.3f);
        overRide = false;
        SceneManager.LoadScene(scene);


    }
}
