<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="teste2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            width: 107px;
        }
        .auto-style3 {
            height: 25px;
            width: 107px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <asp:HiddenField ID="IdH" runat="server" />
            <tr>
                <td class="auto-style3">Nome</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtNome" runat="server" Width="247px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Email</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtEmail" runat="server" Width="247px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Telefone</td>
                <td>
                    <asp:TextBox ID="TxtTelefone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Endereco</td>
                <td>
                    <asp:TextBox ID="TxtEndereco" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <tr>
                <td class="auto-style2">Servico</td>
                <td>
                    <asp:TextBox ID="TxtServico" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnSalvar" runat="server" OnClick="BtnSalvar_Click" Text="Salvar" />
                &nbsp;
                    <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:GridView ID="GVFornecedor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GVFornecedor_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                            <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
                            <asp:BoundField DataField="Servico" HeaderText="Servico" />
                            <asp:ButtonField ButtonType="Button" CommandName="EXCLUIR" Text="Excluir" />
                            <asp:ButtonField ButtonType="Button" CommandName="ALTERAR" Text="Alterar" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>