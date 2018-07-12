using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public KeyCode switchModeInput;
	public KeyCode switchWeaponInput;
		
	void Update () {

		if(Input.GetKeyDown(switchModeInput)){
			Character.Instance.SwitchCombatMode();
		}

		if(Input.GetKeyDown(switchWeaponInput)){
			Character.Instance.SelectPreviousWeapon();
		}
	}

}
