using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
#pragma warning disable IDE1006 // Estilos de Nomenclatura
    class relatorios
#pragma warning restore IDE1006 // Estilos de Nomenclatura
    {
        #region VARIAVEIS 
        string sql = "";
        //long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        DataTable dt = new DataTable();
        DataTable dtConsolidado = new DataTable();
        #endregion

        #region CONSULTAS

        public bool baseGeral(DateTime dataInicial, DateTime dataFinal, ListView lst, int protocolo = 0) {
            {
                try {
                    sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                    sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + ", ";
                    sql += "@id int = " + objCon.valorSql(protocolo) + " ";

                    sql += "select ";
                    sql += "b.id as PROTOCOLO, ";
                    sql += "b.cpf AS CPF, ";
                    sql += "b.data_Registro AS DATA_REGISTRO, ";
                    sql += "f.descricao as FILA, ";
                    sql += "case ";
                    sql += "when b.status_id = 0 then ";
                    sql += "'ABERTO' ";
                    sql += "when b.status_id = 1 then ";
                    sql += "'TRABALHANDO' ";
                    sql += "when b.status_id = 3 then ";
                    sql += "'FINALIZADO' ";
                    sql += "END AS STATUS, ";
                    sql += "uCat.nome as ANALISTA_CAT, ";
                    sql += "fin.descricao as FINALIZACAO, ";
                    sql += "sFin.descricao as SUBFINALIZACAO, ";
                    sql += "b.observacao as OBSERVACAO, ";
                    sql += "b.data_Trabalho as DATA_TRABALHO, ";
                    sql += "b.hora_Inicial as HORA_INICIAL, ";
                    sql += "b.hora_Final as HORA_FINAL, ";
                    sql += "b.tempo_Trabalho_Segundos as TEMPO_TRABALHO_SEGUNDOS, ";
                    sql += "b.valor_Envolvido as VALOR_ENVOLVIDO, ";
                    sql += "iif(b.sla_cumprido = 1,'SIM','NÃO') as SLA_CUMPRIDO, ";
                    sql += "iif(b.gerado_fup = 1,'SIM','NÃO') as GERADO_FUP, ";
                    sql += "b.id_Historico as PROTOCOLO_HISTORICO, ";
                    sql += "b.data_Abertura as DATA_ABERTURA, ";
                    sql += "uImp.nome as ANALISTA_IMP ";
                    sql += "from w_base b ";
                    sql += "inner join w_sysFilas f on b.fila_id = f.id ";
                    sql += "left join w_sysUsuarios uCat on b.idCat = uCat.id ";
                    sql += "left join w_sysFinalizacoes fin on b.finalizacao_id = fin.id ";
                    sql += "left join w_sysSubFinalizacoes sFin on b.subFinalizacao_id = sFin.id  ";
                    sql += "left join w_sysUsuarios uImp on b.id_Abertura = uImp.idRede ";
                    sql += "where 1 = 1 ";
                    sql += "and format(b.data_Abertura,'d') between @dataInicial and @dataFinal ";
                    if (protocolo > 0) {
                        sql += "and b.id = @id ";
                    }
                    dt = objCon.retornaDataTable(sql);
                    return carregarListView(lst, dt, true);
                }
                catch (Exception ex) {
                    log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                    return false;
                }
            }
        }
        public bool targetSlaLaudos(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select u.nome as Analista, u.idRede AS ID_REDE, count(b.id) as VOL_TRABALHADO, ";
                sql += "sum(iif(b.sla_cumprido = 1,1,0)) as SLA_CUMPRIDO, ";
                sql += "sum(iif(b.sla_cumprido = 0,1,0)) as SLA_NAO_CUMPRIDO, ";
                sql += "format(sum(iif(b.sla_cumprido = 1,1,0))/Convert(decimal(7,2),count(b.id)),'P') as [TARGET 90%] ";
                sql += "from w_base b ";
                sql += "inner join w_sysUsuarios u on b.idCat = u.id ";
                sql += "where 1=1 ";
                sql += "and b.status_id = 3 ";
                sql += "and b.data_Trabalho between @dataInicial and @dataFinal ";
                sql += "group by u.nome, u.idRede ";
                sql += "order by u.nome asc ";
                dt = objCon.retornaDataTable(sql);
                return carregarListView(lst, dt, true);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        public bool devolutivaOuvidoria(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select ";
                sql += "fila.descricao as FILA, ";
                sql += "b.id as PROTOCOLO, ";
                sql += "format(br.data_Registro,'yyyy-MM-dd') as DATA_INCIDENTE, ";
                sql += "format(br.data_Abertura,'yyyy-MM-dd') as DATA_ABERTURA, ";
                sql += "format(br.data_Trabalho,'yyyy-MM-dd') as DATA_TRABALHO, ";
                sql += "iif(br.sla_cumprido = 1, 'SIM','NÃO') as SLA_CUMPRIDO, ";
                sql += "case ";
                sql += "when br.status_id = 0 then ";
                sql += "'ABERTO' ";
                sql += "when br.status_id = 1 then ";
                sql += "'TRABALHANDO' ";
                sql += "when br.status_id = 3 then ";
                sql += "'FINALIZADO' ";
                sql += "END AS STATUS, ";
                sql += "f.descricao as FINALIZACAO, ";
                sql += "sf.descricao as SUBFINALIZACAO, ";
                sql += "br.observacao ";
                sql += "from w_base b ";
                sql += "inner join w_baseRetornoOuvidoria br on b.id = br.id_base_principal ";
                sql += "left join w_sysFilas fila on b.fila_id = fila.id ";
                sql += "left join w_sysFinalizacoes f on br.finalizacao_id = f.id ";
                sql += "left join w_sysSubFinalizacoes sf on br.subFinalizacao_id = sf.id ";
                sql += "where 1=1 ";
                sql += "and b.status_id = 3 ";
                sql += "and b.data_Trabalho between @dataInicial and @dataFinal ";
                dt = objCon.retornaDataTable(sql);
                return carregarListView(lst, dt, true);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        public bool resolucaoDiariaEvolutivaPorAnalistaFila(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select b.data_Trabalho as DATA_TRABALHO, ";
                sql += "f.descricao as FILA, ";
                sql += "u.nome, count(b.id) as VOLUME ";
                sql += "from w_base b ";
                sql += "inner join w_sysUsuarios u on b.idCat = u.id ";
                sql += "inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where 1=1 ";
                sql += "and b.status_id = 3 ";
                sql += "and b.data_Trabalho between @dataInicial and @dataFinal ";
                sql += "group by u.nome, b.data_Trabalho, f.descricao ";
                sql += "order by b.data_Trabalho asc, f.descricao asc, u.nome asc ";
                dt = objCon.retornaDataTable(sql);
                return carregarListView(lst, dt, true);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        public bool percentualResolucaoPorAnalistaPeriodo(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select u.nome as Analista, count(b.id) as VOL_TRABALHADO, ";
                sql += "format(count(b.id)/CONVERT(decimal(7,2),(select count(id) from w_base where data_Trabalho between @dataInicial and @dataFinal)),'P') as Percentual ";
                sql += "from w_base b ";
                sql += "inner join w_sysUsuarios u on b.idCat = u.id ";
                sql += "where 1=1 ";
                sql += "and b.status_id = 3 ";
                sql += "and b.data_Trabalho between @dataInicial and @dataFinal ";
                sql += "group by u.nome";
                dt = objCon.retornaDataTable(sql);
                return carregarListView(lst, dt, true);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        public bool resolucaoDiariaEvolutiva(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {

                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select b.data_Trabalho as DATA_TRABALHO, ";
                sql += "f.descricao as FILA, count(b.id) as VOLUME ";
                sql += "from w_base b ";
                sql += "inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where 1=1 ";
                sql += "and b.status_id = 3 ";
                sql += "and b.data_Trabalho between @dataInicial and @dataFinal ";
                sql += "group by f.descricao, b.data_Trabalho ";
                sql += "order by b.data_Trabalho asc, f.descricao asc ";
                dt = objCon.retornaDataTable(sql);
                return carregarListView(lst, dt, true);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }

        }
        public bool produtividadeFilaData(DateTime dataInicial, DateTime dataFinal, ListView lst) {
            try {
                //ENTRANTE 
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select ";
                sql += "f.descricao as FILA, ";
                sql += "format(b.data_Abertura,'d') as DATA, ";
                sql += "count(b.id) as ENTRANTE, ";
                sql += "0 as TRABALHADO ";
                sql += "from w_base b ";
                sql += "inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where 1=1 ";
                sql += "and format(b.data_Abertura,'d') between @dataInicial and @dataFinal ";
                sql += "group by f.descricao, b.data_Abertura ";
                dt = objCon.retornaDataTable(sql);
                carregarListView(lst, dt, true);
                dtConsolidado.Merge(dt, true, MissingSchemaAction.Ignore);

                //TRABALHADO
                sql = "declare @dataInicial date = " + objCon.valorSql(dataInicial) + ", ";
                sql += "@dataFinal date = " + objCon.valorSql(dataFinal) + " ";

                sql += "select ";
                sql += "f.descricao as FILA, ";
                sql += "format(b.data_trabalho,'d') as DATA, ";
                sql += "0 as ENTRANTE, ";
                sql += "sum(iif(B.status_id = 3, 1, 0)) as TRABALHADO ";
                sql += "from w_base b ";
                sql += "inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where 1=1 ";
                sql += "and format(b.data_trabalho,'d') between @dataInicial and @dataFinal ";
                sql += "group by f.descricao, b.data_trabalho ";
                dt = objCon.retornaDataTable(sql);
                carregarListView(lst, dt, false);
                dtConsolidado.Merge(dt, true, MissingSchemaAction.Ignore);
                return true;
                //return carregarListView(lst, dt);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        public bool informacoesAD(DataGridView _dgv, List<string> _ou, string _cpf = "", string _nomeUsuario = "", string _matricula = "", string _campoPersonalizado = "", string _valorCampoPersonalizado = "") {
            try {

                sql = "Select * from db_ControleAD.dbo.Tbl_UsuariosAD where 1=1 ";
                foreach (string item in _ou) {
                    sql += "and Nom_OUs like '%" + item.ToString() + "%' ";
                }
                sql += "and Cod_CPF like '%" + _cpf + "%' ";
                sql += "and Nom_Usuario like '%" + _nomeUsuario + "%' ";
                sql += "and Cod_Matricula like '%" + _matricula + "%' ";

                if (!string.IsNullOrEmpty(_campoPersonalizado)) {
                    //Validando o tipo do campo
                    if (!_campoPersonalizado.ToString().ToUpper().Contains("DAT_")) {
                        sql += "and " + _campoPersonalizado + " like '%" + _valorCampoPersonalizado + "%' ";
                    } else {

                        DateTime data1 = new DateTime();                        
                        DateTime.TryParse(_valorCampoPersonalizado, out data1);

                        string data2 = objCon.valorSql(data1).Replace("'", "").Substring(0, 10);

                        sql += "and format(" + _campoPersonalizado + ",'yyyy-MM-dd') = '" + data2 + "' ";
                    }

                }

                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    carregarDataGridView(_dgv, dt);
                } else {
                    return false;
                }
                return true;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }


        public List<string> colunasTabelaBD(string _nomeTabela) {
            try {
                sql = "select top 1 * from " + _nomeTabela + " ";
                dt = objCon.retornaDataTable(sql);

                List<string> colunas = new List<string>();
                foreach (DataColumn c in dt.Columns) {
                    colunas.Add(c.Caption.ToString().ToUpper().Trim());
                }
                return colunas;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return null;
            }
        }

        #endregion


        #region PREENCHER_COMPONENTES
        private bool carregarListView(ListView lst, DataTable dt, bool limparListview = true) {

            string primeiraColuna = "";
            int contador = 0;

            try {
                //Configuração do ListView
                if (limparListview) { lst.Clear(); }
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;

                //Carregando os nomes das colunas dentro do ListView
                if (limparListview) {
                    foreach (DataColumn coluna in dt.Columns) {
                        lst.Columns.Add(coluna.ToString(), 100, HorizontalAlignment.Center);
                        if (contador == 0) {
                            primeiraColuna = coluna.ToString();
                        }
                        contador += 1;
                    }
                } else {
                    foreach (DataColumn coluna in dt.Columns) {
                        if (contador == 0) {
                            primeiraColuna = coluna.ToString();
                        }
                        contador += 1;
                    }
                }

                if (dt.Rows.Count > 0) {
                    //Navegando por cada linha
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();

                        //Navegando por cada coluna
                        foreach (DataColumn coluna in dt.Columns) {
                            if (coluna.ToString() == primeiraColuna) {
                                item.Text = linha[coluna.ToString()].ToString();
                            } else {
                                item.SubItems.Add(linha[coluna.ToString()].ToString());
                            }
                        }
                        item.ImageKey = "5";
                        lst.Items.Add(item);
                    }
                }

                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }
        private bool carregarDataGridView(DataGridView dgv, DataTable dt, bool limparDGV = true) {
            try {


                if (limparDGV) {
                    dgv.DataSource = null;
                }

                dgv.DataSource = dt;
                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "RELATORIOS - " + hlp.getCurrentMethodName());
                return false;
            }
        }

        #endregion




    }
}
