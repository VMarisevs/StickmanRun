using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	//private bool playing = false;
	void FixedUpdate(){
		if (GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'A') {
			if (!audio.isPlaying){
				audio.Play();
			}
		} else if (GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'S'
		           ||
		           GameObject.Find ("MenuController").GetComponent<MenuController> ().getSoundEnabled () == 'M'){
			if (audio.isPlaying){
				this.audio.Stop();
			}
		} 
	}
}
