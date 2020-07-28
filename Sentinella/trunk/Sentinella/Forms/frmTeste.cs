using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmTeste : Form {

        Uteis.Conexao con = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        string sql = "";
        long retorno = 0;

        public frmTeste() {
            InitializeComponent();
        }


        private void btnTesteConexao_Click(object sender, EventArgs e) {

            con.testaConexao();
        }

        private void btnEncypt_Click(object sender, EventArgs e) {
            txtSaida.Text = hlp.Encrypt(txtEntrada.Text);
        }

        private void btnDecriptar_Click(object sender, EventArgs e) {
            txtSaida.Text = hlp.Decrypt(txtEntrada.Text);
        }

        private void button1_Click(object sender, EventArgs e) {

            DataTable dt_filtro = new DataTable();
            dt_filtro = con.retornaDataTable("Select * from w_tamnun_filtros");

            foreach (DataRow item in dt_filtro.Rows) {

                sql = "Update a set ";
                sql += "a.filtro = '" + item["valorBusca"].ToString() + "' ";
                sql += "from w_tamnun_base a ";
                sql += "where a.caminho like '%" + item["valorBusca"].ToString() + "%' and a.categoria = '" + item["categoria"].ToString() + "' and a.fonte = '" + item["fonte"].ToString() + "'";
                con.executaQuery(sql, ref retorno);

            }

            MessageBox.Show("Acabou!");



        }

        private void button1_Click_1(object sender, EventArgs e) {


            sql = "select c.cod_trilha, c.Id_Conteudo, c.des_trilha, c.des_nome, ";
            sql += "replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, ";
            sql += "count(c.des_conteudo) as total_cursos, ";
            sql += "sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, ";
            sql += "sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, ";
            sql += "sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, "; //calculo de percentual concluído
            sql += "max(dt_fim) as data_conclusao_ultimo_curso_trilha, "; //data do último curso da trilha feito, usar para validar se trilha concluída dentro da vigencia atual
            sql += "(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, "; //inicio do henriquecimento
            sql += "(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, ";
            sql += "(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, ";
            sql += "(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, ";
            sql += "(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, ";
            sql += "(select top 1 data_de_admissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_admissao, ";
            sql += "(select top 1 data_demissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_demissao, ";
            sql += "(select top 1 data_inicio_ferias from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_ferias_inicio, ";
            sql += "(select top 1 data_fim_ferias from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_ferias_fim, ";
            sql += "(select top 1 data_inicio_afastamento from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_afastamento_inicio, ";
            sql += "(select top 1 data_fim_afastamento from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_afastamento_fim, "; //fim do henriquecimento
            sql += "GETDATE() as data_importacao, "; //data-hora única de importação
            sql += Constantes.id_BD_logadoFerramenta + " as id_importacao "; //setando o id do importador
            sql += "from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c ";
            sql += "inner join w_trilhasTreinamentos_cursos f on c.Id_Conteudo = f.cod_curso "; //Garantindo que sejam apenas os cursos SGI                
            sql += "inner join w_trilhasTreinamentos_trilhas t on c.cod_trilha = t.cod_trilha "; //Garantindo que sejam apenas os Trilhas monitoradas 
            sql += "where c.des_status = 'Ativo' ";
            sql += "group by c.cod_trilha, c.Id_Conteudo, c.des_trilha, c.des_nome, c.cod_cpf ";

            dataGridView1.DataSource = con.retornaDataTable(sql);

            MessageBox.Show("The End!");

        }
    }
}
