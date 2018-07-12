using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerInput : MonoBehaviour {

	public enum InputType{
		Button,
		LeftJoystick,
		RightJoystick,
		DPad,
		LeftTrigger,
		RightTrigger
	}

	public InputType inputType;

	public string buttonName;

	private Vector3 startPosition;
	private Transform thisTransform;

	private SpriteRenderer _sprite;

	void Awake(){
		_sprite = GetComponent<SpriteRenderer>();
	}

	void Start(){
		thisTransform = transform;
		startPosition = thisTransform.position;
	}

	void Update(){
		if(inputType == InputType.Button){
			_sprite.enabled = Input.GetButton(buttonName);
		}else if(inputType == InputType.LeftJoystick){
			Vector3 inputDirection = Vector3.zero;
			inputDirection.x = Input.GetAxis("LeftJoystickHorizontal");
			inputDirection.y = -Input.GetAxis("LeftJoystickVertical");
			thisTransform.position = startPosition + inputDirection;
		}else if(inputType == InputType.RightJoystick){
			Vector3 inputDirection = Vector3.zero;
			inputDirection.x = Input.GetAxis("RightJoystickHorizontal");
			inputDirection.y = -Input.GetAxis("RightJoystickVertical");
			thisTransform.position = startPosition + inputDirection;
		}else if(inputType == InputType.DPad){
			Vector3 inputDirection = Vector3.zero;
			inputDirection.x = Input.GetAxis("DPadHorizontal");
			inputDirection.y = Input.GetAxis("DPadVertical");
			thisTransform.position = startPosition + inputDirection;
		}else if(inputType == InputType.LeftTrigger){
			_sprite.color = new Color(255f,255f,255f, Input.GetAxis("LeftTrigger"));
		}else if(inputType == InputType.RightTrigger){
			_sprite.color = new Color(255f,255f,255f, Input.GetAxis("RightTrigger"));
		}
	}
}
