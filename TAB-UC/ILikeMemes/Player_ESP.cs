using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
namespace ILikeMemes
{

    public class Player_ESP : MonoBehaviour
    {
        //Positions for the players bones
        public Vector3 pPos;
        public Vector3 bottomPos;
        public Vector3 headPos;

        public int ScreenCenterX;
        public int ScreenCenterY;

        public int espOffset;

        //Player array shit
        public Player[] player;

        //Menu Bools
        public bool playerNameEsp = false;
        public bool playerHealthEsp = false;
        public bool playerDistanceEsp = false;
        public bool playerBoxEsp = false;
        public bool playerHeadCrossEsp = false;

        //Distances
        public float playerDistance;

        //Distances for menu
        public float playerDistanceMenu;


        void Start()
        {
            ScreenCenterX = Screen.width / 2;
            ScreenCenterY = Screen.height / 2;

            StartCoroutine(UpdatePlayer(5));
        }

        private IEnumerator UpdatePlayer(int seconds)
        {
            for (; ; )
            {
                yield return new WaitForSeconds(seconds);
                this.player = FindObjectsOfType<Player>();
            }
            yield break;
        }

        public void OnGUI()
        {
            float max = Mathf.Infinity;


            for (int i = 0; i < player.Length; i++)
            {

                if (player[i] == Player.localPlayer || player[i].m_playerDeath.dead || player[i].m_playerDeath.health <= 0 || player[i].m_playerDeath.health > 100)
                    continue;

                //Floats
                float num = Vector3.Distance(Player.localPlayer.m_head.transform.position, player[i].m_playerCamera.transform.position);
                playerDistance = Mathf.Ceil(num);
                float health = Mathf.Ceil(player[i].m_playerDeath.health);
                //Floats

                //Positions
                pPos = Camera.main.WorldToScreenPoint(player[i].m_torso.transform.position);
                pPos.y = (float)Screen.height - pPos.y;
                headPos = Camera.main.WorldToScreenPoint(player[i].headDamagable.transform.position);
                headPos.y = (float)Screen.height - headPos.y;

                float customESPHeight = 25;
                customESPHeight = customESPHeight / playerDistance * 34;
                //Positions

                //Bottom of the player
                bottomPos = pPos + new Vector3(customESPHeight - customESPHeight * 1.35f, customESPHeight, 0);
                //Bottom of the player

                if (this.pPos.z > 0f && playerDistance <= playerDistanceMenu)
                {

                    if (playerNameEsp)
                    {
                        GUI.Label(new Rect(this.bottomPos.x, this.bottomPos.y, 300f, 300f), "<color=white>" + player[i].name + "</color>");
                    }

                    if (playerHealthEsp)
                    {
                        GUI.Label(new Rect(this.bottomPos.x, this.bottomPos.y + 15, 300f, 300f), "<color=red>" + health + "</color>" + "<color=white>" + " HP" + "</color>");
                    }

                    if (playerDistanceEsp)
                    {
                        GUI.Label(new Rect(this.bottomPos.x, this.bottomPos.y + 30, 300f, 300f), "<color=yellow>" + playerDistance + "</color>" + "<color=white>" + " m" + "</color>");
                    }

                    if (playerHeadCrossEsp)
                    {
                        GUI.Label(new Rect(this.headPos.x, this.headPos.y, 300f, 300f), "<color=cyan>+</color>");
                    }


                }
            }
        }
    }
}




