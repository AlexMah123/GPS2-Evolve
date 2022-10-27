using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevour : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Devour Hitbox"))
        {
            if(PlayerController.Instance.devouring)
            {
                Destroy(gameObject);
            }
            /*if (PlayerController.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Devour"))
            {
                if (PlayerController.Instance.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !PlayerController.Instance.animator.IsInTransition(0))
                {
                    Destroy(gameObject);
                }
            }*/
        }
    }

}
