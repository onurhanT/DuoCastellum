using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameState : State {

    public GameState(Controller controller) : base(controller)
    {

    }
    override public void OnBack()
    {
        controller.changeState(new OptionsState(controller));
        SceneManager.LoadScene("MenuScene");
    }

    public override void OnClick()
    {
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        //No Functionality
    }

    public override void OnPlay()
    {
        //No Functionality
    }

    public override void OnNext()
    {
        //No Functionality
    }
}
