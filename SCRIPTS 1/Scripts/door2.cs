using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door2 : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle, isOpened;
    public Animator doorAnim;
    public string dialogueString;
    public Text gameObjectText;
    public GameObject faltallave;
    public float dialogueTime;
	

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") )
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(gameObjectText.text == dialogueString){
					
					toggle = !toggle;
					if (toggle==true)
					{
						doorAnim.ResetTrigger("close2");
						doorAnim.SetTrigger("open2");
						
						gameObjectText.text = "";
					}
					if (toggle==false)
					{
						doorAnim.ResetTrigger("open2");
						doorAnim.SetTrigger("close2");
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
    }
    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);
        faltallave.SetActive(false);
    }
}
