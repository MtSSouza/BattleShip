using UnityEngine;
using System.Collections;

public class Casas_Events : MonoBehaviour {

	public string Team;
	private string[] xy = new string[2];
	private string[] firstXY = new string[2];
	public static bool clicked;
	private GameObject goToChange;
	private Btns_Functions btnsf;
	private Color32 oldColor;
	private GameObject[] toPutShip;

	// Use this for initialization
	void Start () {
		btnsf = GameObject.Find("Main Camera").GetComponent<Btns_Functions>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		oldColor = this.GetComponent<SpriteRenderer>().color;
	}
	void OnMouseOver() {

		if (Team == "Ally")	this.GetComponent<SpriteRenderer>().color = new Color32(66, 66, 66, 255);
	}
	void OnMouseExit() {

		if (Team == "Ally") this.GetComponent<SpriteRenderer> ().color = oldColor;
	}
	void OnMouseDown() {

		if (Team == "Ally") {
			if(!clicked && this.tag == "BlankSpace") {

				if (btnsf.spaceshipsPlaced == 0) this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
				if (btnsf.spaceshipsPlaced > 0) this.GetComponent<SpriteRenderer>().color = new Color32(122, 0, 0, 255);
				xy = this.name.Split('-');

				int xy2;

				xy2 = int.Parse(xy[1]);
				if(xy2 < 5) {
					goToChange = GameObject.Find(xy[0] + "-" + (xy2 + 1).ToString());
					if (goToChange.tag == "BlankSpace")
					{
						goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
						goToChange.tag = "CanPutShip";
					}
				}
				xy2 = int.Parse(xy[1]);
				if (xy2 > 1) {
					goToChange = GameObject.Find(xy[0] + "-" + (xy2 - 1).ToString());
					if (goToChange.tag == "BlankSpace")
					{
						goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
						goToChange.tag = "CanPutShip";
					}
				}
				xy2 = int.Parse(xy[0]);
				if(xy2 < 5) {
					goToChange = GameObject.Find((xy2 + 1).ToString() + "-" + xy[1]);
					if (goToChange.tag == "BlankSpace")
					{
						goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
						goToChange.tag = "CanPutShip";
					}
				}
				xy2 = int.Parse(xy[0]);
				if(xy2 > 1) {
					goToChange = GameObject.Find((xy2 - 1).ToString() + "-" + xy[1]);
					if (goToChange.tag == "BlankSpace")
					{
						goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
						goToChange.tag = "CanPutShip";
					}
				}

				btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
				btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
				if (btnsf.spaceshipsPlaced == 0) oldColor = new Color32(255, 0, 0, 255);
				if (btnsf.spaceshipsPlaced > 0) oldColor = new Color32(122, 0, 0, 255);
				btnsf.spaceshipsPlaced++;
				this.tag = "Ship";

				clicked = true;

			} else if(clicked) {

				if (btnsf.spaceshipsPlaced < 4)
				{
					firstXY[0] = btnsf.usedPlaces[0, 0];
					firstXY[1] = btnsf.usedPlaces[0, 1];
				}
				else
				{
					firstXY[0] = btnsf.usedPlaces[3, 0];
					firstXY[1] = btnsf.usedPlaces[3, 1];
				}
				xy = this.name.Split('-');
				Debug.Log(firstXY[0] + " " + firstXY[1] + " " + xy[0] + " " + xy[1]);

				if (btnsf.spaceshipsPlaced < 5 && (firstXY[0] != xy[0] || firstXY[1] != xy[1])) {
					Debug.Log("passou");

					//this.GetComponent<SpriteRenderer>().color = new Color32 (255, 0, 0, 255);
					
					switch (btnsf.spaceshipsPlaced) { 
						case 1:

							if (xy[0] != firstXY[0] && xy[1] == firstXY[1] && this.tag == "CanPutShip") {

								if (int.Parse(xy[0]) < int.Parse(firstXY[0])) {
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(xy[0]) > 1) {

										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + xy[1]);
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
										goToChange.tag = "CanPutShip";
									}
								}
								if (int.Parse(xy[0]) > int.Parse(firstXY[0]))
								{
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(xy[0]) < 5)
									{

										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + xy[1]);
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
										goToChange.tag = "CanPutShip";
									}
								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
							}
							if (xy[1] != firstXY[1] && xy[0] == firstXY[0] && this.tag == "CanPutShip")
							{

								if (int.Parse(xy[1]) < int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(xy[1]) > 1)
									{

										goToChange = GameObject.Find(xy[0] + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
										goToChange.tag = "CanPutShip";
									}
								}
								if (int.Parse(xy[1]) > int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(xy[1]) < 5)
									{

										goToChange = GameObject.Find(xy[0] + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
										goToChange.tag = "CanPutShip";
									}
								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
							}
	
							break;
						case 2:

							if (xy[0] != firstXY[0] && xy[1] == firstXY[1] && this.tag == "CanPutShip")
							{

								if (int.Parse(xy[0]) < int.Parse(firstXY[0])) {
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) < int.Parse(firstXY[0]) && int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(firstXY[0]) + 1).ToString() + "-" + int.Parse(firstXY[1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									else if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) > int.Parse(firstXY[0]) && int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) + 1).ToString() + "-" + int.Parse(btnsf.usedPlaces[1, 1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

								}
								if (int.Parse(xy[0]) > int.Parse(firstXY[0]))
								{
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) > int.Parse(firstXY[0]) && int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(firstXY[0]) - 1).ToString() + "-" + int.Parse(firstXY[1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									else if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) < int.Parse(firstXY[0]) && int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) - 1).ToString() + "-" + int.Parse(btnsf.usedPlaces[1, 1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
								clicked = false;
							}
							if (xy[1] != firstXY[1] && xy[0] == firstXY[0] && this.tag == "CanPutShip")
							{

								if (int.Parse(xy[1]) < int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) < int.Parse(firstXY[1]) && int.Parse(firstXY[1]) < 5) 
									{ 
										goToChange = GameObject.Find(int.Parse(firstXY[0]).ToString() + "-" + (int.Parse(firstXY[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									else if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) > int.Parse(firstXY[1]) && int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find(int.Parse(btnsf.usedPlaces[1, 0]).ToString() + "-" + (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

								}
								if (int.Parse(xy[1]) > int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) > int.Parse(firstXY[1]) && int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find(int.Parse(firstXY[0]).ToString() + "-" + (int.Parse(firstXY[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									else if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) < int.Parse(firstXY[1]) && int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find(int.Parse(btnsf.usedPlaces[1, 0]).ToString() + "-" + (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
								clicked = false;
							}

							break;
						case 4:

							if (xy[0] != firstXY[0] && xy[1] == firstXY[1] && this.tag == "CanPutShip") {

								if (int.Parse(xy[0]) < int.Parse(firstXY[0])) {
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}
									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}

								if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) < int.Parse(firstXY[0]) && int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(firstXY[0]) + 1).ToString() + "-" + int.Parse(firstXY[1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}
									else if (int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) > int.Parse(firstXY[0]) && int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(btnsf.usedPlaces[btnsf.spaceshipsPlaced - 1, 0]) + 1).ToString() + "-" + int.Parse(btnsf.usedPlaces[1, 1]).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
										goToChange.tag = "BlankSpace";
									}

									if (int.Parse(xy[0]) > 1) {

										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + xy[1]);
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
											goToChange.tag = "CanPutShip";
										}
									}
								}
								if (int.Parse(xy[0]) > int.Parse(firstXY[0]))
								{
									if (int.Parse(firstXY[1]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}

									if (int.Parse(firstXY[1]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}
								}

								oldColor = new Color32(122, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
							}
							if (xy[1] != firstXY[1] && xy[0] == firstXY[0] && this.tag == "CanPutShip")
							{

								if (int.Parse(xy[1]) < int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}
									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}

									if (int.Parse(xy[1]) > 1)
									{

										goToChange = GameObject.Find(xy[0] + "-" + (int.Parse(xy[1]) - 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
											goToChange.tag = "CanPutShip";
										}
									}
								}
								if (int.Parse(xy[1]) > int.Parse(firstXY[1]))
								{
									if (int.Parse(firstXY[0]) < 5)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}

									if (int.Parse(firstXY[0]) > 1)
									{
										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
										if (goToChange.tag != "Ship")
										{
											goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
											goToChange.tag = "BlankSpace";
										}
									}
								}

								toPutShip = GameObject.FindGameObjectsWithTag("CanPutShip");
								for(int i = 0; i < toPutShip.Length; i++){

                                    toPutShip[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                                    toPutShip[i].tag = "BlankSpace";
								}

								oldColor = new Color32(122, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								this.tag = "Ship";
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
								btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
								btnsf.spaceshipsPlaced++;
							}

							break;

					}
				}
			}
		}
	}
}
