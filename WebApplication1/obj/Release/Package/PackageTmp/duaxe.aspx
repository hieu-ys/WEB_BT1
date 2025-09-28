<%@ Page Language="C#" AutoEventWireup="true" CodeFile="duaxe.aspx.cs" Inherits="duaxe" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Game Đua Xe (.NET 2.0) - Không dùng control</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        body { font-family: Tahoma; background:#f5f5f5; }
        .card { background:white; padding:20px; width:420px; margin:40px auto;
                border-radius:8px; border:1px solid #ccc; box-shadow:0 2px 6px rgba(0,0,0,0.06); }
        h2 { text-align:center; margin:0 0 12px 0; }
        .controls { margin-top:12px; text-align:center; }
        .controls button { margin:6px; padding:8px 14px; font-size:13px; }
        .status { margin-top:12px; padding:10px; background:#eef; border:1px solid #99c;
                  font-weight:bold; text-align:center; border-radius:4px; min-height:34px; }
    </style>
</head>
<body>
    <!-- form runat=server để IsPostBack hoạt động -->
    <form id="form1" runat="server">
        <div class="card">
            <h2>Game Đua Xe</h2>

            <!-- hiển thị trạng thái (không phải server control) -->
            <div class="status"><%= statusHtml %></div>

            <div class="controls">
                <!-- dùng <button> với name="action" và value là mã hành động -->
                <button type="submit" name="action" value="accelerate">Tăng tốc (W)</button>
                <button type="submit" name="action" value="brake">Phanh (S)</button><br/>
                <button type="submit" name="action" value="left">Trái (A)</button>
                <button type="submit" name="action" value="right">Phải (D)</button><br/>
                <button type="submit" name="action" value="reset">Chơi lại</button>
            </div>
        </div>
    </form>
</body>
</html>
