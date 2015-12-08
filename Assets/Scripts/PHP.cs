using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PHP : MonoBehaviour {
	
	public static string url = "http://danielkropf.16mb.com/BSS.php";
	private Btns_Functions btnsf;
	[HideInInspector]
	public InputField user;
	[HideInInspector]
	public InputField pass;
	public GameObject ne;
	public GameObject wp;
	
	// Use this for initialization
	void Start () {
		btnsf = this.gameObject.GetComponent<Btns_Functions> ();
		user = GameObject.Find("InputUserID").GetComponent<InputField>();
		pass = GameObject.Find("InputPassword").GetComponent<InputField>();
	}
	
	IEnumerator SaveToPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("UserID", 1);
		form.AddField("Senha", 1);

		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
	}
	
	IEnumerator LoadFromPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField ("UserID", user.text);
		PlayerPrefs.SetString ("nickName", user.text);
		WWW w = new WWW(url, form);
		yield return w;

		if (w.text == "error") {
			Debug.Log ("NAO EXISTE!");
			ne.SetActive(true);
		} 
		else
		{
			string[] datas = w.text.Split(';');
			foreach(string data in datas)
			{
				string[] info = data.Split('=');
				switch(info[0])
				{
				case "Senha":
					//tw.tst.lvlPlayer = int.Parse(info[1]);
					bool logou = pass.text.Equals(info[1]);
					if (!logou) wp.SetActive(true);
					Application.LoadLevel(1);
					break;
					
				}
			}
		}
	}

	public void Load()
	{
		StartCoroutine (LoadFromPHP ());
		Application.LoadLevel (1);
	}
}
