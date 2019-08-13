using UnityEngine;
using TMPro;

public class UpdateTypeOfGun : MonoBehaviour
{
    private TextMeshProUGUI typeTxt;

    public static UpdateTypeOfGun instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        typeTxt = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string gunType)
    {
        typeTxt.text = gunType;
    }
}
