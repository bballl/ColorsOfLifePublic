using Assets.Scripts.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PaintScaleViewController : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        
        private void Awake()
        {
            PaintScaleController.OnUpdatePaintScaleView += UpdateScaleView;
            
        }

        private void OnDestroy()
        {
            PaintScaleController.OnUpdatePaintScaleView -= UpdateScaleView;
        }

        private void UpdateScaleView(float curruntValue, float maxValue)
        {
            progressBar.fillAmount = curruntValue / maxValue;
        }
    }
}
