using UnityEngine;

public class Puddle : MonoBehaviour {

	void Start () {
        ObjectList.AddPuddleList(gameObject);
	}
    void OnDestroy()
    {
        ObjectList.RemoveAtPuddleList(0);
    }
}
