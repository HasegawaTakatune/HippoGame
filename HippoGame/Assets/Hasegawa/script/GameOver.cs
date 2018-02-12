using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField]
    GameObject HippoMouth;
    [SerializeField]
    GameObject Blood1;
    [SerializeField]
    GameObject Blood2;
    [SerializeField]
    Image panel;

    Color color;

    void OnEnable()
    {
        color = panel.color;
        StartCoroutine(Production());
    }

    IEnumerator Production()
    {
        HippoMouth.SetActive(true);
        yield return new WaitForSeconds(1);
        Blood1.SetActive(true);
        yield return new WaitForSeconds(1);
        Blood2.SetActive(true);
        yield return new WaitForSeconds(.5f);

        while (color.a <= 1)
        {
            color.a += .05f;
            panel.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("MainManager").GetComponent<G1_GameManager>().GameTitle();
    }
}
