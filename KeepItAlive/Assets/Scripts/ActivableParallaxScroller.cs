using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ActivableParallaxScroller : MonoBehaviour 
{

    #region Serialzed fields
    [Readonly]
    [SerializeField]
    private float m_scrollSpeed;
    [SerializeField]
    private bool m_contiuosMovement = false;
    #endregion

    #region Private fields
    private Vector2 m_startOffset;
    private float m_lastOffset;
    private float m_scrollOffsetByTime;
    private bool m_scroll = false;

    private Renderer m_renderer;
    #endregion

    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_startOffset = m_renderer.sharedMaterial.GetTextureOffset("_MainTex");
        m_scrollSpeed = 1 -  Mathf.Clamp01(Mathf.Abs(Camera.main.transform.position.z / transform.position.z));
        m_lastOffset = 0.0f;

    }

    void Start()
    {
    }

    void Update()
    {
        if (m_scroll || m_contiuosMovement)
        {
            m_lastOffset = Mathf.Repeat(m_scrollOffsetByTime * m_scrollSpeed, 1);
            Vector2 vOffset = new Vector2(m_lastOffset, m_startOffset.y);
            m_renderer.sharedMaterial.SetTextureOffset("_MainTex", vOffset);
            m_scrollOffsetByTime += Time.deltaTime;
        }
    }

    public void StartScroll()
    {
        m_scroll = true;
    }

    public void EndScroll()
    {
        m_scroll = false;
    }

    void OnDisable()
    {
        m_renderer.sharedMaterial.SetTextureOffset("_MainTex", m_startOffset);
    }

}
