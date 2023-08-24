using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Infrastructure.Foundation.Curtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Curtain.alpha = 1;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.DOFade(1.0f, 0.3f);
        }

        public void Hide()
        {
            Curtain.DOFade(0.0f, 0.3f).OnComplete(() => 
                gameObject.SetActive(false));
        }
    }
}