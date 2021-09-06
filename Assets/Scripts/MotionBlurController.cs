using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MotionBlurController : MonoBehaviour
{
    public GameObject nitro;

    void Start()
    {
        GetComponent<PostProcessLayer>().enabled = false;
    }

    void Update()
    {
        if (nitro.activeInHierarchy)
        {
            GetComponent<PostProcessLayer>().enabled = true;
        }   
    }
}
