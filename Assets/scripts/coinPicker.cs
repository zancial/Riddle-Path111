using UnityEngine;
using TMPro;

public class coinPicker : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsText;
    public int key = 0;
    public TMP_Text keyText;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(coll.gameObject);
            AudioManager.Instance.PlaySFX("Coin");
        }

        if (coll.gameObject.tag == "Key")
        {
            key++;
            keyText.text = key.ToString();
            Destroy(coll.gameObject);
            AudioManager.Instance.PlaySFX("Key");
        }
    }
}
