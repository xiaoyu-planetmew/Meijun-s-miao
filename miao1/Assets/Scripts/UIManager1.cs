using UnityEngine;
/*
public class UIManager1 : MonoBehaviour
{
    public InputReader input;

    public Texture2D cursorNormal;
    public Texture2D cursorobserve;
    public Texture2D cursorThrow;
    public int cursorType = 0;

    private static UIManager1 instace;
    public static UIManager1 Instance()
    {
        return instace;
    }

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    public void EnableMouseInput()
    {
        input.EnableUI();
        input.EnableGameplay();
    }

    public void DisableMouseInput()
    {
        input.DisableAllInput();
    }

    public void DisableUI()
    {
        input.DisableUI();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        input.mouseClick += OnMouseClickInput;
        input.mouseMove += OnMouseMoveInput;
    }

    private void OnMouseMoveInput(Vector2 postion)
    {
        if(Camera.main == null)
        {
            return;
        }

        if(cursorType == 2)
        {
            return;
        }

        var world_pos = Camera.main.ScreenToWorldPoint(new Vector3(postion.x, postion.y, 0));
        RaycastHit2D hit = Physics2D.Raycast(world_pos, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("EventObject"))
        {
            ShowObserveCursor();
        }
        else
        {
            ShowNormalCursor();
        }
    }

    public void ShowThrowCursor()
    {
        cursorType = 2;
        Cursor.SetCursor(cursorThrow, new Vector2(25, 25), CursorMode.Auto);
    }

    public void ShowNormalCursor()
    {
        cursorType = 0;
        Cursor.SetCursor(cursorNormal, new Vector2(25, 25), CursorMode.Auto);
    }

    public void ShowObserveCursor()
    {
        cursorType = 1;
        Cursor.SetCursor(cursorobserve, new Vector2(25, 25), CursorMode.Auto);
    }

    private void OnMouseClickInput(Vector2 postion)
    {
        var world_pos = Camera.main.ScreenToWorldPoint(new Vector3(postion.x, postion.y, 0));
        RaycastHit2D hit = Physics2D.Raycast(world_pos, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("EventObject"))
        {
            var obj = hit.collider.gameObject;
            var eventObj = obj.GetComponent<BaseEventObject>();
            eventObj.Execute();
            DisableUI();
        }
    }
}
*/