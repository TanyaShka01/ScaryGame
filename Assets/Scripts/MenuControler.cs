using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public Button StartGameButton;
    public Button ContinueGameButton;
    public Button OpenSetingsButton;
    public Button CloseSetingsButton;
    public GameObject SetingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(StartGame);
        ContinueGameButton.onClick.AddListener(ContinueGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
    }

    void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }
}
