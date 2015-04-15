using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {
	public float scrollSpeed = 0.5F;

	// Update is called once per frame
	void FixedUpdate () {
		moveItem ();
	}
	
	private void moveItem(){		
		//this.transform.Translate (new Vector2 (getSpeed() * Time.deltaTime, 0));
		//Debug.Log("Works2");
		float offset = Time.time * scrollSpeed;
		//if (offset > 1) offset =0F;
		this.renderer.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
