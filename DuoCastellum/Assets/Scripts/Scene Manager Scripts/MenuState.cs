

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class MenuState : State {


    public MenuState(Controller controller) 
    {
        
    }
  
    override public void OnPlay() {
        SceneManager.LoadScene("GameScene");
        controller.changeState(gameObject.GetComponent<GameState>());

    }

    override public void OnOptions()
    {
        SceneManager.LoadScene("Instructions");
        controller.changeState(gameObject.GetComponent<InstructionsState>());

    }

    override public void OnCredits()
    {

        SceneManager.LoadScene("Credits");
        controller.changeState(new CreditsState(controller));

    }

    private void OnEnable()
    {

        GameObject.Find("Instructions").GetComponent<Button>().onClick.AddListener(OnOptions);
        GameObject.Find("Credits").GetComponent<Button>().onClick.AddListener(OnCredits);
        GameObject.Find("Play").GetComponent<Button>().onClick.AddListener(OnPlay);

    }

    private void Start()
    {
        this.controller = GameObject.Find("Controller").GetComponent<Controller>();
    }


}
