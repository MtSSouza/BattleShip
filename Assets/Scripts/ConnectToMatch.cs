using UnityEngine;
using System.Collections;

public class ConnectToMatch : MonoBehaviour {

	public string url;

	// Use this for initialization
	void Start () {
		
	}

	IEnumerator MatchCon(){
		WWWForm form = new WWWForm();
		form.AddField("User", PlayerPrefs.GetString("nickName"));

		
		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
