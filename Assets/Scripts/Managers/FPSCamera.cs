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
        private Camera _camera;
        private Color skyColor;

        private void Awake() {
            _camera = GetComponent<Camera>();
            skyColor = new Color(0.4581257f, 0.5297253f, 0.6698113f, 0);
        }

        private void OnEnable() {
            PlayerController.onPlayerKilled += DisableCameraMovement;
            LightManager.onEnableDarkMode += OnEnabledarkMode;
        }

        private void OnDisable() {
            PlayerController.onPlayerKilled -= DisableCameraMovement;
            LightManager.onEnableDarkMode -= OnEnabledarkMode;
        }

        private void Start() {
            orignalPosition = transform.position;
            originalRotation = transform.rotation;
            FollowPlayer(playerTransform);
        }

        void LateUpdate(){
            if(cameraDisabled) return;
            UpdatePlayerRotation();
            UpdatateCameraRotation();
        }
        
        private void OnEnabledarkMode(bool status){
            Color color = (status)? Color.black: skyColor;
            _camera.backgroundColor = color;
        }

        private void DisableCameraMovement(){
            cameraDisabled = true;
        }

        public void ChangeBackgroundColor(){
            _camera.backgroundColor = Color.black;
        }
    
        public void FollowPlayer(Transform playerTransform){
            this.playerTransform = playerTransform;
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, 1, 0);
            transform.localRotation = Quaternion.identity;
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
