using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace teste2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = getData();
            var db = new FornecedorDB();

            if (fornecedor.Id == 0)
            {
                if (db.Insert(fornecedor))
                {
                    LblMsg.Text = "Registro inserido!";
                }
                else
                    LblMsg.Text = "Erro ao inserir registro";
            }
            else
            {

                if (db.Update(fornecedor))
                {
                    LblMsg.Text = "Registro atualizado!";
                }
                else
                    LblMsg.Text = "Erro ao atualizar registro";
            }

            LoadGrid();
        }

        private Fornecedor getData()
        {
            return new Fornecedor()
            {
                Nome = TxtNome.Text,
                Email = TxtEmail.Text,
                Telefone = TxtTelefone.Text,
                Endereco = TxtEndereco.Text,
                Servico = TxtServico.Text,
                Id = string.IsNullOrEmpty(IdH.Value) ? 0 : int.Parse(IdH.Value)
            };
        }

        private void LoadGrid()
        {
            GVFornecedor.DataSource = new FornecedorDB().GetAll();
            GVFornecedor.DataBind();
        }

        protected void GVFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVFornecedor.Rows[index];

            int id = Convert.ToInt32(row.Cells[0].Text);

            var db = new FornecedorDB();

            if (e.CommandName == "EXCLUIR")
            {
                db.Delete(id);
                LoadGrid();

            }
            else if (e.CommandName == "ALTERAR")
            {
                Fornecedor cliente = db.SelectById(id);

                TxtNome.Text = cliente.Nome;
                TxtEmail.Text = cliente.Email;
                TxtTelefone.Text = cliente.Telefone;
                TxtEndereco.Text = cliente.Endereco;
                TxtServico.Text = cliente.Servico;
                IdH.Value = cliente.Id.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtEmail.Text = "";
            TxtTelefone.Text = "";
            TxtEndereco.Text = "";
            TxtServico.Text = "";
            IdH.Value = "0";
            TxtNome.Focus();
        }
    }
}