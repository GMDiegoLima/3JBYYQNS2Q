using UnityEngine;
using System.Collections;

public class TouchControll : MonoBehaviour {

    public enum SWIPE_DIRECTION
    {
        SD_UP
    , SD_DOWN
    , SD_LEFT
    , SD_RIGHT
    , SD_UP_RIGHT
    , SD_DOWN_RIGHT
    , SD_DOWN_LEFT
    , SD_UP_LEFT
    , SD_TOUCH
    }

    public enum SWIPE_TYPE
    {
        ST_8_DIRECTION
        , ST_4_DIRECTION
    }

    public delegate void Callback(SWIPE_DIRECTION iDirection);
    private Callback m_cCallback;
    private Callback m_cCurrentCallback;

    public bool m_bActiveVisualFeedback = true;
    public bool m_bLeftClick = true;
    public bool m_bInstantSwipe = false;
    public SWIPE_TYPE m_stSwipeType = SWIPE_TYPE.ST_8_DIRECTION;

    [Range(0.0f, 10.0f)]
    public float SwipeDistance = 0.2f;

    private bool m_bSwipePressed = false;
    private Vector3 m_vStarSwipePos;
    private Vector3 m_vEndSwipePos;
    private Vector3 m_vSwipeDirection;
    private LineRenderer m_lLineRenderer;
    private int m_iNumberOfPoints = 0;
    private int m_iInputMouse = 0;
    private float m_fHeightSensibility = 0.2f;
    private float m_fWidthSensibility = 0.2f;

   
    public void SetMethodToCall(Callback iCallback)
    {
        if (m_cCurrentCallback != null)
        {
            m_cCallback -= m_cCurrentCallback;
        }

        m_cCallback += iCallback;
        m_cCurrentCallback = m_cCallback;

        m_lLineRenderer = this.GetComponent<LineRenderer>();
    }

    private void UpdateDebugLineRenderer()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_iNumberOfPoints++;
            m_lLineRenderer.SetVertexCount(m_iNumberOfPoints);

            Vector3 mousePos = new Vector3(0.0f, 0.0f, 0.0f);
            mousePos = Input.mousePosition;
            mousePos.z = 1.0f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            m_lLineRenderer.SetPosition(m_iNumberOfPoints - 1, worldPos);
        }
        else {
            m_iNumberOfPoints = 0;
            m_lLineRenderer.SetVertexCount(0);
        }
    }

    private void CheckAndComputeDirection4Direction()
    {

        if (m_vSwipeDirection.normalized.x > 0.0f
            && m_vSwipeDirection.normalized.x > m_fWidthSensibility)
        {

            if (m_vSwipeDirection.x > 0.0f)
            {
                if (m_vSwipeDirection.normalized.y >= 0.5f
                    && m_vSwipeDirection.normalized.y > m_fHeightSensibility)
                {
                    m_cCallback(SWIPE_DIRECTION.SD_UP);
                }
                else if (m_vSwipeDirection.normalized.y <= -0.5f
                    && m_vSwipeDirection.normalized.y < -m_fHeightSensibility)
                {
                    m_cCallback(SWIPE_DIRECTION.SD_DOWN);
                }
                else {
                    m_cCallback(SWIPE_DIRECTION.SD_RIGHT);
                }
            }
        }
        else if (m_vSwipeDirection.normalized.x < 0.0f
            && m_vSwipeDirection.normalized.x < -m_fWidthSensibility)
        {

            if (m_vSwipeDirection.normalized.y >= 0.5f
                && m_vSwipeDirection.normalized.y > m_fHeightSensibility)
            {
                m_cCallback(SWIPE_DIRECTION.SD_UP);
            }
            else if (m_vSwipeDirection.normalized.y <= -0.5f
                && m_vSwipeDirection.normalized.y < -m_fHeightSensibility)
            {
                m_cCallback(SWIPE_DIRECTION.SD_DOWN);
            }
            else {
                m_cCallback(SWIPE_DIRECTION.SD_LEFT);
            }
        }
        else if (m_vSwipeDirection.normalized.y >= 0.0f)
        {
            m_cCallback(SWIPE_DIRECTION.SD_UP);
        }
        else {
            m_cCallback(SWIPE_DIRECTION.SD_DOWN);
        }
    }

    private void CheckAndComputeDirection()
    {

        if (m_vSwipeDirection.normalized.x > 0.0f
            && m_vSwipeDirection.normalized.x > m_fWidthSensibility)
        {

            if (m_vSwipeDirection.x > 0.0f)
            {
                if (m_vSwipeDirection.normalized.y > 0.0f
                    && m_vSwipeDirection.normalized.y > m_fHeightSensibility)
                {
                    m_cCallback(SWIPE_DIRECTION.SD_UP_RIGHT);
                }
                else if (m_vSwipeDirection.normalized.y < 0.0f
                    && m_vSwipeDirection.normalized.y < -m_fHeightSensibility)
                {
                    m_cCallback(SWIPE_DIRECTION.SD_DOWN_RIGHT);
                }
                else {
                    m_cCallback(SWIPE_DIRECTION.SD_RIGHT);
                }
            }
        }
        else if (m_vSwipeDirection.normalized.x < 0.0f
            && m_vSwipeDirection.normalized.x < -m_fWidthSensibility)
        {

            if (m_vSwipeDirection.normalized.y > 0.0f
                && m_vSwipeDirection.normalized.y > m_fHeightSensibility)
            {
                m_cCallback(SWIPE_DIRECTION.SD_UP_LEFT);
            }
            else if (m_vSwipeDirection.normalized.y < 0.0f
                && m_vSwipeDirection.normalized.y < -m_fHeightSensibility)
            {
                m_cCallback(SWIPE_DIRECTION.SD_DOWN_LEFT);
            }
            else {
                m_cCallback(SWIPE_DIRECTION.SD_LEFT);
            }
        }
        else {

            if (m_vSwipeDirection.normalized.y >= 0.0f)
            {
                m_cCallback(SWIPE_DIRECTION.SD_UP);
            }
            else {
                m_cCallback(SWIPE_DIRECTION.SD_DOWN);
            }
        }
    }

    private void Update()
    {

        if (m_bLeftClick)
        {
            m_iInputMouse = 0;
        }
        else {
            m_iInputMouse = 1;
        }

        if (m_bActiveVisualFeedback)
        {
            UpdateDebugLineRenderer();
        }

        if (!m_bSwipePressed && Input.GetMouseButtonDown(m_iInputMouse))
        {
            m_vStarSwipePos = Input.mousePosition;
            m_bSwipePressed = true;
        }

        if (m_bSwipePressed)
        {

            if (!m_bInstantSwipe && Input.GetMouseButtonUp(m_iInputMouse))
            {
                

                m_vEndSwipePos = Input.mousePosition;
                m_bSwipePressed = false;

                m_vSwipeDirection = m_vEndSwipePos - m_vStarSwipePos;

                if (m_vSwipeDirection.sqrMagnitude < SwipeDistance * 1000.0f)
                {
                    m_cCallback(SWIPE_DIRECTION.SD_TOUCH);
                    return;
                }
                else {
                    if (m_stSwipeType == SWIPE_TYPE.ST_4_DIRECTION)
                    {
                        CheckAndComputeDirection4Direction();
                    }
                    else {
                        CheckAndComputeDirection();
                    }
                }
            }
            else if (m_bInstantSwipe)
            {
               

                m_vEndSwipePos = Input.mousePosition;
                m_vSwipeDirection = m_vEndSwipePos - m_vStarSwipePos;

                if (m_vSwipeDirection.sqrMagnitude > 1.0f)
                {
                    m_bSwipePressed = false;

                    if (m_stSwipeType == SWIPE_TYPE.ST_4_DIRECTION)
                    {
                        CheckAndComputeDirection4Direction();
                    }
                    else {
                        CheckAndComputeDirection();
                    }
                }
            }
        }
    }
}
