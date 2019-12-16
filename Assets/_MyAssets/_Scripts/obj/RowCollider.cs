using UnityEngine;

public class RowCollider : MonoBehaviour
{
    private SlotRulesController _slotRulesController;

    // flag to checks if the symbol it's already added
    [SerializeField] 
    private bool isAdded;

    // stores the current symbol
   [SerializeField] private Transform symbol;

    private void Start()
    {
        _slotRulesController = SlotRulesController.Instance;
        symbol = transform;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {     
        // If the current symbol collides with the match row
        //stores in a match list
        if (!isAdded && other.tag == "boundCenter")
        {
            _slotRulesController.AddMatch(symbol.name);
            isAdded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the current symbol collides with the outside row
        //deletes from the match list
        if (other.tag == "boundBottom")
        {
            _slotRulesController.QuitMatch(symbol.name);
            isAdded = false;          
        }       
    }
}
