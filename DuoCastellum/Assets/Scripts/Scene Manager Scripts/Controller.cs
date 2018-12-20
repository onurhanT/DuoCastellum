using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Controller : MonoBehaviour { 
    
        private State state;
       

        public void Start()
        {
            this.state = new MenuState(this);
        }

        public void changeState(State state)
        {
            this.state = state;
        }
        public State getState()
        {
            return state;
        }
    }



