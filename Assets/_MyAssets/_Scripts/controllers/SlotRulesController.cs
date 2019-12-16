using UnityEngine;
public class SlotRulesController : MonoBehaviour
{
    /// <summary>
    /// Instance of a helper class container
    /// to store the current symbols match
    /// </summary>
    private RowUtil _rowUtil;

    #region Singleton
    public static SlotRulesController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        _rowUtil = RowUtil.Instance;
    }

    /// <summary>
    /// Add the current matched symbol row
    /// </summary>
    /// <param name="rowName"></param>
    public void AddMatch(string rowName)
    {
        _rowUtil.rowMatchedContainer.Add(rowName);
        Debug.Log("<color=green> New match " + rowName + " added</color>");
    }

    /// <summary>
    /// Quit the symbol if is not in the match row
    /// </summary>
    /// <param name="rowName"></param>
    public void QuitMatch(string rowName)
    {
        int index = _rowUtil.rowMatchedContainer.IndexOf(rowName);      
        if(_rowUtil.rowMatchedContainer.Contains(rowName))
            _rowUtil.rowMatchedContainer.RemoveAt(index);
            Debug.Log("<color=red> The match " + rowName+ " has been deleted </color>");
    }
}
