using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfterTime : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(delCo());
    }
    IEnumerator delCo()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
