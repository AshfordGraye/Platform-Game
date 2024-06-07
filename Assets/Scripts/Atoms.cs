using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atoms : MonoBehaviour
{
    private MeshCollider atomCollider;
    public ScoreSystem playerScore;
    bool atomCollected = false;

    int atomSpinForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        atomCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!atomCollected)
        {
            spinStandard();
        }
        else
        {
            spinCollected();
        }
    }

    void spinStandard()
    {
        float atomSpinSpeed = atomSpinForce * Time.deltaTime;
        transform.Rotate(0, atomSpinSpeed, 0);
    }
    void spinCollected()
    {
        Debug.Log("" + gameObject.transform.localPosition.y);
        float atomSpinSpeed = atomSpinForce * 20 * Time.deltaTime;
        transform.Rotate(0, atomSpinSpeed, 0);
        transform.Translate(0, 0, 3 * Time.deltaTime);
        Invoke("atomDestroy", 0.5f);
    }
    void atomDestroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            atomCollider.enabled = false;
            if (gameObject.CompareTag("Atom_Low"))
            {
                atomCollected = true;
                playerScore.scoreCurrent += 5;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            else if (gameObject.CompareTag("Atom_Mid"))
            {
                atomCollected = true;
                playerScore.scoreCurrent += 10;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            else if (gameObject.CompareTag("Atom_High"))
            {
                atomCollected = true;
                playerScore.scoreCurrent += 15;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            playerScore.UpdateScoreText();
        }
    }
}
