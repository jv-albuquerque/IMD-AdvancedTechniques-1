using UnityEngine;
using TMPro;

public class UpdateManualAutomatic : MonoBehaviour
{
    private TextMeshProUGUI typeTxt;

    public static UpdateManualAutomatic instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        typeTxt = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(bool isAutomatic)
    {
        if(isAutomatic)
            typeTxt.text = "Automatic";
        else
            typeTxt.text = "Manual";
    }
}
