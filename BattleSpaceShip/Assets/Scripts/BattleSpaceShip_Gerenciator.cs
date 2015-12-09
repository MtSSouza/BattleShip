using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BattleSpaceShip_Gerenciator : MonoBehaviour 
{
	public bool Finished;
	public GameObject[] Fragatas,Corvetas;
	public string[] CoordenatesF, CoordenatesC;
	private GameObject OtherE;
	void Start () 
	{
		CoordenatesC = new string[2];
		CoordenatesF = new string[3];
	}
	void Update () 
	{
		if(Finished)
		{
			Finished = false;
			GameObject[] AllG;
			AllG = GameObject.FindGameObjectsWithTag("Vazio");
			for(int i = 0; i < AllG.Length; i++)
			{
				AllG[i].GetComponent<Button>().interactable = false;
			}
			Corvetas = GameObject.FindGameObjectsWithTag("Corveta");
			Fragatas = GameObject.FindGameObjectsWithTag("Fragata");
			CoordenatesF[0] = Fragatas[0].name;
			CoordenatesF[1] = Fragatas[1].name;
			CoordenatesF[2] = Fragatas[2].name;
			CoordenatesC[0] = Corvetas[0].name;
			CoordenatesC[1] = Corvetas[1].name;
			OtherE = Instantiate(Resources.Load("Enemy",typeof(GameObject))) as GameObject;
			OtherE.transform.SetParent(GameObject.Find("Canvas").transform,false);
		}
	}
}
