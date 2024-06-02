using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public moveUI completeWindow;
    public moveUI completeExplain;

    public moveUI readyWindow;
    public moveUI readyExplain;

    public moveUI roundSelect;
    public moveUI roundExplain;

    public void completeWindowOpen() // 목표 달성 완료 창
    {
        string goal = TextManager.instance.goal.text;
        transform.GetChild(2).GetComponent<completeManager>().open(goal, int.Parse(goal) / 10);
        StartCoroutine(completeExplain.explainDown());
        StartCoroutine(completeWindow.moveUp(-185));
    }

    public void readyWindowOpen() // 준비 (상점) 창 
    {
        readyWindow.transform.parent.gameObject.SetActive(true);
        StartCoroutine(completeExplain.moveUp(765));
        StartCoroutine(readyWindowAnimation());
    }

    IEnumerator readyWindowAnimation()
    {
        yield return StartCoroutine(completeWindow.moveDown(-915));
        yield return new WaitForSecondsRealtime(0.3f);
        StartCoroutine(readyExplain.explainDown());
        StartCoroutine(readyWindow.moveUp(-185));
    }

    public void roundSelectOpen() // 라운드 선택 창
    {
        roundSelect.transform.parent.gameObject.SetActive(true);
        StartCoroutine(readyExplain.moveUp(765));
        StartCoroutine(roundSelectAnimation());
    }

    IEnumerator roundSelectAnimation()
    {
        yield return StartCoroutine(readyWindow.moveDown(-915));
        yield return new WaitForSecondsRealtime(0.3f);
        StartCoroutine(roundExplain.explainDown());
        StartCoroutine(roundSelect.moveUp(-185));
    }

    public void select()
    {
        StartCoroutine(roundExplain.moveUp(765));
        StartCoroutine(selectAnimation());
    }
    IEnumerator selectAnimation()
    {
        yield return StartCoroutine(roundSelect.moveDown(-915));
        yield return new WaitForSecondsRealtime(0.3f);
    }






    // 아직 고려 안함
    public void readyWindowClose()
    {
        StartCoroutine(readyWindow.moveDown(-915));
    }

    public void roundSelectClose()
    {
        StartCoroutine(roundSelect.moveDown(-915));
    }

    public void completeWindowClose()
    {
        StartCoroutine(completeWindow.moveDown(-915));
    }
}
