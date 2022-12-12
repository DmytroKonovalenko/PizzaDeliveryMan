using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collect : MonoBehaviour
{
    public Transform InventoryHolder;
    Stack<Transform> collectedTrans = new Stack<Transform>();
    bool isADropArea;
    Vector3 DropPos;
    [SerializeField] private GameObject winPanel;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drop"))
        {
            isADropArea = true;
            DropPos = other.transform.position;
            
            StartCoroutine(DropSlow(.5f));

        }
        else
        {
            Pizza localResources = null;
            other.TryGetComponent(out localResources);

            if (other.CompareTag("pizza") && localResources && localResources.isAlreadyCollected == false)
            {
                
                other.transform.SetParent(InventoryHolder);
                other.transform.localPosition = new Vector3(0, collectedTrans.Count * .25f, .1f);
                other.transform.localRotation = Quaternion.identity;
                collectedTrans.Push(other.transform);
                localResources.isAlreadyCollected = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drop"))
        {
            isADropArea = false;
        }

    }

    IEnumerator DropSlow(float _delay = 0)
    {
        while (isADropArea)
        {
            yield return new WaitForSeconds(_delay);
            if (collectedTrans.Count > 0)
            {
                Transform newResources = collectedTrans.Pop();
                newResources.parent = null;
                newResources.DOJump(DropPos, 2, 1, .2f).OnComplete(() => newResources.DOPunchScale(new Vector3(.2f, .2f, .2f), .1f).OnComplete(() => winPanel.SetActive(true)));
                

            }
        }
    }
}