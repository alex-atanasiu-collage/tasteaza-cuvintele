using UnityEngine;
using System.Collections;

public class change_letter : MonoBehaviour {
    public TextMesh text;
    public char letter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + System.Char.ToUpper(letter);
	}
}
