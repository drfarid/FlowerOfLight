using Ditzelgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputController : MonoBehaviour
{

	float speed = 4f;
	float rotSpeed = 80f;
	float rot = 0f;
	float gravity = 8f;

	Vector3 moveDir = Vector3.zero;
	CharacterController controller;
	Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
    	controller = gameObject.GetComponent<CharacterController>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    	if (controller.isGrounded) {
    		if (Input.GetKey(KeyCode.UpArrow)) {
    			playerAnimator.SetBool("isRunning", true);
    			moveDir = new Vector3(0, 0, 1);
    			moveDir *= speed; 
    			moveDir = transform.TransformDirection(moveDir);
    		}
    		if (Input.GetKeyUp(KeyCode.UpArrow)) {
    			moveDir = new Vector3(0, 0, 0);
    			playerAnimator.SetBool("isRunning", false);
    		}
    		controller.Move(moveDir * Time.deltaTime);
    	} 	
    	
    	if (playerAnimator.GetBool("isOnWater")) {
			if (Input.GetKey(KeyCode.UpArrow))
	            PhysicsHelper.ApplyForceToReachVelocity(GetComponent<Rigidbody>(), moveDir * speed * 4, speed);
	        if (Input.GetKey(KeyCode.DownArrow))
	            PhysicsHelper.ApplyForceToReachVelocity(GetComponent<Rigidbody>(), moveDir * -speed * 4, speed);
		}


    	if (Input.GetKey(KeyCode.T)) {
    		GameObject terrain = GameObject.Find("Terrain");
    		terrain.SetActive(false);
    		controller.enabled = false;
    		playerAnimator.SetBool("isOnWater", true);

    	}
    	
    	rot  += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
    	transform.eulerAngles = new Vector3(0, rot, 0);
    	moveDir.y -= gravity * Time.deltaTime;
    	

    	
    }
}
