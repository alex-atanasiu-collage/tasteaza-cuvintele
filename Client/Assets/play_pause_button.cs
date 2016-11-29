using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]
public class play_pause_button : MonoBehaviour {
    public Sprite play_sprite;
    public Sprite pause_sprite;
    bool play;

	// Use this for initialization
	void Start () {
        play = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ChangeSprite();
        }
	}

    public void ChangeSprite () {
        if (!play)
            GetComponent<Image>().sprite = pause_sprite;
        else
            GetComponent<Image>().sprite = play_sprite;

        play = !play;
        if (play)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;
    }

    public void reloadGame () {
        Application.LoadLevel("scene");
    }
}
