using UnityEngine;

namespace MiniIT.SUPPORT
{
    public class SettableMaxFPS : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
        }
    }
}