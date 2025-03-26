using UnityEngine;
using MiniIT.ENUMS;
using NaughtyAttributes;

namespace MiniIT.CAMERA
{
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField]
        private Vector2           referenceResolution = new Vector2(1080, 1920);

        [SerializeField]
        private WorkingModeCamera mode = WorkingModeCamera.ConstantWidth;

        [ShowIf(nameof(mode), WorkingModeCamera.MatchWidthOrHeight)]
        [Range(0f, 1f)]
        [SerializeField]
        private float             matchWidthOrHeight = 0.5f;

        private Camera            componentCamera = null;

        private float             targetAspect = 1;

        private float             cameraZoom = 1;

        private float             initialSize = 5;

        private void Awake()
        {
            componentCamera = Camera.main;

            initialSize = componentCamera.orthographicSize;

            targetAspect = referenceResolution.x / referenceResolution.y;

            Refresh();
        }

        private void Refresh()
        {
            switch (mode)
            {
                case WorkingModeCamera.ConstantHeight:
                    componentCamera.orthographicSize = initialSize / cameraZoom;
                    break;

                case WorkingModeCamera.ConstantWidth:
                    componentCamera.orthographicSize = initialSize * (targetAspect / componentCamera.aspect) / cameraZoom;
                    break;

                case WorkingModeCamera.MatchWidthOrHeight:
                    float vSize = initialSize;
                    float hSize = initialSize * (targetAspect / componentCamera.aspect);

                    float vLog = Mathf.Log(vSize, 2);
                    float hLog = Mathf.Log(hSize, 2);

                    float logWeightedAverage = Mathf.Lerp(hLog, vLog, matchWidthOrHeight);

                    componentCamera.orthographicSize = Mathf.Pow(2, logWeightedAverage) / cameraZoom;

                    break;

                case WorkingModeCamera.Expand:
                    if (targetAspect > componentCamera.aspect)
                    {
                        componentCamera.orthographicSize = initialSize * (targetAspect / componentCamera.aspect) / cameraZoom;
                    }
                    else
                    {
                        componentCamera.orthographicSize = initialSize / cameraZoom;
                    }

                    break;

                case WorkingModeCamera.Shrink:
                    if (targetAspect < componentCamera.aspect)
                    {
                        componentCamera.orthographicSize = initialSize * (targetAspect / componentCamera.aspect) / cameraZoom;
                    }
                    else
                    {
                        componentCamera.orthographicSize = initialSize / cameraZoom;
                    }

                    break;

                default:
                    componentCamera.orthographicSize = initialSize / cameraZoom;
                    break;
            }
        }
    }
}