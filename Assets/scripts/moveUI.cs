using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUI : MonoBehaviour
{
    public RectTransform ui;
    public IEnumerator moveUp(int y)
    {
        while (ui.anchoredPosition.y <= y)
        {
            ui.anchoredPosition += Vector2.up * 5;
            yield return null;
        }
    }

    public IEnumerator moveDown(int y)
    {
        while (ui.anchoredPosition.y >= y)
        {
            ui.anchoredPosition += Vector2.down * 5;
            yield return null;
        }
        transform.parent.gameObject.SetActive(false);
    }

    public IEnumerator explainDown()
    {
        while (ui.anchoredPosition.y >= 355)
        {
            ui.anchoredPosition += Vector2.down * 5;
            yield return null;
        }
    }
}
