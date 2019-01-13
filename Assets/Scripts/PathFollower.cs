using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    Node [] pathNode;
    public GameObject barrel;
    public float speed;
    float Timer;
    int currentNode;
    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        pathNode = GetComponentsInChildren<Node>();
        Animator anim = barrel.GetComponent<Animator>();
        anim.SetBool("isRolling", true);
        CheckNode();
	}

    void CheckNode() {
        if (currentNode < pathNode.Length - 1)
        {
            Timer = 0;
            currentPosition = pathNode[currentNode].transform.position;
        }
    }

    // Update is called once per frame
    void Update () {
        Timer += Time.deltaTime * speed;
        if(barrel.transform.position != currentPosition) {
            //barrel.transform.position = Vector3.Lerp(barrel.transform.position, currentPosition, Timer);
            barrel.transform.position = Vector3.MoveTowards(barrel.transform.position, currentPosition, 0.025f);
        }
        else {
            if (currentNode < pathNode.Length - 1)
            {
                currentNode++;
                CheckNode();
            }   
        }
	}
}
