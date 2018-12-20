using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsState : State {

    public CreditsState(Controller controller) : base(controller)
    {

    }
    override public void OnBack()
    {
       
        controller.changeState(new OptionsState(controller));
        SceneManager.LoadScene("MenuScene");
    }

    public override void OnClick()
    {
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
