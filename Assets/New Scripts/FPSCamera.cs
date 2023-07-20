using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class FPSCamera : MonoBehaviour
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

        private void OnDisable() {
            PlayerController.onPlayerKilled -= DisableCameraMovement;
        }

        private void DisableCameraMovement(){
            cameraDisabled = true;
        }

        private void Start() {
            orignalPosition = transform.position;
            originalRotation = transform.rotation;
            FollowPlayer(playerTransform);
        }
    
        public void FollowPlayer(Transform playerTransform){
            this.playerTransform = playerTransform;
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, 1, 0);
            transform.localRotation = Quaternion.identity;
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
