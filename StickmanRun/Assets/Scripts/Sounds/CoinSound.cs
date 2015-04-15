using UnityEngine;
using System.Collections;

public class CoinSound : MonoBehaviour {

	//public GameObject menuController;

	public void PlayCoinSound(){
		if (GameObject.Find("MenuController").GetComponent<MenuController>().getSoundEnabled() == 'A'
		    ||
		    GameObject.Find("MenuController").GetComponent<MenuController>().getSoundEnabled() == 'S')
				this.audio.Play ();
	}
}
