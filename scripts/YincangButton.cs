using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YincangButton : MonoBehaviour {

	public GameObject sceneButtons;
	public GameObject[] controlButtons;

	bool cameraModeOn;

	// Use this for initialization
	public void toggleCameraMode() {
		cameraModeOn = !cameraModeOn;
		sceneButtons.SetActive(!cameraModeOn);
		foreach(GameObject button in controlButtons) {
			button.SetActive(!cameraModeOn);
		}
		if(cameraModeOn) {
			this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		} else {
			this.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
		}
	}
}
