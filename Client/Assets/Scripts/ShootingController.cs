using UnityEngine;
using System.Collections;

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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
