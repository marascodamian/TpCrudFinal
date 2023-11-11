<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="TpCrudFinal.About" %>

<%@ Register Src="~/BtnVolver.ascx" TagPrefix="uc1" TagName="BtnVolver" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Integrantes:</h3>
        
        <h5>Diego Romero.</h4>
        <h5>Iván Karlen.</h4>
        <h5>Damián Marasco.</h5>
        <br />
        <uc1:BtnVolver runat="server" id="BtnVolver" />
    </main>
</asp:Content>
