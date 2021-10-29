using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += (- GameManager.instance.player.gameObject.transform.forward) * Constants.SCROLL_SPEED;
    }
}
