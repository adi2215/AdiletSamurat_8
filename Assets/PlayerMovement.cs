using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float sliderAmount = 100.0f;
    [SerializeField] private Slider sliderControl;
    [SerializeField] private Slider sliderHP;
    [SerializeField] private Slider HealthBar;
    [SerializeField] private Text hpText;
    private float valueControl;
    private bool ControlChecking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        valueControl = sliderControl.value;
    }

    void Update()
    {
        HealthBar.value = sliderHP.value;
        float localHp = HealthBar.value * sliderAmount;
        hpText.text = localHp.ToString("0.0") + "%";
        valueControl = sliderControl.value;
        anim.SetFloat("InputMagnitude", valueControl);
    }

    public void IdleSystem()
    {
        anim.SetFloat("InputMagnitude", 0);
        sliderControl.value = 0;
    }

    public void WalkSystem()
    {
        anim.SetFloat("InputMagnitude", 1);
        sliderControl.value = 1;
    }

    public void JumpSystem()
    {
        anim.SetTrigger("Jump");
    }

    public void AttackSystem()
    {
        anim.SetTrigger("Attack");
    }
}
