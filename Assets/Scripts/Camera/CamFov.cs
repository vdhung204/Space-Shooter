using UnityEngine;

public class CamFov : MonoBehaviour
{
    public float fov { get; private set; }

    [HideInInspector] public bool canReset = true;

    // Grab the field of view value from the camera.
    private void Start() => fov = GetComponent<Camera>().fieldOfView;

    private void Update()
    {
        // If we can perform it, lerp the current field of view to the initial FOV.
        if (canReset) GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, fov, Time.deltaTime * 20);
    }
}
