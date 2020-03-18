using UnityEngine;
using System.Collections;

public class PlayerBehaviours : MonoBehaviour {

    public float jumpPower = 5f;
    private bool isGrounded = true;
    public GameObject fractured;
    public StatusManager statusManager;

    public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && statusManager.getState() == StatusManager.IDLE_STATUS_KEY)
        {
            statusManager.setState(StatusManager.PLAY_STATUS_KEY);
        }

        if (Input.GetMouseButtonDown(0) && isGrounded && statusManager.getState() == StatusManager.PLAY_STATUS_KEY) {
            isGrounded = false;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            scoreManager.IncreaseScore();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag.Equals("Rope"))
        {
            GameObject frackles = (GameObject) Instantiate(fractured, transform.position, transform.rotation);

            Destroy(frackles, 1000);

            statusManager.setState(StatusManager.END_STATUS_KEY);

            Destroy(gameObject);
        }
    }

}
