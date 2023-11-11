<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="TpCrudFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12 d-flex align-items-center justify-content-between">
            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-m btn-success" Text="Nuevo" />
            <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True">Selecciona un estado</asp:ListItem>
                <asp:ListItem Value="1">Activo</asp:ListItem>
                <asp:ListItem Value="0">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
        <br />
    <div class =" row">
        <div class="col-12">
            <asp:GridView ID="GvEmpleados" runat="server" CSSClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="Email" HeaderText="Email"/>
                    <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento"/>
                    <asp:BoundField DataField="Puesto" HeaderText="Puesto"/>
                    <asp:BoundField DataField="Sueldo" HeaderText="Sueldo"/>
                    <asp:BoundField DataField="FechaContrato" HeaderText="Fecha de Ingreso" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("Activo")) ? "Activo" : "Inactivo" %>
                        </ItemTemplate>
                    </asp:TemplateField>
               
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("IdEmpleado")%>'
                                OnClick="Editar_Click" CssClass="btn btn-sm btn-primary">Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("IdEmpleado")%>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm ('Desea eliminar este empleado?')">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
