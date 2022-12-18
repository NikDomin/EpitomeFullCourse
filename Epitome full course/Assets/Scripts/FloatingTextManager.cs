using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class FloatingTextManager : MonoBehaviour
    {
        public GameObject textContainer;
        public GameObject textPrefab;

        private List<FloatingText> floatingTexts = new List<FloatingText>();

        private void Update()
        {
            foreach (FloatingText txt in floatingTexts)
            {
                txt.UpdateFloatingText();
            }
        }

        public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
        {
            FloatingText floatingText = getFloatingText();

            floatingText.txt.text = msg;
            floatingText.txt.fontSize = fontSize;
            floatingText.txt.color = color;
            floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);// Transfer world space to screen space so we can use it in the UI
            floatingText.motion = motion;
            floatingText.duration = duration;

            floatingText.Show();
        }

        private FloatingText getFloatingText()
        {
            FloatingText txt = floatingTexts.Find(t => !t.active); // проходим по массиву floatingTexts и ищем то что не активно, если ничего не находит делает txt null object

            if (txt == null)
            {
                txt = new FloatingText();//создаем новый txt
                txt.go = Instantiate(textPrefab);//копируем его с префаба
                txt.go.transform.SetParent(textContainer.transform);
                txt.txt = txt.go.GetComponent<Text>();

                floatingTexts.Add(txt);
            }

            return txt; // если что-то нашли в поиске массива - возвращаем 
        }
    }
}