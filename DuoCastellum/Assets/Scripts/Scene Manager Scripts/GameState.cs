using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameState : State {
    private GameObject gameManager;

    public GameState(Controller controller) 
    {

    }
    override public void OnBack()
    {
        SceneManager.LoadScene("MenuScene");
        controller.changeState(gameObject.GetComponent<MenuState>());
    }
    override public void OnMute()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().volume = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBack();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnMute();
        }
    }
}
