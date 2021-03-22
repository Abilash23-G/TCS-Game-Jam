using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit2 : MonoBehaviour
{
    [SerializeField] GameObject finalCompound;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject[] compounds;

    bool isSpawned = false;

    [SerializeField] bool[] Check;

    void Start()
    {

    }

    void Update()
    {
        CheckCompound();

    }

    void OnTriggerEnter(Collider collision)
    {

        for (int index = 0; index < compounds.Length; index++)
        {
            if (collision.gameObject == compounds[index])
            {
                Check[index] = true;
                Destroy(compounds[index]);
            }
        }
    }


    void CheckCompound()
    {
        if (!isSpawned && Check[0] && Check[1])
        {
            Instantiate(finalCompound, spawnPoint.position, spawnPoint.rotation);
            isSpawned = true;
            Invoke("LoadNextLevel", 1f);
        }
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        isSpawned = false;
    }
}
