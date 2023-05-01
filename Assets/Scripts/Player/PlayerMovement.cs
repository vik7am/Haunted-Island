using UnityEngine;

namespace HauntedIsland
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        private CharacterController characterController;
        private float horizontalInput;
        private float verticalInput;
        private Vector3 movementDirection;

        private void Awake() {
            characterController = GetComponent<CharacterController>();
        }

        private void Update(){
            UpdatePlayerMovement();
        }

        private void UpdatePlayerMovement(){
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            movementDirection = transform.forward*verticalInput + transform.right*horizontalInput;
            movementDirection = movementDirection.normalized;
            characterController.SimpleMove(movementDirection * movementSpeed);
        }
    }
}