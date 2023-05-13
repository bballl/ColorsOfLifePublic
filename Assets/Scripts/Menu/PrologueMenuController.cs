using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.CoreModule;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class PrologueMenuController : MonoBehaviour
    {
        [SerializeField] private Button NextPage;
        [SerializeField] private Image _im;
        public Sprite One;
        public Sprite Two;
        public Sprite Three;
        public Sprite Four;
        public Sprite Five;
        private int _now = 1;
        
        private void Awake()
        {
            NextPage.onClick.AddListener(() => Next());
        }

        private void Next()
        {
            if (_now == 1)
            {
                _im.sprite = Two;
                _now = 2;
            }
            else if (_now == 2)
            {
                _im.sprite = Three;
                _now = 3;
            }
            else if (_now == 3) 
            {
                 _im.sprite = Four;
                _now = 4;
            }
            else if (_now == 4)
            {
                _im.sprite = Five;
                NextPage.transform.GetChild(0).GetComponent<Text>().text = "Μενώ";
                _now = 5;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
