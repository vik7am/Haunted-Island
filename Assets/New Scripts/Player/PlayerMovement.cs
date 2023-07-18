using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Awake() {
            characterController = GetComponent<CharacterController>();
        }

        private void Start() {
            movementEnabled = true;
        }

        private void Update(){
            if(!movementEnabled) return;
            GetPlayerMovementInput();
            UpdatePlayerMovement();
        }

        private void GetPlayerMovementInput(){
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.z = Input.GetAxisRaw("Vertical");
        }

        private void UpdatePlayerMovement(){
            movementDirection = transform.forward*movementInput.z + transform.right*movementInput.x;
            characterController.SimpleMove(movementDirection.normalized * movementSpeed);
        }

        public bool IsIdle => movementDirection == Vector3.zero;

        public void SetMovementEnabled(bool value) => movementEnabled = value;
    }
}
