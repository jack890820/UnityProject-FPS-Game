using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public static Raycast instance;
    [SerializeField] float rayRange = 10f;
    [SerializeField] public GameObject playerCursor;
    [SerializeField] public bool cursorActive;
    [SerializeField] public float fillAmountOB;
    [SerializeField] public float waitTime;
    [SerializeField] public Image progressBar;
    [SerializeField] public GameObject interactableText;


    private void Awake() 
    {
        instance = this;
    }

    void Start() 
    {
        playerCursor.SetActive(false);
        interactableText.SetActive(false);
        cursorActive = false;
    }
    public void LateUpdate()
    {
        PlayerRaycast();
    }

    public void PlayerRaycast()
    {
        Ray playerRay = new Ray(transform.position, transform.forward * rayRange);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayRange);

        if (Physics.Raycast(playerRay, out hit, rayRange, LayerMask.GetMask("Interactable")))
        {
            playerCursor.SetActive(true);
            cursorActive = true;

            if(Physics.Raycast(playerRay, out hit, (rayRange - 1f), LayerMask.GetMask("Interactable")))
            {
                fillAmountOB += (Time.deltaTime / waitTime);
                progressBar.fillAmount = fillAmountOB;
            }            
        }
        else
        {            
            playerCursor.SetActive(false);
            cursorActive = false;

            interactableText.SetActive(false);
            fillAmountOB = 0;
            progressBar.fillAmount = 0; 
        }

        if (progressBar.fillAmount == 1)
        {
            interactableText.SetActive(true);
        }
    }
}
