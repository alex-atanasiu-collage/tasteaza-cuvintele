using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class moving_cloud : MonoBehaviour {
    private Rigidbody2D currentRigidBody;

    public float speed;
	// Use this for initialization
	void Start () {
        currentRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float s = GameObject.Find("GameMaster").GetComponent<GameMaster>().getCloudSpeed();

        currentRigidBody.velocity = new Vector2(-s, 0);


        if (transform.position.x < -5) {
            GameObject.Find("GameMaster").GetComponent<GameMaster>().loseLife();
            Destroy(gameObject);
        }

	}
}
