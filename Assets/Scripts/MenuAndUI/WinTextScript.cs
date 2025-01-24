using TMPro;
using UnityEngine;
public class WinTextScript : MonoBehaviour
{
    private void WinTextChange()
    {
        gameObject.GetComponent<TMP_Text>().text = "Za chwilê przejdzisz na nastêpny poziom";
    }
}
