using UnityEngine;
using Assets.Scripts.Mafias;

namespace Assets.Scripts.Buildings
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private GameObject viewColor;
        [SerializeField] private GameObject viewSepia;
        
        private bool isColorful;
        private ParticalSystemAnimatorControl[] anim;

        private void Start()
        {
            anim = GetComponentsInChildren<ParticalSystemAnimatorControl>();
            anim[0].EventOnEndAnimation += Painting;

            //
            AIController.On—haracter—ontact += LoseColor;
                    
            if (isColorful)
            {
                viewColor.SetActive(true);
                viewSepia.SetActive(false);
            }
            else
            {
                viewColor.SetActive(false);
                viewSepia.SetActive(true);
            }
        }
        private void OnDestroy()
        {
            anim[0].EventOnEndAnimation -= Painting;
            AIController.On—haracter—ontact -= LoseColor;
        }

        private void Painting()
        {
            if (isColorful == false)
            {
                isColorful = true;
                viewColor.SetActive(true);
                viewSepia.SetActive(false);
            }
        }

        private void LoseColor()
        {
            isColorful = false;
            viewColor.SetActive(false);
            viewSepia.SetActive(true);
        }

    }
}

