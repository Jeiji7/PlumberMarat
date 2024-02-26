using UnityEngine;

public class WidthHeightCamera : MonoBehaviour
{
    public float targetAspect = 0.5f;
    void Start()
    {
        Camera mainCamera = Camera.main;
        mainCamera.ResetAspect();
        float currentAspect = (float)Screen.height / Screen.width;
        float orthographicSize = mainCamera.orthographicSize * (currentAspect/targetAspect);
        mainCamera.orthographicSize = orthographicSize;
    }


}
