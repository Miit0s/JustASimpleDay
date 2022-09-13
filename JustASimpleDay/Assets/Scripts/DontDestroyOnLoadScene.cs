using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Ce script permet de sauvegarder les donn� lors du changement de sc�ne

    public GameObject[] objects;

    void Awake()
    {
        //Boucle qui va lire la liste
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
