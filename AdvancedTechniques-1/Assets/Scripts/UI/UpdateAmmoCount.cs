using UnityEngine;
using TMPro;

public class UpdateAmmoCount : MonoBehaviour
{
    private TextMeshProUGUI ammoTxt;

    public static UpdateAmmoCount instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        ammoTxt = GetComponent<TextMeshProUGUI>();
    }

    public void SetAmmo(int ammo)
    {
        ammoTxt.text = ammo.ToString() + " / 0";
    }

}
