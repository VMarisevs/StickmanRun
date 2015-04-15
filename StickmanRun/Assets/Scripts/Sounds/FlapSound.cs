using UnityEngine;
using System.Collections;

public class FlapSound : MonoBehaviour {

	public void PlayFlapSound(){
		if (GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'A'
		    ||
			GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'S') {
			if (!this.audio.isPlaying) {
					this.audio.Play ();
			}
		}
	}
}
