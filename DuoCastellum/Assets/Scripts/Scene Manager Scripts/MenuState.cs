

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class MenuState : State {

    public MenuState(Controller controller) : base(controller)
    {

    }

    override public void OnPlay() {
        SceneManager.LoadScene("GameScene");
    }

    override public void OnClick()
    {
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        if(button_name == "Options")
        {
            controller.changeState(new OptionsState(controller));
            SceneManager.LoadScene("Options");
        }
         else if (button_name == "Credits")
        {
            controller.changeState(new CreditsState(controller));
            SceneManager.LoadScene("Credits");
        }

    }

    override public void OnBack()
    {
       //No Back at menu
    }
}
