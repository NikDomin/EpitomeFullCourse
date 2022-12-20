using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Fighter : MonoBehaviour
    {
        public int hitPoint = 10;
        public int maxHitpoint = 10;
        public float pushRecoverySpeed = 0.2f;

        protected float immuneTime = 1.0f;
        protected float lastImmune;

        protected Vector3 pushDirection;

        //All fighters can ReceiveDamage and die 

        protected virtual void ReceiveDamage(Damage dmg)
        {
            if (Time.time - lastImmune > immuneTime)
            {
                lastImmune = Time.time;
                hitPoint -= dmg.damageAmount;
                pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

                GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.white, transform.position, Vector3.up * 15, 0.5f);

                if (hitPoint <= 0)
                {
                    hitPoint = 0;
                    Death();
                }
            }
        }

        protected virtual void Death()
        {
             
        }
    }
}