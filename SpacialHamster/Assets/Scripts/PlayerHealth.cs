using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    int maxHealth = 2;

    [SerializeField]
    protected int health;

    public GameObject dieParticles;

    public Image lifeBar;
    public GameObject camera;
    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage()
    {
        health--;
        lifeBar.fillAmount = Mathf.InverseLerp(0, maxHealth, health);
        camera.GetComponent<Animator>().SetTrigger("Shake");
    }

    public int GetHealth()
    {
        return health;
    }
}
