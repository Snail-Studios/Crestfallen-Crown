using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM : MonoBehaviour
{
    public bool IsMinion = false;
    public bool IsEnemy = false;

    // Update is called once per frame
    void Update()
    {  if(IsMinion == false)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if (IsMinion)
        {
            Vector2 objectPos = GetComponentInParent<FollowMinion>().targetTransform.position;

            Vector2 direction = objectPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = rotation;
            transform.position = GetComponentInParent<Transform>().position;
        }
        else if (IsEnemy)
        {
            Vector2 objectPos = GameObject.FindWithTag("Player").transform.position;

            Vector2 direction = objectPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = rotation;
            transform.position = GetComponentInParent<Transform>().position;
        }
    }
}
