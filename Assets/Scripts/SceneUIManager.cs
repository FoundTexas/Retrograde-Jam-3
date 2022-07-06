using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventSystem))]
[RequireComponent(typeof(StandaloneInputModule))]
public class SceneUIManager : MonoBehaviour
{
    GameObject currentSelect;
    EventSystem ES;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ES = GetComponent<EventSystem>();

        currentSelect = ES.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                ES.SetSelectedGameObject(currentSelect);
            }
            else
            {
                currentSelect = ES.currentSelectedGameObject;
            }
        }
    }

    public void SetValue(GameObject select)
    {
        currentSelect = select;
        ES.SetSelectedGameObject(currentSelect);
    }
}
