using UnityEngine;

namespace Player
{
    public class HighLight : MonoBehaviour
    {
        private Renderer _objectRenderer;
        private Color _originalColor;
        private Color _targetColor;

        private void Start()
        {
            _objectRenderer = GetComponent<Renderer>();
            _originalColor = new Color(_objectRenderer.material.color.r, _objectRenderer.material.color.g, _objectRenderer.material.color.b, 0f);
            _objectRenderer.material.color = _originalColor;
            
            _targetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 1f);
        }
        private void OnMouseEnter()
        {
            _objectRenderer.material.color = _targetColor;
        }
        private void OnMouseExit()
        {
            _objectRenderer.material.color = _originalColor;
        }
    }
}
