using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneOperator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartScene", 3f);
    }

    // Update is called once per frame
    void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
