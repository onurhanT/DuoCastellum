using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsState : State {

    private Button back;
    public CreditsState(Controller controller) 
    {
        
    }
    override public void OnBack()
    {
        SceneManager.LoadScene("MenuScene");
        controller.changeState(gameObject.GetComponent<MenuState>());   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBack();
        }
    }



}
