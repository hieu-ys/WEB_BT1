using System;

/// <summary>
/// Code-behind cho duaxe.aspx
/// Không dùng control server để tránh lỗi designer / lblStatus không tồn tại.
/// </summary>
public partial class duaxe : System.Web.UI.Page
{
    // biến để chèn trạng thái vào HTML: <%= statusHtml %>
    protected string statusHtml = "";

    // Sử dụng lớp game có tên khác (DuaxeGame) để tránh xung đột với bất kỳ DLL nào
    private DuaxeGame Game
    {
        get
        {
            object o = Session["DuaxeGame"];
            if (o == null)
            {
                DuaxeGame g = new DuaxeGame();
                Session["DuaxeGame"] = g;
                return g;
            }
            return (DuaxeGame)o;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Nếu có POST thì xử lý action; IsPostBack vẫn hoạt động nhờ form runat=server
        if (IsPostBack)
        {
            string action = Request.Form["action"];
            if (!String.IsNullOrEmpty(action))
            {
                if (action == "accelerate")
                {
                    if (!Game.IsGameOver) Game.Accelerate();
                }
                else if (action == "brake")
                {
                    if (!Game.IsGameOver) Game.Brake();
                }
                else if (action == "left")
                {
                    if (!Game.IsGameOver) Game.MoveLeft();
                }
                else if (action == "right")
                {
                    if (!Game.IsGameOver) Game.MoveRight();
                }
                else if (action == "reset")
                {
                    Game.Reset();
                }
            }
        }

        // Cập nhật statusHtml để hiển thị
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        // Nếu game over, show thêm lý do (nếu có)
        string s = Game.GetStatus();
        if (Game.IsGameOver)
        {
            statusHtml = s + " <br/><em>Nhấn 'Chơi lại' để bắt đầu lại.</em>";
        }
        else
        {
            statusHtml = s;
        }
    }
}

/// <summary>
/// Lớp game đơn giản đặt tên DuaxeGame để tránh conflict với các DLL cùng tên.
/// Thiết kế tương thích .NET 2.0 (không auto-property, không LINQ).
/// </summary>
public class DuaxeGame
{
    private int speed;
    private int position;
    private bool gameOver;
    private string reason;

    public bool IsGameOver { get { return gameOver; } }

    public DuaxeGame()
    {
        Reset();
    }

    public void Accelerate()
    {
        speed += 10;
        if (speed > 200)
        {
            EndGame("Xe hỏng vì quá tốc độ!");
        }
    }

    public void Brake()
    {
        speed -= 10;
        if (speed < 0) speed = 0;
    }

    public void MoveLeft()
    {
        position -= 1;
        if (position < -5) EndGame("Xe lao khỏi đường bên trái!");
    }

    public void MoveRight()
    {
        position += 1;
        if (position > 5) EndGame("Xe lao khỏi đường bên phải!");
    }

    public void Reset()
    {
        speed = 0;
        position = 0;
        gameOver = false;
        reason = "";
    }

    public string GetStatus()
    {
        if (gameOver)
        {
            return "GAME OVER! " + reason;
        }
        return "Tốc độ: " + speed + " km/h | Vị trí: " + position;
    }

    private void EndGame(string r)
    {
        gameOver = true;
        reason = r;
    }
}
