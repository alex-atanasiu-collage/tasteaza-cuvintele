using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class cloud : MonoBehaviour {
    string[] dif_anims = { "idle", "translate", "scale-trans", "rotate"};


	// Use this for initialization
	void Start () {
        int level = GameObject.Find("GameMaster").GetComponent<GameMaster>().getLevel();

        int nums = level % 4;

        GetComponent<Animator>().SetTrigger(dif_anims[Random.Range(0, nums)]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
