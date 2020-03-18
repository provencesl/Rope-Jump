using UnityEngine;
using System.Collections;

public class RopeBehaviours : MonoBehaviour {

    public float spinSpeed;
    public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float speed = spinSpeed + (scoreManager.GetScore() / 10);
        Debug.Log(speed);
        transform.Rotate(transform.forward * speed);
	}
}
