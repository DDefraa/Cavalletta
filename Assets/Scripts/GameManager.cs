using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject player;

    public void CheckWinState()
    {
        int aliveCount = 0;
        
        foreach (GameObject enemy in enemy)
        {
            if (enemy.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount == 0)
        {
            Invoke(nameof(Victory), 1f);
        }

    }

    private void Victory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void LooseState()
    {
        SceneManager.LoadScene("Lost");

    }

}
