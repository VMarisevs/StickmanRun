using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public CoinSound CoinPrefab;
	private CoinSound coinSounds;

	void Start(){
		init ();
	}

	private void init(){
		coinSounds =  Instantiate (CoinPrefab) as CoinSound;
		coinSounds.transform.SetParent(GameObject.Find("SoundController").transform);
		coinSounds.gameObject.name = "CoinSounds";
	}
}
