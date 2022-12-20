using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Mover
{
   private void FixedUpdate()
   {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        UpdateMotor(new Vector3(x,y,0));

   }
}
