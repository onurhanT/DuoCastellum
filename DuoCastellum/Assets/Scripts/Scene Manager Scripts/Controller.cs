using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Controller : MonoBehaviour { 
    
        private State state;
       

        public void Start()
        {
            this.state = new MenuState(this);
            state = gameObject.AddComponent<MenuState>() as MenuState;        
        }

        public void changeState(State state)
        {
            this.state = state;
            state = this.gameObject.AddComponent<CreditsState>() as CreditsState;

    }
        public State getState()
        {
            return state;
        }

}



