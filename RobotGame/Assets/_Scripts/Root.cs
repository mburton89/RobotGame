using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour {

	public static Root Instance;

	void Awake(){
		Instance = this;
	}
}
