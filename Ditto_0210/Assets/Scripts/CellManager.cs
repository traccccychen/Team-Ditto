using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public static CellManager instance = null;
    public int PlayerNumber =1;
    public float DefaultMass = 10;
    public float DefaultSpeed = 3;
    public float SpeedDamp = 0.3f;

    void Awake() {
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
