using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class DebugConsole : MonoBehaviour
{
    public static DebugConsole Instance;
    TMP_Text c;

    public DebugConsole()
    {
        if ( Instance ==null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

    private void Awake()
    {
        c = GetComponent<TMP_Text>();
    }
    public void Log(string message)
    {
        Instance.c.text = $"Log: {message}"; 
    }
}
