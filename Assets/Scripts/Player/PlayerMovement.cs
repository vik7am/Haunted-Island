using UnityEngine;

namespace HauntedIsland.Old
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        private CharacterController characterController;
        private float horizontalInput;
        private float verticalInput;
        private Vector3 movementDirection;
        private bool movementEnabled;

        private void Awake() {
            characterController = GetComponent<CharacterController>();
        }

        private void Update(){
            if(movementEnabled)
                UpdatePlayerMovement();
        }

        public void SetMovementEnabled(bool value) => movementEnabled = value;

        private void UpdatePlayerMovement(){
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            movementDirection = transform.forward*verticalInput + transform.right*horizontalInput;
            movementDirection = movementDirection.normalized;
            characterController.SimpleMove(movementDirection * movementSpeed);
        }

        public bool IsIdle(){
            return movementDirection == Vector3.zero;
        }
    }
}