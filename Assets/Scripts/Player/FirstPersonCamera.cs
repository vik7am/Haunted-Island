using UnityEngine;

namespace HauntedIsland
{
    public class FirstPersonCamera : MonoBehaviour
    {
        private Transform playerTransform;
        [SerializeField] private float cameraSensitivity;
        private float mouseX, mouseY;
        private float xRotation;
        private bool gameRunning;
    
        public void FollowPlayer(Transform playerTransform){
            gameRunning = true;
            this.playerTransform = playerTransform;
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, 1, 0);
            transform.localRotation = Quaternion.identity;
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        void Update(){
            if(!gameRunning)
                return;
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
}

