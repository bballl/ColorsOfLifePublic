using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Locations
{
    public class Timer : MonoBehaviour
    {
        public TimerProperties TimerMod;
        public GameObject Arrow;
        public SpriteRenderer Panel;

        private bool _flag;
        private float _timeLeft = 0f;
        private bool isNight = false;
        private float _speed = 3f;

        private void Update()
        {
            Color col = Panel.color;

            if (isNight && Panel.color.a < 0.55f)
            {
                col.a += Time.deltaTime * (0.55f / _speed);
                Debug.Log($"fadind in: +{Time.deltaTime * (0.55f / _speed)} / Alpha now: {col.a}");
                Panel.color = col;
            }
            else if (!isNight && Panel.color.a > 0)
            {
                col.a -= Time.deltaTime * (0.55f / _speed);
                Panel.color = col;
            }
        }

        private IEnumerator StartTimer()
        {
            while (true)
            {
                _timeLeft -= Time.deltaTime;
                if (!isNight && _timeLeft < (TimerMod.Time - TimerMod.Delay))
                {
                    isNight = true; // Началась ночь
                    //StartNight();
                    Invoke("NightStart", 0f);
                }

                if (_timeLeft < 0)
                {
                    isNight = false;
                    _timeLeft = TimerMod.Time; // Снова начался день
                    //StartDay();
                    Debug.Log("Day");
                }
                var normalizedValue = Mathf.Clamp(_timeLeft / TimerMod.Time, 0.0f, 1.0f);
                //TimerImage.fillAmount = normalizedValue;
                Arrow.transform.localEulerAngles = new Vector3(0, 0, normalizedValue * 360);
                yield return null;
            }
        }

        private void Start()
        {
            _timeLeft = TimerMod.Time;
            StartCoroutine(StartTimer());
        }

        public void NightStart() 
        {
            Debug.Log("Night");
        }

        public void StartNight()
        {
            //Panel.material.color.a = 194;
            Color col = Panel.color;
            col.a = 1f;
            Panel.color = col;
        }

        public void StartDay()
        {
            Color col = Panel.color;
            col.a = 0;
            Panel.color = col;
        }

    }
}
    