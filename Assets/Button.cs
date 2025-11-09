using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button");
    }
}
