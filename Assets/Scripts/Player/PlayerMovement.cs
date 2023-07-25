using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        private CharacterController characterController;
        private Vector3 movementInput;
        private Vector3 movementDirection;
        private bool movementEnabled;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;

        private void Awake() {
            characterController = GetComponent<CharacterController>();
        }

        private void Start() {
            movementEnabled = true;
        }

        private void Update(){
            if(!movementEnabled) return;
            CheckGround();
            GetPlayerMovementInput();
            UpdatePlayerMovement();
            CheckJumpInput();
            ApplyGravity();
            characterController.Move(playerVelocity * Time.deltaTime);
        }

        private void ApplyGravity(){
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        private void CheckJumpInput(){
            if (Input.GetButtonDown("Jump") && groundedPlayer)
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        private void CheckGround(){
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0){
                playerVelocity.y = 0f;
            }
        }

        private void GetPlayerMovementInput(){
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.z = Input.GetAxisRaw("Vertical");
        }

        private void UpdatePlayerMovement(){
            movementDirection = transform.forward*movementInput.z + transform.right*movementInput.x;
            movementDirection = movementDirection.normalized * movementSpeed;
            playerVelocity.x = movementDirection.x;
            playerVelocity.z = movementDirection.z;
        }

        public bool IsIdle => movementDirection == Vector3.zero;

        public void SetMovementEnabled(bool value) => movementEnabled = value;
    }
}
