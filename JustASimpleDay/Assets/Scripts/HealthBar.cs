using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    //Initialise la barre de vie (remet à zéro les vie)
    public void SetMaxHealth()
    {
        Heart1.enabled = true;
        Heart2.enabled = true;
        Heart3.enabled = true;
    }

    //Enlève ou remet de la vie
    public void SetHealth(int health)
    {
        if (health == 3)
        {
            Heart3.enabled = true;
            Heart2.enabled = true;
            Heart1.enabled = true;

        }else if (health == 2)
        {
            Heart3.enabled = false;
            Heart2.enabled = true;
            Heart1.enabled = true;

        }else if(health == 1)
        {
            Heart3.enabled = false;
            Heart2.enabled = false;
            Heart1.enabled = true;

        }else if(health == 0)
        {
            Heart3.enabled = false;
            Heart2.enabled = false;
            Heart1.enabled = false;
        }
    }
}
