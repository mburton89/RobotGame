using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayHud : MonoBehaviour {

	public static GameplayHud Instance;

	public TextMeshProUGUI combatModeText;
	public TextMeshProUGUI activeWeaponText;

	void Awake () {
		Instance = this;
	}
}
