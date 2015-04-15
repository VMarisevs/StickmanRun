using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	private const float DEFAULT_HELP_TIMER = 2F;

	public GameObject btnPanel;
	public Button btnNewGame;
	public Button btnSound;
	public Button btnQuit;

	public Text txtHighScore;
	public Text txtCoin;
	public Text txtCopyright;
	public GameObject help;
	private float helpTimer = DEFAULT_HELP_TIMER; 
	private char SoundEnabled = 'A'; // S - Sound; M - Mute; A - Sound + Music

	void Start(){
		init ();
	}

	void FixedUpdate(){
		txtCoin.text = "Coins: " +
						GameObject.Find ("GamePlayController").GetComponent<GamePlayController> ().coinsCollected;

		if (helpTimer > 0) {
			helpTimer -=Time.deltaTime;
		} else if (help.activeSelf){
			help.SetActive(false);
		}
	}

	private void init(){
		SoundFunc (); // Set sound button depending on default sound option selected
		//PlayerPrefs.SetInt ("Player Help", 0);
	}

	private bool playerHelp(){
		if (PlayerPrefs.GetInt ("Player Help") < 3) {
			int i = PlayerPrefs.GetInt ("Player Help") + 1;
			PlayerPrefs.SetInt("Player Help",i );
			helpTimer = DEFAULT_HELP_TIMER;
			return true;
		}
		return false;
	}

	public void EnableMenu(bool boolean){
		btnPanel.SetActive (boolean);
		btnNewGame.enabled = boolean;
		btnQuit.enabled = boolean;
		txtHighScore.enabled = boolean;
		txtCopyright.enabled = boolean;
		txtHighScore.text = "High Score: " + PlayerPrefs.GetInt ("High Score").ToString ();
		txtCoin.enabled = !boolean;
		if (!boolean && playerHelp()) {
			help.SetActive(true);
		} else{
			help.SetActive(false);
		}
	}

	public void NewGameFunc(){
		GameObject.Find("GamePlayController").GetComponent<GamePlayController>().gameRunning = true;
		EnableMenu (false);
	}

	public void SoundFunc(){
		Text buttonText = btnSound.transform.FindChild ("Text").GetComponent<Text>();

		switch (SoundEnabled) {
		
		case 'A':
			SoundEnabled = 'S';
			buttonText.text = "Sound";
			break;
		case 'S':
			SoundEnabled = 'M';
			buttonText.text = "Mute";
			break;
		case 'M':
			buttonText.text = "Music";
			SoundEnabled = 'A';
			break;
		}
	}
	public char getSoundEnabled(){
		return SoundEnabled;
	}
	
	public void QuitFunc(){
		Application.Quit();
	}


	// Share on FACEBOOK
	public void ShareToFacebookFunc (){
		string linkParameter = "https://www.facebook.com/pages/Stickman-Run/1017404148287610";
		string nameParameter = "Stickman Run!!!";
		string captionParameter = "Check out My high score!";
		string descriptionParameter = "Score: " 
										+ PlayerPrefs.GetInt ("High Score").ToString ()
										+ ". Try to beat Me!";
		string pictureParameter = "http://vmarisevs.me/sites/default/files/%3Cem%3EEdit%20Blog%20entry%3C/em%3E%20Unity%20Game%20Stickman%20Run/poster2.png";
		string redirectParameter = "http://www.facebook.com/";

		ShareToFacebook (linkParameter, nameParameter, captionParameter, 
	                 descriptionParameter, pictureParameter, redirectParameter);
	}


	private const string FACEBOOK_APP_ID = "837883349590559";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	
	private void ShareToFacebook (string linkParameter, 
	                              string nameParameter, 
	                              string captionParameter, 
	                              string descriptionParameter, 
	                              string pictureParameter, 
	                              string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	// Share on TWITTER
	public void ShareToTwitterFunc(){
		ShareToTwitter ("Stickman Run\nCheck out my high score!\nScore: " 
		                + PlayerPrefs.GetInt ("High Score").ToString ()
		                + ".\nTry to beat Me!");
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 
	
	private void ShareToTwitter (string textToDisplay){
		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL(textToDisplay) +
		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}


}
