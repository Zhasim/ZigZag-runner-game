namespace CodeBase.Infrastructure.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public bool GetInputDown() => 
            UnityEngine.Input.GetMouseButtonDown(0);
    }
}