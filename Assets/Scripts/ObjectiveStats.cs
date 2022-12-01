using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveStats : MonoBehaviour
{
    public bool isDestroyed = false;
    [SerializeField] int objectiveHealth;
    [SerializeField] float delayTimer;
    [SerializeField] string objectiveName;
    [SerializeField] GameObject destroyedObj;
    DamageFlash damageFlash;
    ParticleSystem particleSystem;

    bool delay = false;
    int tempHealth = 0;
    bool smoking = false;

    private void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        damageFlash = GetComponent<DamageFlash>();
        particleSystem.Stop();
    }

    private void Start()
    {
        tempHealth = objectiveHealth;
    }

    private void Update()
    {
        if((tempHealth <= objectiveHealth / 2) && smoking == false)
        {
            smoking = true;
            particleSystem.Play();
        }

        if (tempHealth <= 0)
        {
            isDestroyed = true;
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(isDestroyed)
        {
            switch(objectiveName)
            {
                case "Radio Tower":
                    GameSceneUI.radioTowerDestroyed = true;
                    break;

                case "Chemist Lab":
                    GameSceneUI.chemistLabDestroyed += 1;
                    break;

                case "Enemy Camp":
                    GameSceneUI.enemyCampDestroyed = true;
                    break;
                default:
                    break;
            }

            destroyedObj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Hitbox"))
        {
            if (PlayerController.Instance.attacking)
            {
                StartCoroutine(TakeDamage(null));
            }
            else if (PlayerController.Instance.smashActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[4]));
            }
            else if (PlayerController.Instance.leapsmashActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[2]));
            }

        }
        else if (other.gameObject.CompareTag("Bite Hitbox"))
        {
            if (PlayerController.Instance.biteActive)
            {
                StartCoroutine(TakeDamage(Player_AbilityHolder.Instance.totalSkillList[0]));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Whip Hitbox"))
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

    IEnumerator TakeDamage(Player_BaseAbility ability)
    {
        if (!delay)
        {
            if (ability == null)
            {
                tempHealth -= Player_StatusManager.Instance.playerStats.Attack;
            }
            else if (ability.name == "Bite" || ability.name == "Dash" || ability.name == "Smash" || ability.name == "Whip" || ability.name == "Leap Smash")
            {
                tempHealth -= ability.attack;
            }

            delay = true;
        }

        StartCoroutine(damageFlash.Flash());

        yield return new WaitForSeconds(delayTimer);
        delay = false;
    }


}
