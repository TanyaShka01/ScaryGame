using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseManu : MonoBehaviour
{
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Restart.onClick.AddListener(MakeRestart);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Over()
    {
        gameObject.SetActive(true);
    }

    void MakeRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
