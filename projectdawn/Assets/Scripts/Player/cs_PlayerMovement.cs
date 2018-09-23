using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_PlayerMovement : MonoBehaviour {
	// class for player's movement and camera

	private CharacterController myController;
	private Vector3 moveDirection;
	private Camera myCamera;
	private GameObject myCameraPivot;

	[Header("Movement Settings")]

	public float WalkSpeed;
	public float SprintSpeed;
	public float JumpSpeed;
	public float Gravity;
	public bool isSprinting;


	[Header("Camera Settings")]

	public float CameraSensitivity;
	public float CameraZoom;
	public float CameraZoomSpeed;
	public float CameraZoomMin;
	public float CameraZoomMax;
	public float CameraYOffset;
	public float CameraXOffset;
	public float CameraFOV;
	private float mouseX;
	private float mouseY;

	void Start(){
		
		myController = GetComponent<CharacterController> ();
		moveDirection = Vector3.zero;

		isSprinting = false;


		myCamera = GetComponentInChildren<Camera> ();
		myCameraPivot = transform.Find ("CameraPivot").gameObject;

		CameraZoom = -3.0f;


	} // end start

	void Update(){

		// movement

		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		moveDirection = myCamera.transform.TransformDirection (moveDirection);
		moveDirection.y = 0.0f;

		if (Input.GetKey (KeyCode.LeftShift)) {
			isSprinting = true;
		} else {
			isSprinting = false;
		}

		if (isSprinting) {
			myController.Move (moveDirection * Time.deltaTime * SprintSpeed);
		} else {
			myController.Move (moveDirection * Time.deltaTime * WalkSpeed);
		}
			

		// camera

		CameraZoom += Input.GetAxis ("Mouse ScrollWheel") * CameraZoomSpeed;

		if (CameraZoom > CameraZoomMin) {
			CameraZoom = CameraZoomMin;
		}
		if (CameraZoom < CameraZoomMax) {
			CameraZoom = CameraZoomMax;
		}

		myCamera.transform.localPosition = new Vector3 (CameraXOffset, CameraYOffset, CameraZoom);
		myCamera.fieldOfView = CameraFOV;
		myCamera.transform.LookAt (myCameraPivot.transform);

		if (Input.GetMouseButton (1)) {
			mouseX += Input.GetAxis ("Mouse X") * CameraSensitivity;
			mouseY -= Input.GetAxis ("Mouse Y") * CameraSensitivity;
			mouseY = Mathf.Clamp (mouseY, -30, 70);
			myCameraPivot.transform.localRotation = Quaternion.Euler (mouseY, 0, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, mouseX, 0);
		}
			
	} // end update

} // end player movement class
