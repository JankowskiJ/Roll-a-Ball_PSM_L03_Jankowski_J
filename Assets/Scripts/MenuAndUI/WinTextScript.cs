using TMPro;
using UnityEngine;
public class WinTextScript : MonoBehaviour
{
    private void WinTextChange()
    {
        gameObject.GetComponent<TMP_Text>().text = "Za chwil� przejdzisz na nast�pny poziom";
    }
}
