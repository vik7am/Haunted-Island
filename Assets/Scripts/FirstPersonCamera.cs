using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraSensitivity;
    private float mouseX, mouseY;
    private float xRotation;

    void Awake(){
        transform.SetParent(playerTransform);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        UpdatateCameraRotation();
        UpdatePlayerRotation();
    }

    private void UpdatateCameraRotation(){
        mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation , 0, 0);
    }

    private void UpdatePlayerRotation(){
        mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        playerTransform.Rotate(Vector3.up, mouseX);
    }
}
