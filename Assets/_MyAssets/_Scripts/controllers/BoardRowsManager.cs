using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardRowsManager : MonoBehaviour
{
    //reference of matched symbol list
    private RowUtil _rowUtil;

    // frame of matches win
    [SerializeField]
    private Image frameImg;

    // reference whellControllers references
    [SerializeField]
    private WheelController[] wheelControllers;

    // reference of spin button UI
    [SerializeField]
    private Button spinButton;

    // reference of UI prize tezxt
    [SerializeField]
    private TextMeshProUGUI prizeText;

    // reference of UICOntroller
    private UIController _uiController;

    private void Start()
    {
        _rowUtil = RowUtil.Instance;
        _uiController = UIController.Instance;
    }

    public void Spin()
    {
        StartCoroutine(RotateWheel());
    }

    private IEnumerator RotateWheel()
    {
        float timer = RandomTimer.RandomInterval();
        StartCoroutine(DisableSpinButton(timer));

        for (int i = 0; i < wheelControllers.Length;)
        {
            StartCoroutine(wheelControllers[i].RotateWheel(timer));
            yield return new WaitForSeconds(.2f);
            i++;
        }       
        yield return null;       
    }                                                                                                                                                                                                                                  

    private IEnumerator DisableSpinButton(float timer)
    {
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            spinButton.interactable = false;
            yield return null;          
        }
      
        spinButton.interactable = true;
        yield return new WaitForSeconds(1f);
        CheckResults();
    }

    private void CheckResults()
    {
        int matchesQuantity = 0;
        //TODO: agroup the matches and set score
        List<string> matches = _rowUtil.rowMatchedContainer;
        
        for (int i = 0; i < matches.Count; i++)
        {
            var match = matches[0];

            if(match == matches[i])
            {
                matchesQuantity++;
            }
            else
            {
                Debug.Log("There's not more matches!");
                break;
            }
        }

        // checks the prizes of matches
        if (matchesQuantity >= 4)
        {
            int prize = 100;
            prizeText.text = prize.ToString();
            StartCoroutine(_uiController.ShowPrize());
        }

        else if (matchesQuantity >= 3)
        {
            int prize = 75;
            prizeText.text = prize.ToString();
            StartCoroutine(_uiController.ShowPrize());
        }       

        else if (matchesQuantity >= 2)
        {
            int prize = 50;
            prizeText.text = prize.ToString();
            StartCoroutine(_uiController.ShowPrize());
        }
    }
}
