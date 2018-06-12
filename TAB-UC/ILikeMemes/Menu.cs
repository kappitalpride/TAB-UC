using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
namespace ILikeMemes
{

    public class Menu : MonoBehaviour
    {
        public Rect playerWindow = new Rect(40, 40, 400, 280);
        public Rect advancedWindow = new Rect(40, 400, 200, 250);
        public bool menuActive = false;

        public Player_ESP playerESP;
        public Advanced adv;

        public Vector2 scrollPosition = Vector2.zero;

        public bool crosshair;

        void Start()
        {
            playerESP = FindObjectOfType<Player_ESP>();
            adv = FindObjectOfType<Advanced>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                menuActive = !menuActive;
            }
        }

        public void OnGUI()
        {
            GUI.color = Color.yellow;
            GUI.Label(new Rect(3, 3, 300f, 20f), "www.unknowncheats.me | Public Source");

            if (crosshair)
            {
                GUI.color = Color.yellow;
                GUI.Label(new Rect(playerESP.ScreenCenterX, playerESP.ScreenCenterY, 25, 25), "+");
            }

            if (menuActive)
            {
                playerWindow = GUI.Window(0, playerWindow, PlayerMenu, "Player");
                advancedWindow = GUI.Window(2, advancedWindow, AdvancedMenu, "LocalPlayer");
            }

        }

        public void PlayerMenu(int window)
        {
            if (menuActive)
            {
                GUI.DragWindow(new Rect(0, 0, 300, 10));
                GUI.color = Color.white;
                playerESP.playerNameEsp = GUI.Toggle(new Rect(25, 50, 150, 20), playerESP.playerNameEsp, " Player Name");
                playerESP.playerHealthEsp = GUI.Toggle(new Rect(25, 100, 150, 20), playerESP.playerHealthEsp, " Player Health");
                playerESP.playerDistanceEsp = GUI.Toggle(new Rect(25, 150, 150, 20), playerESP.playerDistanceEsp, " Player Distance");
                playerESP.playerHeadCrossEsp = GUI.Toggle(new Rect(25, 200, 150, 20), playerESP.playerHeadCrossEsp, " Player Head Cross");
                playerESP.playerDistanceMenu = GUI.HorizontalSlider(new Rect(25, 250, 100, 20), playerESP.playerDistanceMenu, 0f, 1000f);
                GUI.color = Color.cyan;
                float pDistance = Mathf.Ceil(playerESP.playerDistanceMenu);
                GUI.Label(new Rect(25, 260, 100, 100), "Distance " + pDistance);
            }
        }

        public void AdvancedMenu(int window)
        {
            if (menuActive)
            {
                GUI.DragWindow(new Rect(0, 0, 300, 20));
                GUI.color = Color.white;
  
                adv.noRecoil = GUI.Toggle(new Rect(25, 50, 150, 20), adv.noRecoil, " No Recoil");

                adv.infiniteAmmo = GUI.Toggle(new Rect(25, 100, 150, 20), adv.infiniteAmmo, " Infinite Ammo");

                adv.noShake = GUI.Toggle(new Rect(25, 300, 150, 20), adv.noShake, " No Shake");

            }
        }

    }
}




