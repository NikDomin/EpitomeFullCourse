using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Portal : Collidable
    {
        public string[] SceneNames;

        protected override void OnCollide(Collider2D coll)
        {
            if (coll.name == "Player")
            {
                // teleport player to random scene
                GameManager.instance.SaveState();//сохранить при выходе из уровня
                string sceneName = SceneNames[Random.Range(0, SceneNames.Length)];

                SceneManager.LoadScene(sceneName);
            }
        }
    }
}