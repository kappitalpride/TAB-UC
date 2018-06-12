using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
namespace ILikeMemes
{
    public class Advanced : MonoBehaviour
    {
        public Weapon weapon;

        public bool infiniteAmmo = false;
        public bool noRecoil = false;
        public bool noShake = false;

        public float noclipSpeed = 0.1f;

        void Start()
        {
            StartCoroutine(FindWeapon(2));
            StartCoroutine(UpdateWeapon(2.5f));
        }

        private IEnumerator FindWeapon(float seconds)
        {
            while (true)
            {
                weapon = FindObjectOfType<Weapon>();
                yield return new WaitForSeconds(seconds);
            }
            yield break;
        }

        private IEnumerator UpdateWeapon(float seconds)
        {
            while (true)
            {
                yield return new WaitForSeconds(seconds);
                if (noRecoil)
                    DestroyObject(FindObjectOfType<Recoil>());
                if (noShake)
                    DestroyObject(FindObjectOfType<AddScreenShake>());
            }
            yield break;
        }

        void Update()
        {
            if (infiniteAmmo && weapon.gun.bullets <= 500)
                weapon.gun.bullets = 999;
        }

    }

}
