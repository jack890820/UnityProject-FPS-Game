using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemont : MonoBehaviour
{
    //摘要
    //  負責Player相機旋轉、移動、移動角度
    //  Player移動、衝刺、跳躍

    public static PlayerMovemont instance;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private float maxMoveSpeed = 10f;
    [SerializeField]private float moveSpeed;    
    [SerializeField]private float jumpForce = 50f;
    [SerializeField] public float playerForce = 50f;
    [SerializeField]public bool isOnTheGround = true;

    [SerializeField]private float minX = -60f;
    [SerializeField]private float maxX = 60f;
    [SerializeField]private float sensitivity;
    public Camera playerCamera;
    [SerializeField]private float rotY = 0f;
    [SerializeField]private float rotX = 0f;
    [SerializeField] LocomotionStatePattern playerFSM;
    [SerializeField] bool isSprint;

    private void Awake() 
    {
        instance = this;
        moveSpeed = maxMoveSpeed;
        isSprint = false;
    }
    void FixedUpdate()
    {
        PlayerController();
        Sprint();
        PlayerJump();
    }
    void LateUpdate()
    {
        CameraMovemont();
    }

    private void CameraMovemont()
    {
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;

        rotX = Mathf.Clamp(rotX, minX, maxX);

        transform.localEulerAngles = new Vector3(0, rotY, 0);
        playerCamera.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }

    public void OnCollisionEnter(Collision other) 
    {
        if (other.collider.gameObject.tag == "Ground")    
        {
            isOnTheGround = true;
            playerFSM.Land();
        }
    }

    public void PlayerController()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime));        
    }

    public void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isSprint == false)
        {
            float sprintSpeed = maxMoveSpeed * 2f;
            moveSpeed = sprintSpeed;
            isSprint = true;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = maxMoveSpeed;
            isSprint = false;
        }
    }

    public void PlayerJump()
    {
        if (Input.GetButton("Jump") && isOnTheGround == true)
        {
            rb.velocity = new Vector3(rb.velocity.x , jumpForce, rb.velocity.z);
            isOnTheGround = false;
            playerFSM.Jump();
        }        
    }
}
