using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public GameObject Die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartScene()
    {
        Die.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void StartScene()
    {
        Die.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
