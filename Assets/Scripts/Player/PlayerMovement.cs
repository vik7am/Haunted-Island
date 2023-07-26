using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity;
        private bool movementEnabled;
        private bool groundedPlayer;
        private Vector3 horizontalInput;
        private Vector3 verticalInput;
        private Vector3 inputDirection;
        private Vector3 inputVelocity;
        private Vector3 playerVelocity;
        private CharacterController characterController;

        private void Awake() {
            characterController = GetComponent<CharacterController>();
            movementEnabled = true;
        }

        private void Update(){
            if(!movementEnabled) return;
            GroundCheck();
            GetPlayerInput();
            UpdatePlayerVelocity();
            CheckJumpInput();
            ApplyGravity();
            MovePlayer();
        }

        private void GroundCheck(){
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0){
                playerVelocity.y = 0f;
            }
        }

        private void GetPlayerInput(){
            horizontalInput = Input.GetAxisRaw("Horizontal") * transform.right;
            verticalInput = Input.GetAxisRaw("Vertical") * transform.forward;
        }

        private void UpdatePlayerVelocity(){
            inputDirection = (horizontalInput + verticalInput).normalized;
            inputVelocity = inputDirection * playerSpeed;
            playerVelocity.x = inputVelocity.x;
            playerVelocity.z = inputVelocity.z;
        }

        private void CheckJumpInput(){
            if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        private void ApplyGravity(){
            playerVelocity.y += gravity * Time.deltaTime;
        }

        private void MovePlayer(){
            characterController.Move(playerVelocity * Time.deltaTime);
        }

        public void SetMovementEnabled(bool value) => movementEnabled = value;
    }
}
