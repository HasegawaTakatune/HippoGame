using UnityEngine;

public class ReturnToTitle : MonoBehaviour {

	void Start () {
        Invoke("toTitle", 15);
	}

    void toTitle()
    {
        GameObject.FindGameObjectWithTag("MainManager").GetComponent<G1_GameManager>().GameTitle();
    }
}
