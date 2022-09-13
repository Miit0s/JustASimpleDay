using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    //Ce script permet de sauvegarder les donné lors du changement de scène

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
