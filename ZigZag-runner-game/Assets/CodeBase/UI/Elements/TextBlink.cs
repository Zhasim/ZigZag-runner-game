using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class TextBlink : MonoBehaviour
    {
        public float blinkDuration = 1.5f;
        public float blinkInterval = 0.3f;

        private TextMeshProUGUI textMesh;
        private Sequence blinkSequence;

        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            
            blinkSequence = DOTween.Sequence()
                .Append(textMesh.DOFade(0f, blinkDuration / 2))
                .AppendInterval(blinkInterval)
                .Append(textMesh.DOFade(1f, blinkDuration / 2))
                .AppendInterval(blinkInterval)
                .SetLoops(-1);
            
            blinkSequence.Pause();
            blinkSequence.Play();
        }
        
        public void StartBlinking() => 
            blinkSequence.Play();

        public void StopBlinking() => 
            blinkSequence.Pause();
    }
}