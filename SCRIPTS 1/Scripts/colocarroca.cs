using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colocarroca : MonoBehaviour
{
    public GameObject intText, mostrar,activarescena;
    public bool interactable, toggle, isOpened;
    public Animator doorAnim;
    public string dialogueString;
    public Text gameObjectText;
    public GameObject faltallave;
    public float dialogueTime;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && gameObjectText.text == dialogueString)
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable==true)
        {
            if (Input.GetKeyDown(KeyCode.E) && gameObjectText.text == dialogueString)
            {
                toggle = !toggle;
                if (toggle==true)
                {
                    doorAnim.SetTrigger("activar");
                    
                    gameObjectText.text = "";
					mostrar.SetActive(true);
					activarescena.SetActive(true);
                }
                
                intText.SetActive(false);
                interactable = false;
            }
            else
            {
                faltallave.SetActive(true);
                StartCoroutine(disableDialogue());
            }
        }
    }
    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);
        faltallave.SetActive(false);
    }
}
