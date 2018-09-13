using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelHero : MonoBehaviour {

	[SerializeField]private Animator animator;

	[SerializeField]private AnimationClip MoveUpAnimation;
	[SerializeField]private AnimationClip MoveDownAnimation;
	[SerializeField]private AnimationClip MoveLeftAnimation;
	[SerializeField]private AnimationClip MoveRightAnimation;

	public float speed;
	public float verticalSpeedAdjustment;

	public void MoveUp(){
		transform.Translate (Vector3.up * (Time.deltaTime * (speed * verticalSpeedAdjustment)), Space.World);
		animator.Play (MoveUpAnimation.name);
	}

	public void MoveDown(){
		transform.Translate (Vector3.down * (Time.deltaTime * (speed * verticalSpeedAdjustment)), Space.World);
		animator.Play (MoveDownAnimation.name);
	}

	public void MoveLeft(){
		transform.Translate (Vector3.left * (Time.deltaTime * speed), Space.World);
		animator.Play (MoveLeftAnimation.name);
	}

	public void MoveRight(){
		transform.Translate (Vector3.right * (Time.deltaTime * speed), Space.World);
		animator.Play (MoveRightAnimation.name);
	}

	public void StopMoving(){
		animator.StopPlayback ();
	}	
}
