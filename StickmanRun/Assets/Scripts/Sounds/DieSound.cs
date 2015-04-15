using UnityEngine;
using System.Collections;

public class DieSound : MonoBehaviour {

	public void PlayDieSound(){
		if (GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'A'
		    ||
			GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'S') {
			this.audio.Play ();
		}
	}
}
