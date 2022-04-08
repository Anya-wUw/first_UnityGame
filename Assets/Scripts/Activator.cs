using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;
    public Activator button;
    public Material normal;
    public Material transpanent;
    //чтобы блок не засревал в непрозрачной ловушке
    public bool canPush;

    private void OnTriggerEnter(Collider other)
    {
        if (canPush)
        {
            //если кнопки коснулся куб или розовый(главный)куб
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                //материал блоков
                foreach (GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }
                foreach (GameObject second in secondGroup)
                {
                    //материал блоков + можно ходить сквозь них isTrigger = true;
                    second.GetComponent<Renderer>().material = transpanent;
                    second.GetComponent<Collider>().isTrigger = true;
                }
                //материал кнопки
                GetComponent<Renderer>().material = transpanent;
                button.GetComponent<Renderer>().material = normal;
                button.canPush = true;
            }
        }
        
    }

}
