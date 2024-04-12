using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events {

    public static class Dial {
        
        // Event to be called when pressing the button
        public delegate void Button();
        public static event Button _Button;
        public static void OnButton() {
            if (_Button == null) return;
            _Button();
        }

        // Event to be called when flicking the switch
        public delegate void Switch();
        public static event Switch _Switch;
        public static void OnSwitch() {
            if (_Switch == null) return;
            _Switch();
        }

        // Event to be called when resetting the game
        public delegate void Reset();
        public static event Reset _Reset;
        public static void OnReset() {
            if (_Reset == null) return;
            _Reset();
        }

        // Event to be called when finishing the game (player has taken 10 actions)
        public delegate void GameFinish();
        public static event GameFinish _GameFinish;
        public static void OnGameFinish() {
            if (_GameFinish == null) return;
            _GameFinish();
        }
    }

}
