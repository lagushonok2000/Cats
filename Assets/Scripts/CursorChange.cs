using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
    [SerializeField] private Animator _cursorAnimator;
    [SerializeField] private RectTransform _cursorImage;
    [SerializeField] private Canvas _canvas;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(), Input.mousePosition, _camera, out Vector2 canvasPos);
        _cursorImage.anchoredPosition = canvasPos;

        if (Input.GetMouseButtonDown(0))
        {
            _cursorAnimator.SetTrigger("click");
        }
    }
}
