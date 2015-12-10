using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class criarNovo : MonoBehaviour {
	GameObject id;
	GameObject idS;
	public static string url = "http://danielkropf.16mb.com/SaveNew.php";
	private Btns_Functions btnsf;
	[HideInInspector]
	public InputField user;
	[HideInInspector]
	public InputField pass;
	
	// Use this for initialization
	void Start () {
		id = GameObject.Find ("Canvas/Nome");
		idS = GameObject.Find ("Canvas/Senha");
		btnsf = this.gameObject.GetComponent<Btns_Functions> ();
	}
	
	IEnumerator SaveToPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("UserID", id.gameObject.GetComponent<InputField>().text);
		form.AddField("Senha", idS.gameObject.GetComponent<InputField>().text);
		
		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
	}

	public void Save()
	{
		StartCoroutine (SaveToPHP ());
		Application.LoadLevel (0);
	}
}