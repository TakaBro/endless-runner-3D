using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += (-PlayerController.player.transform.forward) * Constants.SCROLL_SPEED;
    }
}
