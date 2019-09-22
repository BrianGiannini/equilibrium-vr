using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public Transform player;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float position = Vector3.Distance(player.position, this.transform.position);
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (position < 8 && angle < 80)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);

            anim.SetBool("isIdle", false);
            anim.SetBool("isAiming", true);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAiming", false);
        }

    }
}
