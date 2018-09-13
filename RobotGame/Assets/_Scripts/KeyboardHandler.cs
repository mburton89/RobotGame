using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

	[SerializeField] private PixelHero pixelHero;

	void Update () {
		HandleKeyboard ();
	}

    void HandleKeyboard() {
		if (Input.GetKey (KeyCode.W)) {
			pixelHero.MoveUp ();
		} 

		else if (Input.GetKey (KeyCode.A)) {
			pixelHero.MoveLeft ();
		} 

		else if (Input.GetKey (KeyCode.S)) {
			pixelHero.MoveDown ();
		} 

		else if (Input.GetKey (KeyCode.D)) {
			pixelHero.MoveRight ();
		} 

		else {
			pixelHero.StopMoving ();
		}
    }
}
