using UnityEngine;
using System.Collections;

public class GroundBlock : MonoBehaviour {

	public int Speed = 5;

	void FixedUpdate () {
		moveItem ();
	}
	
	private void moveItem(){		
		this.transform.Translate (new Vector2 (getSpeed() * Time.deltaTime, 0));
	}
	
	private int getSpeed(){
		// changing direction from right to left, so user speed would be positive all the time
		if (Speed > 0) {
			Speed = -Speed;
		}
		return Speed;
	}
}
