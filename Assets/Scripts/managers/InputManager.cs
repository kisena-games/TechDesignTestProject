using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        ListenMouse();
    }

    private void ListenMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hitInfo = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
