using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattleSpaceShip_Gerenciator : MonoBehaviour 
{
	public int Counter; // Contador de cliques 
	public bool myTime; // Controlador da vez de cada jogador
	public bool Finished;
	public GameObject[] Fragatas,Corvetas;
	public GameObject FailM,Initial, WaitingT;
	public string[] CoordenatesF, CoordenatesC; // Variaveis que gravam onde estao os barcos para o inimigo
	private GameObject OtherE;
	private ColorBlock myColors;
	void Start () 
	{
		Counter = 0;
		FailM.SetActive(false);
		WaitingT.SetActive(false);
		myColors = GameObject.Find("0A").GetComponent<Button>().colors;
		Fragatas = new GameObject[3];
		CoordenatesC = new string[2];
		CoordenatesF = new string[3];
		myTime = true;
	}
	void Update () 
	{
		if(Counter >= 3 && myTime)
		{
			Counter = 0;
			WaitingT.SetActive(true);
			myTime = false;
		}
		else if(myTime)
		{
			WaitingT.SetActive(false);
		}
		if(Finished)
		{
			Finished = false;
			Corvetas = GameObject.FindGameObjectsWithTag("Corveta");
			Fragatas = GameObject.FindGameObjectsWithTag("Fragata");
			if(Fragatas.Length == 2 || Fragatas.Length == 1)
			{
				FailM.SetActive(true);
				Initial.SetActive(false);
				GameObject[] Vazios;
				Vazios = GameObject.FindGameObjectsWithTag("Waiting");
				GameObject[] F;
				F = GameObject.FindGameObjectsWithTag("Fragata");
				for(int i = 0; i < Vazios.Length; i++)
				{
					myColors.normalColor = Color.white;
					Vazios[i].tag = "Vazio";
					Vazios[i].GetComponent<Button>().colors = myColors;
					Vazios[i].GetComponent<Button>().interactable = true;
				}
				for(int i = 0; i < F.Length; i++)
				{
					myColors.normalColor = Color.white;
					F[i].tag = "Vazio";
					F[i].GetComponent<Button>().colors = myColors;
					F[i].GetComponent<Button>().interactable = true;
				}
			}
			else
			{
				FailM.SetActive(false);
				Initial.SetActive(false);
				myColors.normalColor = Color.white;
				myColors.highlightedColor = Color.white;
				myColors.pressedColor = Color.white;
				GameObject[] AllG;
				AllG = GameObject.FindGameObjectsWithTag("Vazio");
				for(int i = 0; i < AllG.Length; i++)
				{
					AllG[i].GetComponent<Button>().colors = myColors;
				}
				OtherE = Instantiate(Resources.Load("Enemy",typeof(GameObject))) as GameObject;
				OtherE.transform.SetParent(GameObject.Find("Canvas").transform,false);
				CoordenatesF[0] = Fragatas[0].name;
				CoordenatesF[1] = Fragatas[1].name;
				CoordenatesF[2] = Fragatas[2].name;
				CoordenatesC[0] = Corvetas[0].name;
				CoordenatesC[1] = Corvetas[1].name;
			}
		}	
	}
}
