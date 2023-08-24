using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class MobileInputService : IInputService
    {
        public bool GetInputDown() => 
            UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began;
    }
}