using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSubjectCode
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]private float minX = -60f;
        [SerializeField]private float maxX = 60f;
        [SerializeField]private float sensitivity;
        public Camera playerCamera;
        [SerializeField]private float rotY = 0f;
        [SerializeField]private float rotX = 0f;

        void Start()
        {
            
        }

        void LateUpdate()
        {
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            rotX += Input.GetAxis("Mouse Y") * sensitivity;

            rotX = Mathf.Clamp(rotX, minX, maxX);

            transform.localEulerAngles = new Vector3(0, rotY, 0);
            playerCamera.transform.localEulerAngles = new Vector3 (-rotX, 0, 0);
        }
    }
}