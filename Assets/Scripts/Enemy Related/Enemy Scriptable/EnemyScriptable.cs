using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by terrence, edit by alex
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyScriptable")]

public class EnemyScriptable : ScriptableObject
{
    public GameObject enemy;
    public int spawnCount = 5;
    public float spawnDelay = 0.5f;
    [SerializeField] new string name;
    [SerializeField] int health;
    [SerializeField] int defence;
    [SerializeField] int attack;
    [SerializeField] float attackSpeed;
    [SerializeField] float speed;
    [SerializeField] float evolvePointGain;

    [SerializeField] string testResponse = "signal received, should spawn enemy now";

    public void signalTest()
    {
        Debug.Log(testResponse);
    }


    #region Properties
    public int Health
    {
        get => health;
        set => health = value;
    }

    public int Defence
    {
        get => defence;
        set => defence = value;
    }

    public int Attack
    {
        get => attack;
        set => attack = value;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    #endregion
}
