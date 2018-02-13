using UnityEngine;

public class ReturnToTitle : MonoBehaviour {

	void OnEnable () {
        Invoke("toTitle", 5);
	}

    void toTitle()
    {
        GameObject.FindGameObjectWithTag("MainManager").GetComponent<G1_GameManager>().GameTitle();
    }
}
