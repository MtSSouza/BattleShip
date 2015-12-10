using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class BattleSpaceShip_ButtonAux : MonoBehaviour 
{
	public string Status;
	private string Classe;
	private ColorBlock myColors;
	public Button[] Partners, Fragatas; 
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
		if(GameObject.FindGameObjectWithTag("Corveta") == null && GameObject.FindGameObjectsWithTag("Corveta").Length < 2)
		{
			gameObject.tag = "Corveta";
			Status = "Corveta";
			myColors.normalColor = Color.yellow;
			for(int i = 0; i < Partners.Length; i++)
			{
				if(Partners[i] != null)
				{
					Partners[i].GetComponent<Button>().colors = myColors;
					Partners[i].tag = "Waiting";
				}
			}
			myColors.disabledColor = Color.blue;
			gameObject.GetComponent<Button>().interactable = false;
			gameObject.GetComponent<Button>().colors = myColors;
		}
		else if(GameObject.FindGameObjectsWithTag("Corveta").Length < 2 && gameObject.GetComponent<Button>().colors.normalColor == Color.yellow)
		{
			gameObject.tag = "Corveta";
			Status = "Corveta";
			myColors.normalColor = Color.white;
			try
			{
				GameObject[] Lolo;
				Lolo = GameObject.FindGameObjectsWithTag("Waiting");
				Lolo[0].GetComponent<Button>().colors = myColors; 
				Lolo[1].GetComponent<Button>().colors = myColors;
				Lolo[2].GetComponent<Button>().colors = myColors;
				Lolo[3].GetComponent<Button>().colors = myColors;
			}
			catch{}
			myColors.disabledColor = Color.blue;
			gameObject.GetComponent<Button>().interactable = false;
			gameObject.GetComponent<Button>().colors = myColors;
		}
		else if(GameObject.FindGameObjectWithTag("Fragata") == null && GameObject.FindGameObjectsWithTag("Corveta").Length == 2)
		{
			gameObject.tag = "Fragata";
			Status = "Fragata";
			myColors.normalColor = Color.yellow;
			for(int i = 0; i < Partners.Length; i++)
			{
				if(Partners[i] != null && Partners[i].tag == "Vazio")
				{
					Partners[i].GetComponent<Button>().colors = myColors;
					Partners[i].tag = "Waiting";
				}
			}
			myColors.disabledColor = Color.cyan;
			gameObject.GetComponent<Button>().interactable = false;
			gameObject.GetComponent<Button>().colors = myColors;
			
			for(int i = 0; i < Fragatas.Length; i++)
			{
				if(Fragatas[i].tag == "Vazio")
				{
					myColors.normalColor = Color.cyan;
					Fragatas[i].GetComponent<Button>().colors = myColors;
				}
			}
		}
		else if(GameObject.FindGameObjectsWithTag("Fragata").Length == 1 && GameObject.FindGameObjectsWithTag("Corveta").Length == 2 && gameObject.GetComponent<Button>().colors.normalColor == Color.yellow)
		{
			gameObject.tag = "Fragata";
			Status = "Fragata";
			myColors.normalColor = Color.white;
			try
			{
				GameObject[] Lolo;
				Lolo = GameObject.FindGameObjectsWithTag("Waiting");
				for(int i = 0; i < 8; i ++)
				{
					Lolo[i].GetComponent<Button>().colors = myColors; 
					Lolo[i].tag = "Vazio"; 
				}
			}
			catch{}
			for(int i = 0; i < Partners.Length; i++)
			{
				if(Partners[i] != null && Partners[i].GetComponent<Button>().colors.normalColor == Color.cyan)
				{
					Partners[i].tag = "Fragata";
					Partners[i].interactable = false;
				}
			}
			myColors.disabledColor = Color.cyan;
			gameObject.GetComponent<Button>().interactable = false;
			gameObject.GetComponent<Button>().colors = myColors;
			try
			{
				GameObject[] Love;
				Love = GameObject.FindGameObjectsWithTag("Vazio");
				for(int i = 0; i < 25; i ++)
				{
					if(Love[i].GetComponent<Button>().colors.normalColor == Color.cyan)
					{
						myColors.disabledColor = Color.white;
						Love[i].GetComponent<Button>().colors = myColors; 
						Love[i].tag = "Vazio"; 
					}
				}
			}
			catch{}
			GameObject.Find("Camera").GetComponent<BattleSpaceShip_Gerenciator>().Finished = true;
		}
	}
}
