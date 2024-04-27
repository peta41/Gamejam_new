using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "Enemy")
        {
            print("ENTER");
        }
    }
    void OnTriggerStay(Collider other){

        if(other.gameObject.tag == "Enemy")
        {
            print("STAY");
        }
    }
    void OnTriggerExit(Collider other){

        if(other.gameObject.tag == "Enemy")
        {
            print("STAY");
        }
    }
}
