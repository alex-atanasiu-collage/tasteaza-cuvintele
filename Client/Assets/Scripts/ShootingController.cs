using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class ShootingController : MonoBehaviour {

	public Transform firePoint;
	public GameObject snowball;

	public int chances = 3;

	public TextMesh targetA;
	public TextMesh targetB;

	public int destination = 0;
	public int indexA = 0;
	public int indexB = 0;

	private string content;

    private class Pair {
        public GameObject cloud;
        public GameObject word;

        public Pair (GameObject cloud, GameObject word) {
            this.cloud = cloud;
            this.word = word;
        }
    }

    private TextMesh selected_cloud = null;
    private HashSet<TextMesh> clouds;

    // Use this for initialization
	void Start () {
        clouds = new HashSet<TextMesh>();
	}

	// Update is called once per frame
	void Update () {
        if (GameObject.Find("GameMaster").GetComponent<GameMaster>().gameOver) {
            return;
        }

        foreach (var gameObj in FindObjectsOfType(typeof(TextMesh)) as TextMesh[]) {
            if (gameObj.gameObject.name == "word") {
                
                GameObject word = gameObj.gameObject;
                GameObject cloud = gameObj.gameObject.transform.parent.gameObject;
                //Debug.Log("Word: " + gameObj.text + "," + word.name + "," + cloud.name);

                clouds.Add(gameObj);

            }
        }
        //Debug.Log(clouds.Count);


        foreach (char chr in Input.inputString) {
            char c = Char.ToUpper(chr);
            //Debug.Log(c);
            if (selected_cloud == null) {
                //Debug.Log("selected_cloud == null");
                foreach (TextMesh current_cloud in clouds) {
                    //Debug.Log(c + " ??? " + current_cloud.text[0]);
                    if (current_cloud == null) {
                        continue;
                    }
                    if (current_cloud.text[0] == c) {
                        selected_cloud = current_cloud;
                        //Debug.Log("current_cloud.text.Length=" + current_cloud.text.Length);
                        if (current_cloud.text.Length == 1) {
                            clouds.Remove(selected_cloud);
                            Destroy(selected_cloud.gameObject.transform.parent.gameObject.transform.parent.gameObject);
                            selected_cloud = null;

                            GameMaster gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
                            gm.addPoints(gm.getPointsPerWin());
                        } else {
                            current_cloud.text = current_cloud.text.Substring(1);

                            current_cloud.transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.57f, 0.77f, 0.71f);
                        }
                        break;
                    }
                }
            } else {
                //Debug.Log("selected_cloud == " + selected_cloud.text);
                string current_word = selected_cloud.text;
                if (c == current_word[0]) {
                    if (current_word.Length == 1) {
                        clouds.Remove(selected_cloud);
                        Destroy(selected_cloud.gameObject.transform.parent.gameObject.transform.parent.gameObject);
                        //Destroy(selected_cloud.cloud);
                        selected_cloud = null;
                        GameMaster gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
                        gm.addPoints(gm.getPointsPerWin());
                    } else {
                        selected_cloud.text = current_word.Substring(1);
                    }
                }
            }
        }

        /*


		foreach (char c in Input.inputString) {

			char C = System.Char.ToUpper (c);

			if (targetA.text != "") {
				if (C == targetA.text [0]) {

					Debug.Log ("Text:" + targetA.text);

					content = targetA.text;
					Debug.Log ("Orignal content:" + content);

					content = content.Substring (1, content.Length - 1);
					Debug.Log ("After cut:" + content);

					targetA.text = content;
					destination = 1;
				} else {
					destination = 0;
				}
			} else if (targetB.text != "") {
					if (C == targetB.text [0]) {

						Debug.Log ("Text:" + targetB.text);

						content = targetB.text;
						Debug.Log ("Orignal content:" + content);

						content = content.Substring (1, content.Length - 1);
						Debug.Log ("After cut:" + content);

						targetB.text = content;
						destination = 2;
					} else {
						destination = 0;
					}
			} else {
				destination = 0;
			} 



			if (destination != 0) {
				snowball.GetComponent<change_letter> ().letter = C;
				Instantiate (snowball, firePoint.position, firePoint.rotation);
				Debug.Log ("Sending snowball to: " + destination);
			} else {
				chances--;
				Debug.Log ("Chances left " + chances);
			}
		}
         */
	}
}
