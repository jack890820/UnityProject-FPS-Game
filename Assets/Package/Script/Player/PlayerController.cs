using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject miniMap;

    // Start is called before the first frame update
    void Start()
    {
        miniMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenMiniMap();
    }

    private void OpenMiniMap()
    {
        if (Input.GetKeyDown(KeyCode.M) && miniMap.activeSelf == false)
        {
            miniMap.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && miniMap.activeSelf == true)
        {
            miniMap.SetActive(false);
        }
    }
}
