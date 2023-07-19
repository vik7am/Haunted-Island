using System;
using HauntedIsland.Player;
using UnityEngine;

namespace HauntedIsland.Old
{
    public class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField] private float cameraSensitivity;
        [SerializeField] private Transform playerTransform;
        private float mouseX, mouseY;
        private float xRotation;
        private bool cameraDisabled;
        private Vector3 orignalPosition;
        private Quaternion originalRotation;

        private void OnEnable() {
            PlayerController.onPlayerKilled += DisableCameraMovement;
        }

        private void DisableCameraMovement(){
            cameraDisabled = true;
        }

        private void Start() {
            orignalPosition = transform.position;
            originalRotation = transform.rotation;
            FollowPlayer(playerTransform);
        }

        public void DetachCamera(){
            transform.SetParent(null);
            transform.position = orignalPosition;
            transform.rotation = originalRotation;
            //gameRunning = false;
        }
    
        public void FollowPlayer(Transform playerTransform){
            //gameRunning = true;
            this.playerTransform = playerTransform;
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, 1, 0);
            transform.localRotation = Quaternion.identity;
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        void LateUpdate(){
            if(cameraDisabled) return;
            UpdatePlayerRotation();
            UpdatateCameraRotation();
            
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

