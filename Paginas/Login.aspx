<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpCrudFinal.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <style>
        body {
            text-align: center;
            font-family: Arial, sans-serif;
        }

        #formContainer {
            margin: 50px auto;
            max-width: 400px;
            text-align: center;
        }

        #LogoImage {
            display: block;
            margin: 0 auto;
        }

        #loginTitle {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
            text-align: center; /* Alinea el texto al centro */
        }

        .formContainer {
            width: 200px;
            margin: 0 auto;
            text-align: left;
        }

        .formLabel, .formInput, #btnIngresar {
            width: 100%;
            margin-top: 10px;
            box-sizing: border-box;
            display: block;
            text-align: left;
        }

        .formInput {
            width: 100%;
            padding: 8px;
        }

        #btnIngresar {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        #btnIngresar:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer">
            <asp:Image ID="LogoImage" runat="server" Height="216px" Width="250px" ImageUrl="~/Imagenes/logo.gif" />

            <asp:Label ID="loginTitle" runat="server" Text="LOGIN" CssClass="formLabel"></asp:Label>

            <div class="formContainer">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="formLabel"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="formInput"></asp:TextBox>

                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" CssClass="formLabel"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="formInput"></asp:TextBox>

                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
