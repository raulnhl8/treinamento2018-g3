﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//HPMax, HPatual, Moviment Velocity, level, dinheiro.
public class PlayerController : MonoBehaviour
{

    #region PlayerController
    //this was copyed from internet and is usefull to refering to this script from another one
    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNING! More than one inventory found!");
            return;
        }
        instance = this;

    }
    #endregion

    //Public
    [Range(1, 100)]
    public int hpMax;
    public float hpCurrent;
    [Range(1.0f, 10.0f)]
    public float movimentVelocity;
    /*public x healthBar;                           // Faz referência a barra de vida*/
    public Text totalMoney;                         // Faz referência ao texto da quantidade de dinheiro. 
    public Text totalLevel;                         // Faz referência ao texto do level

    //Private
    private int level = 1;
    private int experience = 0;                     // experiência do player
    private int requiredExperience = 1000;          // experiência requerida para passar de nível
    private int money = 100;
    private Animator animator;
    private MenuManager menuManager;

    void Start ()
    {
        hpCurrent = hpMax;
        //totalMoney.text = money.ToString();         // Dinheiro a ser mostrado no HUD
        //totalLevel.text = level.ToString();         // Level a ser mostrado no HUD
        animator = GetComponent<Animator>();
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    void Update()
    {
        if (experience > requiredExperience)        // Level up!
        {
            LevelUp();
        }
    }

    public void GainHp(float amount)
    {
        if (hpCurrent + amount <= hpMax)
            hpCurrent += amount;
        else
            hpCurrent = hpMax;
    }

    public void TakeDamage(float amount)
    {
       if (this.GetComponent<Teleport>().invencible == false)
       {
            hpCurrent -= amount;
            animator.SetTrigger("hit");
        }

        //player death
        //should trigger game over screen
        if (hpCurrent <= 0)
            menuManager.LoadGameOver();
    }

    public void TakeMoney(int amount)
    {
        money += amount;
        totalMoney.text = money.ToString();         // Mostrar a quantidade de dinheiro de acordo com a quantidade de dinheiro
    }

    void LevelUp()
    {
        level += 1;
        hpMax = 100;
        hpMax += level * 5;
        experience -= requiredExperience;
        requiredExperience += 1000;
        totalLevel.text = level.ToString();         // Mostra o level de acordo com o level
    }
}