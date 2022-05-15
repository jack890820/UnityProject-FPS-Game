using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFocus : MonoBehaviour
{
    [SerializeField] GameObject spriteObject;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player.transform);

        Debug.DrawLine(transform.position, player.transform.position, Color.red);
    }
}
