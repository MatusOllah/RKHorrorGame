using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
public class Ladder : MonoBehaviour {
    public float speed = 5f;

    CharacterController characterController;
    PlayerMovement playerMovement;
    Vector3 moveDirection = Vector3.zero;
    bool isClimbing = false;

    void Start() {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update() {
        if (isClimbing) {
            float verticalInput = Input.GetAxis("Vertical");
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), verticalInput * speed, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Ladder") {
            Debug.Log("climbing");
            playerMovement.enabled = false;
            isClimbing = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Ladder") {
            Debug.Log("not climbing");
            playerMovement.enabled = true;
            isClimbing = false;
        }
    }
}
