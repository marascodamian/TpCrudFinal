<%@ Page Title="Index"  Language="C#" MasterPageFile ="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TpCrudFinal.Index" %>

<%@ Register Src="~/BtnVolver.ascx" TagPrefix="uc1" TagName="BtnVolver" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" class="fs-4 fw-bold"></asp:Label>
    <div class="mb-3">
        <label class="form-label">
        <br />
        Nombre</label>&nbsp;<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="form-label"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <label class="form-label">
        Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="El Email es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email es inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <label class="form-label">Fecha de Nacimiento</label>
        <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaNac" ErrorMessage="La fecha de nacimiento es requerida" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="mb-3">
        <label class="form-label">Departamento</label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartamento" ErrorMessage="El departamento es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label class="form-label">Puesto</label>
        <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPuesto" ErrorMessage="El puesto es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <label class="form-label">
        Sueldo</label>
        <asp:TextBox ID="txtSueldo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSueldo" ErrorMessage="El sueldo es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSueldo" ErrorMessage="El sueldo debe ser como máximo de 1000" ForeColor="Red" MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <br />
        <label class="form-label">
        Fecha de Contrato</label>
        <asp:TextBox ID="txtFechaContrato" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFechaContrato" ErrorMessage="La fecha de contrato es requerida" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <label class="form-label">
        Activo</label>
        <asp:RadioButtonList ID="RblEstado" runat="server" Width="128px">
            <asp:ListItem Value="1" Selected="True">Activo</asp:ListItem>
            <asp:ListItem Value="0">Inactivo</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="RblEstado" ErrorMessage="El estado del empelado es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-bg btn-primary" OnClick="btnSubmit_Click"/>
    <uc1:BtnVolver runat="server" id="BtnVolver" />
    <script type="text/javascript">
        document.onkeydown = function (e) {
            if (e.key === 'Enter') {
                e.preventDefault();
                document.getElementById('<%= btnSubmit.ClientID %>').click();
                return false;
            }
        };
    </script>


</asp:Content>
