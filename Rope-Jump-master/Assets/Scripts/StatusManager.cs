using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StatusManager : MonoBehaviour
{

    public const int IDLE_STATUS_KEY = 0;
    public const int PLAY_STATUS_KEY = 1;
    public const int END_STATUS_KEY = 2;

    public int gameState;

    // Use this for initialization
    void Start()
    {
        setState(IDLE_STATUS_KEY);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && gameState == StatusManager.END_STATUS_KEY)
        {
            SceneManager.LoadScene("GamePlay");
            setState(StatusManager.IDLE_STATUS_KEY);
        }
    }

    public int getState()
    {
        return gameState;
    }

    public Animator bottomLabelAnimator;
    public RopeBehaviours ropeBehaviours;
    public GameObject player;
    public ScoreManager scoreManager;
    public Transform playerSpawn;

    public void setState(int newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case IDLE_STATUS_KEY:
                {
                    //GameObject frackles = (GameObject)Instantiate(player, playerSpawn.position, playerSpawn.rotation);
                    player.SetActive(true);
                    scoreManager.PlayAgain();
                    bottomLabelAnimator.SetBool("isVisible", true);
                    ropeBehaviours.enabled = false;
                    break;
                }
            case PLAY_STATUS_KEY:
                {
                    bottomLabelAnimator.SetBool("isVisible", false);
                    ropeBehaviours.enabled = true;
                    GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
                    Rigidbody playerRigidbody = currentPlayer.GetComponent<Rigidbody>();
                    playerRigidbody.useGravity = true;
                    break;
                }
            case END_STATUS_KEY:
                {
                    scoreManager.isHighscore();
                    bottomLabelAnimator.SetBool("isVisible", true);
                    break;
                }
        }
    }
}