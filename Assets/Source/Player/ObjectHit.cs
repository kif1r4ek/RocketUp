using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
    private Movement _movement;
    private SwitchSaund _switchSaund;
    private SwitchParticle _switchParticle;

    private int currentLevel;

    private float levelLoadDelay;

    private bool isTransitioning = false;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _switchSaund = GetComponent<SwitchSaund>();
        _switchParticle = GetComponent<SwitchParticle>();

        currentLevel = SceneManager.GetActiveScene().buildIndex;

        levelLoadDelay = 2.5f;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            CrashSequence();
        }
        else if (collision.gameObject.tag == "Finish")
        {
            SuccessSequence();
        }
    }

    private void CrashSequence()
    {
        isTransitioning = true;

        StopMovement();
        _switchSaund.PlayFirstSaund();
        _switchParticle.PlayFirstParticle();
        Invoke("ReloadLeval", levelLoadDelay);
    }

    private void SuccessSequence()
    {
        isTransitioning = true;

        StopMovement();
        _switchSaund.PlaySecondSaund();
        _switchParticle.PlaySecondParticle();

        Invoke("NextLevel", levelLoadDelay);
    }

    private void StopMovement()
    {
        _movement.enabled = false;
    }

    private void ReloadLeval()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private void NextLevel()
    {
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }

}
