using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane, edited by Alex
public class EnemyStatus : MonoBehaviour
{
    [Header("Enemy Status")]
    public EnemyScriptable ess;
    public float tempHealth;
    public float stunDuration = 3f;
    DamageFlashEnemy damageFlashEnemy;

    Rigidbody rb;
    bool killed;
    bool delay;
    bool stun;

    private void Awake()
    {
        tempHealth = ess.Health;
        damageFlashEnemy = GetComponent<DamageFlashEnemy>();
        rb = GetComponent<Rigidbody>();
        killed = false;
        delay = false;
        stun = false;

    }

    private void Update()
    {
        if (tempHealth <= 0)
        {
            //if selected perks contains bloodlust
            if(Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[1]))
            {
                Player_StatusManager.Instance.playerStats.Bloodlust = true;
                Player_StatusManager.Instance.playerStats.BloodlustDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                Player_StatusManager.Instance.playerStats.BloodlustCap++;
            }

            killed = true;
            gameObject.SetActive(false);
        }

        #region roar skill
        if (Vector3.Distance(gameObject.transform.position, PlayerController.Instance.gameObject.transform.position) <= 5)
        {
            stun = PlayerController.Instance.roarActive ? stun = true : stun = false;
        }

        //freeze based on stun
        if(stun)
        {
            stun = false;
            StartCoroutine(Stunned());
        }

        #endregion
    }

    private void OnDisable()
    {
        if(killed)
        {
            
            if(ess.Name != "Machine Enemy")
            {
                Instantiate(ess.enemyDeathBody, transform.position, ess.enemyDeathBody.transform.rotation);
            }

            if (ess.Name == $"Armed Human")
            {
                GameSceneUI.armedKilled++;
            }
        }
    }

    IEnumerator Stunned()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(stunDuration);
        rb.constraints = RigidbodyConstraints.None;
    }

    IEnumerator TakeDamage(Player_BaseAbility ability)
    {
        if(!delay)
        {
            if(ability == null)
            {
                tempHealth -= Player_StatusManager.Instance.playerStats.Attack;
            }
            else if(ability.name == "Bite" || ability.name == "Dash" || ability.name == "Smash" || ability.name == "Whip" || ability.name == "Leap Smash")
            {
                tempHealth -= ability.attack;
            }


            //execute check
            if (tempHealth < ess.Health * Player_StatusManager.Instance.playerStats.ExecuteValue && Player_StatusManager.Instance.playerStats.Execute)
            {
                tempHealth = 0;
                Debug.Log("Execute");
            }

            delay = true;
        }

        StartCoroutine(damageFlashEnemy.Flash());

        yield return new WaitForSeconds(1f);
        delay = false;
    }

    #region collision related
    //melee colliders
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player Hitbox"))
        {
            if (PlayerController.Instance.attacking)
            {
                StartCoroutine(TakeDamage(null));
            }
            else if(PlayerController.Instance.smashActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[4]));
            }
            else if(PlayerController.Instance.leapsmashActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[2]));
            }

        }
        else if(collision.gameObject.CompareTag("Bite Hitbox"))
        {
            if (PlayerController.Instance.biteActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[0]));
            }
        }
    }

    //skill colliders
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Whip Hitbox"))
        {
            if (PlayerController.Instance.whipActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[5]));
            }

            
        }
        else
        {
            if (PlayerController.Instance.dashActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[1]));
            }
        }
    }
    #endregion
}
