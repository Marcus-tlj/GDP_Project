using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Retry : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void retrygame()
    {
        SceneManager.LoadScene("game_scene");
    }
    public void leave()
    {
        SceneManager.LoadScene("main_menu");
    }
}
