using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace teste
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Agenda agenda = getData();
            var db = new AgendaDB();

            if (agenda.Id == 0)
            {
                if (db.Insert(agenda))
                {
                    LblMsg.Text = "Registro inserido!";
                }
                else
                    LblMsg.Text = "Erro ao inserir registro";
            }
            else
            {

                if (db.Update(agenda))
                {
                    LblMsg.Text = "Registro atualizado!";
                }
                else
                    LblMsg.Text = "Erro ao atualizar registro";
            }

            LoadGrid();
        }

        private Agenda getData()
        {
            return new Agenda()
            {
                Cliente = TxtCliente.Text,
                Horario = TxtHorario.Text,
                Id = string.IsNullOrEmpty(IdH.Value) ? 0 : int.Parse(IdH.Value)
            };
        }

        private void LoadGrid()
        {
            GVAgenda.DataSource = new AgendaDB().GetAll();
            GVAgenda.DataBind();
        }

        protected void GVAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVAgenda.Rows[index];

            int id = Convert.ToInt32(row.Cells[0].Text);

            var db = new AgendaDB();

            if (e.CommandName == "EXCLUIR")
            {
                db.Delete(id);
                LoadGrid();

            }
            else if (e.CommandName == "ALTERAR")
            {
                Agenda agenda = db.SelectById(id);

                TxtCliente.Text = agenda.Cliente;
                TxtHorario.Text = agenda.Horario;
                IdH.Value = agenda.Id.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            TxtCliente.Text = "";
            TxtHorario.Text = "";
            IdH.Value = "0";
            TxtCliente.Focus();
        }
    }
}