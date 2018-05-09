using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //Animator anim;
    public Transform[] BurnPoints;
    public GameObject flamePrefab;
    GameObject[] flames;
    bool isOccupied=false, isOnFire=false;

    private void Awake()
    {
        // anim = GetComponent<Animator>();
        flames = new GameObject[BurnPoints.Length];
        for (int f = 0; f < BurnPoints.Length; f++)
        {
            flames[f] = Instantiate(flamePrefab, BurnPoints[f].position, Quaternion.identity, this.transform) as GameObject;
            flames[f].SetActive(false);
        }
        Ignite();
    }

    public void Ignite()
    {
        isOnFire = true;
        StartCoroutine(SpreadFlame());
       // anim.SetBool("OnFire", true);
    }
   private IEnumerator SpreadFlame()
    {
        for (int f = 0; f < BurnPoints.Length; f++)
        {
            if (!flames[f].activeSelf)
            {
                flames[f].SetActive(true);
            }
            yield return new WaitForSeconds(1.5f);
        }
        yield return null;
    }
}
