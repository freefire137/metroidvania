using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public int jumpSpeed = 6;
	private Vector3 jumpForce;
	public int moveSpeed = 3;
	private bool isGrounded;
	public bool doubleJumpEnabled;
	private int jumpsLeft;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter() {
		isGrounded = true;
		Debug.Log("grounded");
		jumpsLeft = MaxJumps();
	}
	void OnCollisionStay() {
		//isGrounded = true;
	}

	void OnCollisionExit() {
		isGrounded = false;
		Debug.Log("ungrounded");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody myRigid = this.GetComponent<Rigidbody>();
		myRigid.velocity = new Vector3(moveSpeed*Input.GetAxis("Horizontal"),myRigid.velocity.y,0f);
		
		if (jumpsLeft > 0 && Input.GetKey(KeyCode.Space)) {
			myRigid.AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);
			jumpsLeft--;

		}
		//Camera.main
		//Debug.Log()
	}

	int MaxJumps(){
		if (doubleJumpEnabled)
			return 2;
		return 1;
	}
}
