using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected CombatText CombatTextPrefab;

    public float regenRate = 5f;// toc do hoi mau(so giay giua moi lan hoi mau)
    public float regenAmount = 10f;// so luong mau hoi moi lan
    private bool isRegenHealth;// kiem tra xem hoi mau dang thuc hien ko
    public float maxHp = 100;
    public float hp;
    private string currentAnimName;


    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }
  
 
    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100, transform);
    }

    public virtual void OnDespawn()
    {

    }
    protected virtual void OnDeath()
    {
        ChangeAnim("die");
        Invoke(nameof(OnDespawn), 2f);
    }

    protected void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;

            if (IsDead)
            {
                hp = 0;
                OnDeath();
            }
            else
            {
                // Kiểm tra xem máu có âm không để bắt đầu/quay lại quá trình hồi máu
                if (hp <= 100 && !isRegenHealth)
                {
                    StartRegenHealth();
                }
                else if (hp > 100 && isRegenHealth)
                {
                    StopRegenHealth();
                }
            }
            healthBar.SetNewHp(hp);
            Instantiate(CombatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }
    private void StartRegenHealth()
    {
        isRegenHealth = true;
        StartCoroutine(RegenHealth());
    }

    private IEnumerator RegenHealth()
    {
        while (isRegenHealth)
        {
            yield return new WaitForSeconds(regenRate);
            Heal(regenAmount);
        }
    }

    public void StopRegenHealth()
    {
        isRegenHealth = false;
    }
    public void Heal(float amount)
    {
        hp += amount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        healthBar.SetNewHp(hp);
    }
}
