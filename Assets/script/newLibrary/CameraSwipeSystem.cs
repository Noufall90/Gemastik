using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSwipeSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera; 
    private float fieldOfViewMin = 10f;
    private float fieldOfViewMax = 50f;
    private float followOffsetMin = 5f;
    private float followOffsetMax = 50f;
    private float followOffsetMinY = 10f;
    private float followOffsetMaxY = 50f;
    
    private bool dragPanMoveActive;
    private Vector2 lastMousePosition;
    private float targetFieldOfView = 50f;
    private Vector3 followOffset;

    private float moveSpeed = 300f;
    private float rotateSpeed = 100f;
    private float zoomSpeed = 10f;

    private void Awake()
    {
      followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 10, 0);
    }
    private void Update()
    {
        HandleCameraMovement();
        HandleCameraZoom_FieldOfView();
        HandleCameraMovement_MoveForward();
        // HandleCameraZoom_LowerY();
    }

    private void HandleCameraMovement()
    {
        Vector3 inputDir = new Vector3(0,0,0);

        if (SwipeManager.swipeRight) inputDir.x = +1f;
        if (SwipeManager.swipeLeft) inputDir.x = -1f;
        if (SwipeManager.swipeUp) inputDir.z = +1f;
        if (SwipeManager.swipeDown) inputDir.z = -1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
    private void HandleCameraMovementEdgeScrolling()
    {
        Vector3 inputDir = new Vector3(0,0,0);
        int edgeScrollSize = 20;
          if(Input.mousePosition.x < edgeScrollSize)
          {
            inputDir.x = -1f;
          }
          if(Input.mousePosition.x > Screen.width - edgeScrollSize)
          {
            inputDir.x = +1f;
          }
          if(Input.mousePosition.y < edgeScrollSize)
          {
            inputDir.z = -1f;
          }
          if(Input.mousePosition.y > Screen.height - edgeScrollSize)
          {
            inputDir.z = +1f;
          }
        

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        
        float moveSpeed = 100f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

    }
    private void HandleCameraMovementDragPan()
    {
        Vector3 inputDir = new Vector3(0,0,0);
        if (Input.GetMouseButtonDown(1))
        {
          dragPanMoveActive = true;
          lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
          dragPanMoveActive = false;
        }

        if (dragPanMoveActive)
        {
          Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;
          
          float dragPanSpeed = 0.3f;
          inputDir.x = mouseMovementDelta.x * dragPanSpeed;
          inputDir.z = mouseMovementDelta.y * dragPanSpeed;

          lastMousePosition = Input.mousePosition;
        }

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        
        float moveSpeed = 100f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void HandleCameraZoom_FieldOfView()
    {
        float zoomAmount = SwipeManager.swipeUp ? -5f : SwipeManager.swipeDown ? 5f : 0f;
        targetFieldOfView += zoomAmount;
        targetFieldOfView = Mathf.Clamp(targetFieldOfView, 10f, 50f);
        cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, targetFieldOfView, Time.deltaTime * zoomSpeed);
    }

    private void HandleCameraMovement_MoveForward()
    {
        Vector3 zoomDir = followOffset.normalized;
        float zoomAmount = SwipeManager.swipeUp ? -3f : SwipeManager.swipeDown ? 3f : 0f;
        followOffset -= zoomDir * zoomAmount;
        followOffset = Vector3.ClampMagnitude(followOffset, 50f);
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
    }

    private void HandleCameraZoom_LowerY()
    {

      float zoomAmount = 30f;
      if (Input.mouseScrollDelta.y > 0)
      {
        followOffset.y -= zoomAmount;
      }

      if (Input.mouseScrollDelta.y < 0)
      {
        followOffset.y += zoomAmount;
      }

      followOffset.y = Mathf.Clamp( followOffset.y, followOffsetMinY, followOffsetMaxY);

      float zoomSpeed = 10f;
      cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = 
        Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
    }
}
