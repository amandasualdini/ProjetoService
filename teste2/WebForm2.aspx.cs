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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = getData();
            var db = new ClienteDB();

            if (cliente.Id == 0)
            {
                if (db.Insert(cliente))
                {
                    LblMsg.Text = "Registro inserido!";
                }
                else
                    LblMsg.Text = "Erro ao inserir registro";
            }
            else
            {

                if (db.Update(cliente))
                {
                    LblMsg.Text = "Registro atualizado!";
                }
                else
                    LblMsg.Text = "Erro ao atualizar registro";
            }

            LoadGrid();
        }

        private Cliente getData()
        {
            return new Cliente()
            {
                Nome = TxtNome.Text,
                Telefone = TxtTelefone.Text,
                Endereco = TxtEndereco.Text,
                Id = string.IsNullOrEmpty(IdH.Value) ? 0 : int.Parse(IdH.Value)
            };
        }

        private void LoadGrid()
        {
            GVCliente.DataSource = new ClienteDB().GetAll();
            GVCliente.DataBind();
        }

        protected void GVCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVCliente.Rows[index];

            int id = Convert.ToInt32(row.Cells[0].Text);

            var db = new ClienteDB();

            if (e.CommandName == "EXCLUIR")
            {
                db.Delete(id);
                LoadGrid();

            }
            else if (e.CommandName == "ALTERAR")
            {
                Cliente cliente = db.SelectById(id);

                TxtNome.Text = cliente.Nome;
                TxtTelefone.Text = cliente.Telefone;
                TxtEndereco.Text = cliente.Endereco;
                IdH.Value = cliente.Id.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtTelefone.Text = "";
            TxtEndereco.Text = "";
            IdH.Value = "0";
            TxtNome.Focus();
        }
    }
}