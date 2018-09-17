using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_PlayerMovement : MonoBehaviour {
	// class for player's movement

	public float WalkSpeed;
	public float SprintSpeed;

	private CharacterController myController;

	void Start(){
		myController = GetComponent<CharacterController> ();
	} // end start()

	void Update(){
		
	} // end update

} // end player movement class
