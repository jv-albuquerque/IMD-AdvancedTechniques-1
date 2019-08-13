using UnityEngine;
using UnityEngine.UI;

public class UpdateHopUpCount : MonoBehaviour
{
    private Slider slider;

    public static UpdateHopUpCount instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        slider = GetComponent<Slider>();
    }

    public void SetHopUp(float hopUpForce)
    {
        slider.value = (hopUpForce - 0.001f) / 0.039f;
    }
}
