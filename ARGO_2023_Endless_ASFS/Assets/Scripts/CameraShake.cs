using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// These are the properties for the camera shaker
    /// </summary>
    public Transform cameraTransform;
    private Vector3 originalCameraPos;

    public float shakeDuration = 0;
    public float shakeAmount = 0.7f;

    public static CameraShake instance;

    private bool canShake = false;

    /// <summary>
    /// On awake it checks if there is only one camera
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// On start we save the starting position of the camera
    /// </summary>
    void Start()
    {
        originalCameraPos = cameraTransform.localPosition;
    }
    /// <summary>
    /// when this function is called the shake duration is being passed in and we set the new duration of the shake screen.
    /// </summary>
    /// <param name="_shakeDuration"></param>
    public void shakeCamera(float _shakeDuration)
    {
        canShake = true;
        shakeDuration = _shakeDuration;
    }
    /// <summary>
    /// Here we shake the camera around for duration that is being passed in inot the function
    /// </summary>
    void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.position = originalCameraPos;
        }
    }
}
