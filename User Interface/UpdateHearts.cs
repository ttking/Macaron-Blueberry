using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateHearts : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts = new List<GameObject>();

    Animator anim;
    int count;

    // Play animation after live is lost
    public void LiveLost()
    {
        Debug.Log("LostLives");
        anim = hearts[count].GetComponent<Animator>();
        anim.SetTrigger("HeartLost");
        count++;
    }
}
