using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class GameMaster : MonoBehaviour {
    private float cloudSpeed;
    private int points;
    private int lifes;

    public GameObject cloud;

    public bool gameOver;
    private float[] positions = { -0.5f, 0.25f, 1.0f };
    private int last_postion = 1;


    
    private string[] static_word_list = { "mere", "pere", "banane", "caise", "dinozaur", "elefant", "fasole", "gradina", "hectar"};

    private string[] word_list;

    private static string HttpGet (string url) {
        HttpWebRequest req = WebRequest.Create(url)
                             as HttpWebRequest;
        string result = null;
        using (HttpWebResponse resp = req.GetResponse()
                                      as HttpWebResponse) {
            StreamReader reader =
                new StreamReader(resp.GetResponseStream());
            result = reader.ReadToEnd();
        }
        return result;
    }

    // Use this for initialization
	void Start () {
        cloudSpeed = 1.0f;

        lifes = 3;
        gameOver = false;

       // HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("http://localhost:8080/getPhrase/0&0");

        char[] delimiterChars = { '[', ']', ',', '\"' };
        string raw_resp = HttpGet("http://localhost:8080/getPhrase/0&0");
        Debug.Log(raw_resp);
        string[] aux_word_list = raw_resp.Split(delimiterChars);
        //word_list[0] = word_list[1];

        List<string> list = new List<string>();
        foreach (string s in aux_word_list) {
           // Debug.Log("> \"" + s + "\"");
            if (s.CompareTo("") != 0) {
                list.Add(s);
            }
        }

        word_list = new string[list.Count];
        for (int i = 0; i < list.Count; i++) {
            word_list[i] = list[i];
            Debug.Log(list[i]);
        }
	}

    // Update is called once per frame
    void Update () {
        cloudSpeed += 0.001f;
        //Debug.Log("Cloud speed: " + cloudSpeed);
        if (gameOver) {
            GameObject.Find("LevelText").GetComponent<Text>().text = "Game over at level " + (int)(cloudSpeed * 2 - 1) + ". Enter your name: ";
            GameObject.Find("InputField").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, GameObject.Find("InputField").GetComponent<RectTransform>().anchoredPosition.y, 0);
            return;
        }



        GameObject.Find("ScoreText").GetComponent<Text>().text = "" + points;
        GameObject.Find("LevelText").GetComponent<Text>().text = "Level " + (int)(cloudSpeed*2 - 1);

        float max_x = 0.0f;
        foreach (GameObject cloud in GameObject.FindGameObjectsWithTag("Cloud")) {
            float thisx = cloud.transform.position.x;
            if (max_x < thisx) {
                max_x = thisx;
            }
        }

        if (max_x < 4f) {
            float current_y;
            int current_position;
            switch (last_postion) {
                case 0:
                    current_position = 1;
                    break;
                case 2:
                    current_position = 1;
                    break;
                case 1:
                    current_position = 2 * ((int)Random.Range(0, 2));
                    break;
                default:
                    current_position = 1;
                    break;
            }
            current_y = positions[current_position];
            last_postion = current_position;

            bool already_one_word = false;
            string current_word;
            int i = 0;
            do {
                Debug.Log(i++);
                already_one_word = false;
                current_word = word_list[Random.Range(0, word_list.Length)].ToUpper();
                foreach (var gameObj in FindObjectsOfType(typeof(TextMesh)) as TextMesh[]) {
                    string cloud_word = gameObj.text;
                    Debug.Log(">>>" + cloud_word);
                    if (cloud_word[0] == current_word[0]) {
                        already_one_word = true;
                        break;
                    }
                }
            } while (already_one_word);


            GameObject new_cloud = (GameObject)Instantiate(cloud, new Vector3(6.0f, current_y, 0.0f), Quaternion.identity);
            new_cloud.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = current_word.ToUpper();
        }
	}

    public float getCloudSpeed () {
        return cloudSpeed;
    }

    public int getPoints () {
        return points;
    }

    public void addPoints (int pts) {
        points += pts;
    }

    public int getPointsPerWin () {
        return (int)(cloudSpeed * 10);
    }

    public void loseLife () {
        if (lifes > 0) {
            Destroy(GameObject.Find("Life" + lifes));
            lifes--;
        } else {
            // end game
            gameOver = true;
        }
    }

    public int getRemainingLifes () {
        return lifes;
    }

    public void SendScore () {
        string url = "http://localhost:8080/saveScore/" + GameObject.Find("InputText").GetComponent<Text>().text + "&" + points;
        Debug.Log("Sending to " + url);
        HttpGet(url);
    }
}
