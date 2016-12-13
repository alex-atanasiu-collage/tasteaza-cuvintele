using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    private float cloudSpeed;
    private int points;
    private int lifes;

    public GameObject cloud;

    // Use this for initialization
	void Start () {
        cloudSpeed = 1.0f;

        lifes = 3;
	}
	
	// Update is called once per frame
	void Update () {
        cloudSpeed += 0.001f;
        //Debug.Log("Cloud speed: " + cloudSpeed);

        GameObject.Find("ScoreText").GetComponent<Text>().text = "" + points;


        float max_x = 0.0f;
        foreach (GameObject cloud in GameObject.FindGameObjectsWithTag("Cloud")) {
            float thisx = cloud.transform.position.x;
            if (max_x < thisx) {
                max_x = thisx;
            }
        }

        if (max_x < 4f) {
            Instantiate(cloud, new Vector3(6.0f, Random.Range(-0.5f, 1.5f), 0.0f), Quaternion.identity);
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
        }
    }

    public int getRemainingLifes () {
        return lifes;
    }
}
