using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InstructionsState : State {

    public InstructionsState(Controller controller)
    {

    }
    override public void OnBack()
    {
        controller.changeState(new InstructionsState(controller));
        SceneManager.LoadScene("MenuScene");
    }

   
    private void Start()
    {
        this.controller = GameObject.Find("Controller").GetComponent<Controller>();
    }
}
