using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public UIElements uiElements;
    
    public IEnumerator ShowPrize()
    {
        uiElements.prizeFrame.enabled = true;
        yield return new WaitForSeconds(1f);
        Animator anim = uiElements.prizeWindow.GetComponent<Animator>();
        uiElements.prizeWindow.SetActive(true);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length 
                                       + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        uiElements.prizeWindow.SetActive(false);
        uiElements.prizeFrame.enabled = false;
    }

}

[System.Serializable]
public class UIElements
{    
    public GameObject prizeWindow;
    public Image prizeFrame;
}