using UnityEngine;
using System.Collections;

public class GamePlayController : MonoBehaviour {

	public int coinsCollected = 0;

	public bool gameRunning = false;

	public MenuController menuController;

	public PlayerController playerControllerPrefab;
	private PlayerController playerControllerClone;
	//Player Starting possition
	private int xPosition = -5; 
	private int yPosition = -1;

	// Use this for initialization
	void Start () {
	
		menuController.EnableMenu (true);
		GameObject.Find ("MapController").GetComponent<MapController> ().ClearObjects ();
		CreateCharacter (xPosition, yPosition);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		OnDie ();
	}

	private void OnDie(){
		if (playerControllerClone == null) {
			GameObject.Find ("MapController").GetComponent<MapController> ().ClearObjects ();
			GameObject.Find("DieSound").GetComponent<DieSound>().PlayDieSound();

			CreateCharacter(xPosition,yPosition);
			highScore(coinsCollected);
			coinsCollected = 0;
			menuController.EnableMenu(true);
		}
	}




	private void highScore(int coins){
		if (PlayerPrefs.GetInt("High Score") < coins)
			PlayerPrefs.SetInt("High Score", coins);
	}

	private void CreateCharacter(int startX, int startY){
		playerControllerClone = Instantiate (playerControllerPrefab) as PlayerController;
		playerControllerClone.transform.localPosition = new Vector2 (startX, startY);
		playerControllerClone.gameObject.name = "Player";
	}
}
