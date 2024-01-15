using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clickkey : MonoBehaviour
{
    public bool interactable, toggle;
    public GameObject inttext, dialogue,llave;
    public string dialogueString;
    public Text dialoguetext;
    public float dialogueTime;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (toggle == false)
            {
                inttext.SetActive(true);
                interactable = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                dialoguetext.text = dialogueString;
                dialogue.SetActive(true);
                inttext.SetActive(false);
                StartCoroutine(disableDialogue());
                interactable = false;
                
            }
        }
    }
    IEnumerator disableDialogue()
    {
		yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
		llave.SetActive(false);
    }
}
