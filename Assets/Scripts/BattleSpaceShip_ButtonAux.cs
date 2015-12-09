using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class BattleSpaceShip_ButtonAux : MonoBehaviour 
{
	public string Status;
	public string Classe;
	private ColorBlock myColors;
	public Button[] Partners; 
	public GameObject Parent;
	
	void Start () 
	{
		Classe = gameObject.transform.parent.name;
		Status = "Vazio";
		myColors = gameObject.GetComponent<Button>().colors;
		Partners = new Button[4];
		if(gameObject.name[0].ToString() != "0")
		{
			Partners[0] = gameObject.transform.parent.GetComponent<BattleSpaceShip_Identifier>().Houses[int.Parse(gameObject.name[0].ToString())-1];
		}
		if(gameObject.name[0].ToString() != "4")
		{
			Partners[1] = gameObject.transform.parent.GetComponent<BattleSpaceShip_Identifier>().Houses[int.Parse(gameObject.name[0].ToString())+1];
		}
		if(gameObject.transform.parent.name != "1")
		{
			Partners[2] = GameObject.Find((Convert.ToInt32(Classe)- 1).ToString()).GetComponent<BattleSpaceShip_Identifier>().Houses[int.Parse(gameObject.name[0].ToString())];
		}
		if(gameObject.transform.parent.name != "5")
		{
			Partners[3] = GameObject.Find((Convert.ToInt32(Classe) + 1).ToString()).GetComponent<BattleSpaceShip_Identifier>().Houses[int.Parse(gameObject.name[0].ToString())];
		}
	}
	void Update () 
	{
	
	}
	public void ChangeStatus()
	{
		if(GameObject.FindGameObjectWithTag("Corveta") == null)
		{
			gameObject.tag = "Corveta";
			Status = "Corveta";
			myColors.normalColor = Color.yellow;
			gameObject.GetComponent<Button>().interactable = false;
			for(int i = 0; i < Partners.Length; i++)
			{
				if(Partners[i] != null)
				{
					Partners[i].GetComponent<Button>().colors = myColors;
					Partners[i].tag = "Waiting";
				}
			}
		}
		else if(GameObject.FindGameObjectsWithTag("Corveta").Length < 2 && gameObject.GetComponent<Button>().colors.normalColor == Color.yellow)
		{
			GameObject[] Lolo;
			gameObject.tag = "Corveta";
			Status = "Corveta";
			myColors.normalColor = Color.white;
			gameObject.GetComponent<Button>().interactable = false;
			try
			{
				Lolo = GameObject.FindGameObjectsWithTag("Waiting");
				Lolo[0].GetComponent<Button>().colors = myColors; 
				Lolo[1].GetComponent<Button>().colors = myColors;
				Lolo[2].GetComponent<Button>().colors = myColors;
			}
			catch{}
		}
	}
}
