using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattleSpaceShip_Verifyer : MonoBehaviour 
{
	private BattleSpaceShip_Gerenciator Gerenciator;
	private ColorBlock myColors;
	public string Desative,Match; //Variaveis que mostram onde foram os cliques.
	void Start () 
	{
		Desative = "Nada";
		Match = "Nada";
		myColors = gameObject.GetComponent<Button>().colors;
		Gerenciator = GameObject.Find("Camera").GetComponent<BattleSpaceShip_Gerenciator>();
	}
	void Update () 
	{
		if(Desative != "Nada")
		{	
			if(GameObject.Find(gameObject.name).transform.parent.transform.parent.name == "Player")
			{
				GameObject.Find(Desative).GetComponent<Button>().interactable = false;
			}
			Desative = "Nada";
		}
		if(Match != "Nada")
		{
			if(GameObject.Find(gameObject.name).transform.parent.transform.parent.name == "Player")
			{
				myColors.disabledColor = Color.red;
				GameObject.Find(Match).GetComponent<Button>().colors = myColors;
			}
			Match = "Nada";
		}
	}
	public void Verify()
	{
		if(Gerenciator.myTime)
		{
			Gerenciator.Counter += 1;
			GameObject[] Twins;
			Twins = new GameObject[2];
			try
			{
				for(int i = 0; i < 3; i++)
				{
					if(gameObject.name == Gerenciator.CoordenatesF[i])
					{
						if(GameObject.Find(gameObject.name).transform.parent.transform.parent.name == "Player")
						{
							myColors.disabledColor = Color.red;
							GameObject.Find(gameObject.name).GetComponent<Button>().colors = myColors;
						}
						Match = gameObject.name;
						myColors.disabledColor = Color.cyan;
						gameObject.GetComponent<Button>().colors = myColors;
						gameObject.GetComponent<Button>().interactable = false;
					}
					else if(gameObject.name == Gerenciator.CoordenatesC[i])
					{
						if(GameObject.Find(gameObject.name).transform.parent.transform.parent.name == "Player")
						{
							myColors.disabledColor = Color.red;
							GameObject.Find(gameObject.name).GetComponent<Button>().colors = myColors;
						}
						Match = gameObject.name;
						myColors.disabledColor = Color.blue;
						gameObject.GetComponent<Button>().colors = myColors;
						gameObject.GetComponent<Button>().interactable = false;
					}
					else
					{
						for(int j = 0; j < 2; j++)
						{
							if(GameObject.Find(gameObject.name).transform.parent.transform.parent.name == "Player")
							{
								Twins[0] = GameObject.Find(gameObject.name);
							}
							Twins[1] = gameObject;
							Desative = gameObject.name;
							Twins[j].GetComponent<Button>().interactable = false;
						}
					}
				}
			}
			catch{}
		}
	}
}
