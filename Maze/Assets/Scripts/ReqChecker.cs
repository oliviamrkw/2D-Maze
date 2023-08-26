using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqChecker : MonoBehaviour
{
    public GameObject requirement1;
    public GameObject requirement2;
    public GameObject destroyObject;
    public GameObject enableObject1;
    public GameObject enableObject2;

    void Update(){
        if (requirement1 == null && requirement2 == null)
        {
            Destroy(destroyObject);
            enableObject1.SetActive(true);
            enableObject2.SetActive(true);
        }
    }

}
