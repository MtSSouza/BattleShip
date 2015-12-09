using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattleSpaceShip_Verifyer : MonoBehaviour 
{
	private BattleSpaceShip_Gerenciator Gerenciator;
	private ColorBlock myColors;
	public string nameTiles;
	
	void Start () 
	{
		myColors = gameObject.GetComponent<Button>().colors;
		Gerenciator = GameObject.Find("Camera").GetComponent<BattleSpaceShip_Gerenciator>();
	}
	void Update () 
	{
		print (nameTiles);
	}
	public void Verify()
	{
		try
		{
			for(int i = 0; i < 3; i++)
			{
				if(gameObject.name == Gerenciator.CoordenatesF[i])
				{
					myColors.disabledColor = Color.cyan;
					gameObject.GetComponent<Button>().colors = myColors;
					gameObject.GetComponent<Button>().interactable = false;
				}
				else if(gameObject.name == Gerenciator.CoordenatesC[i])
				{
					myColors.disabledColor = Color.blue;
					gameObject.GetComponent<Button>().colors = myColors;
					gameObject.GetComponent<Button>().interactable = false;
				}
				else
				{
					gameObject.GetComponent<Button>().interactable = false;
				}
				nameTiles = gameObject.name;
			}
		}
		catch{}

	}
}
