using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowUtil : MonoBehaviour
{
    #region Singleton
    public static RowUtil Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<string> rowMatchedContainer = new List<string>();
}
