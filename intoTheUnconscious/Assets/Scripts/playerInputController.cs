using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputController : MonoBehaviour
{

	Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    	//if you stop having a forward component
    	//then you are either standing still or turning
        if (Input.GetKeyDown("space")) {
        	Debug.Log("pressed space");
            playerAnimator.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp("space")) {
        	Debug.Log("released it");
        	playerAnimator.SetBool("isRunning", false);
        }
    }
}
