﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chest : Collectable
    {
        public Sprite emptyChest;
        public int pesosAmount = 5;

        protected override void OnCollect()
        {
            if (!collected)
            {
                base.OnCollect();
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 15, 3.0f);
            }

        }
    }
}