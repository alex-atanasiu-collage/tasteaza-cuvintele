using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
public class ScoreController : MonoBehaviour {

	//public TextMesh Alex;
	//public TextMesh Andrei;
	//public TextMesh Lavinia;
	//public TextMesh Mihaela;
	//public TextMesh Ioana;
	//public TextMesh Zavate;

	public List<User> userList = new List<User> ();

	// Use this for initialization
	void Start () {
		
		string url = "http://localhost:8080/getTop";

		HttpWebRequest req = WebRequest.Create(url)
			as HttpWebRequest;
		string result = null;
		using (HttpWebResponse resp = req.GetResponse()
			as HttpWebResponse)
		{
			StreamReader reader =
				new StreamReader(resp.GetResponseStream());
			result = reader.ReadToEnd();
		}
		Debug.Log(result);

		string jsonToParse = "{\"users\":" + result + "}";

		UserData userData = JsonUtility.FromJson<UserData> (jsonToParse);

		foreach (User user in userData.users) {
			Debug.Log (user.name);
		}

	}
	
	// Update is called once per frame
	void Update () {

		
	
	}
}

[System.Serializable]
public class User
{
	public string id;
	public string name;
	public string password;
	public string score;
}

[System.Serializable]
public class UserData
{
	public List<User> users;
}