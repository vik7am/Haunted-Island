using HauntedIsland.Manager;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class FPSCamera : MonoBehaviour
    {
        private int cameraSensitivity;
        private Transform playerTransform;
        private float mouseX, mouseY;
        private float xRotation;
        private bool cameraActive;
        private Vector3 orignalPosition;
        private Quaternion originalRotation;
        private Camera _camera;
        private Color skyColor;

        private void Awake() {
            _camera = GetComponent<Camera>();
            skyColor = new Color(0.4581257f, 0.5297253f, 0.6698113f, 0);
        }

        private void Start() {
            cameraSensitivity = GameManager.Instance.mouseSensitivity;
            orignalPosition = transform.position;
            originalRotation = transform.rotation;
        }

        private void OnEnable() {
            PlayerController.onPlayerKilled += DisableCameraMovement;
            LightManager.onDayNightChange += ChangeSkyColor;
        }

        private void OnDisable() {
            PlayerController.onPlayerKilled -= DisableCameraMovement;
            LightManager.onDayNightChange -= ChangeSkyColor;
        }

        void LateUpdate(){
            if(!cameraActive) return;
            UpdatateVerticalMovement();
            UpdateHorizontalMovement();
        }

        public void SetPlayerTransform(Transform playerTransform){
            this.playerTransform = playerTransform;
            cameraActive = true;
        }

        private void DisableCameraMovement(){
            cameraActive = false;
        }

        private void ChangeSkyColor(bool isDay){
            _camera.backgroundColor = (isDay)? skyColor: Color.black;
        }
    
        private void UpdatateVerticalMovement(){
            mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation , 0, 0);
        }
    
        private void UpdateHorizontalMovement(){
            mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            playerTransform.Rotate(Vector3.up, mouseX);
        }
    }
}
