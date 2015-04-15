using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

	public int gameSpeed = 4;
	private int oldGameSpeed;

	public CoinController coinPrefab;
	private int coinCounter = 0;
	private List<CoinController> coinList = new List<CoinController>();
	private float coinDelay = 0;

	public GroundBlock groundBlockPrefab;
	private int groundBlockCounter=0;
	private List<GroundBlock> groundBlockList = new List<GroundBlock>();

	void Start(){
		oldGameSpeed = gameSpeed;
		CreateStartMap ();
	}

	void FixedUpdate(){

		KeepCreatingPausedBlocks ();
		ChangeSpeed ();
		GenerateBlocks ();
		GenerateCoins ();
	}



	//generate map
	private void GenerateMap(){
		int y = 0;
		for (int x = 0; x < 100; x++) {
			y = (int)Random.Range(-4.0F, 1.0F);
			if (y != 1){
				CreateGroundBlock(x,y,true);
			}
		}
	}

	// starting point
	private void CreateStartMap(){
		int y = -4;
		for ( int x = -8; x < 18 	; x++){
			CreateGroundBlock(x,y,true);
		}

	}

	private void GenerateBlocks(){
		int y = (int)Random.Range (-4.0F, 4.0F);
		int x = 14;

		if (GameObject.Find ("GamePlayController").GetComponent<GamePlayController> ().gameRunning) {
			if (groundBlockList [groundBlockList.Count - 1].transform.position.x < 13)  {
				if (y < 1){
					CreateGroundBlock (x, y,true);
				} else{
					CreateGroundBlock (x, y,false);
				}
			}
		}
	}

	private void GenerateCoins(){

		if (GameObject.Find ("GamePlayController").GetComponent<GamePlayController> ().gameRunning) {
			if (coinDelay < 0){
				float y = Random.Range (1.0F, 3.0F);
				float x = 14F;
				y = groundBlockList[groundBlockList.Count-1].transform.position.y + y;
				CreateCoin(x,y);
				coinDelay = Random.Range(0.1F,1.5F);
			} else {
				coinDelay -= Time.deltaTime;
			}
		}
	}

	private void KeepCreatingPausedBlocks(){
		// Creating blocks while game in pause mode
		int y = -4;
		int x = 14;
		if (!GameObject.Find("GamePlayController").GetComponent<GamePlayController>().gameRunning) {
			if (groundBlockList[groundBlockList.Count-1].transform.position.x <13)
				CreateGroundBlock(x,y,true);
			
		}
	}

	// create Coin
	private void CreateCoin(float startX, float startY){
		CoinController coinClone = Instantiate (coinPrefab) as CoinController;
		coinClone.transform.SetParent (GameObject.Find ("Coins").transform);
		coinClone.transform.localPosition = new Vector2 (startX, startY);
		coinClone.Speed = this.gameSpeed;
		coinClone.gameObject.name = "CoinClone_" + coinCounter++;
		coinList.Add (coinClone);
	}

	// create ground block
	private void CreateGroundBlock(int startX, int startY, bool enabled){
		GroundBlock groundBlockClone = Instantiate (groundBlockPrefab) as GroundBlock;
		groundBlockClone.transform.SetParent (GameObject.Find("GameFloor").transform);
		groundBlockClone.transform.localPosition = new Vector2 (startX, startY);
		groundBlockClone.collider2D.enabled = enabled;
		groundBlockClone.renderer.enabled = enabled;
		groundBlockClone.Speed = this.gameSpeed;
		groundBlockClone.gameObject.name = "GroundBlockClone_" + groundBlockCounter++;
		groundBlockList.Add (groundBlockClone);
	}



	private void ChangeSpeed(){
		if (gameSpeed != oldGameSpeed) {
			for (int i = 0; i < groundBlockList.Count; i++){
				if (groundBlockList[i] != null)
					groundBlockList[i].Speed = gameSpeed;
			}

			for (int i = 0; i< coinList.Count; i++){
				if (coinList[i] != null)
					coinList[i].Speed = gameSpeed;
			}
			
			oldGameSpeed = gameSpeed;
		}
	}

	public void ClearObjects(){
		for (int i = 0; i < groundBlockList.Count; i++) {
			if (groundBlockList[i] != null){
				Destroy(groundBlockList[i].gameObject);
			}
		}
		groundBlockList.Clear ();

		for (int i = 0; i < coinList.Count; i++) {
			if (coinList[i] != null){
				Destroy(coinList[i].gameObject);
			}
		}

		coinList.Clear ();

		CreateStartMap ();
	}	
}
