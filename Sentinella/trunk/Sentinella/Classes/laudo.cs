using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Sentinella {
    class laudo {

        #region Variaveis 

        string sql = "";
        long retorno = 0;
        bool validacao = false;
        //long retorno = 0;        
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();

        #endregion

        #region Camada DTO - Dados

        //CREATE TABLE [dbo].[w_laudos] (
        //    [id]                   INT             IDENTITY (1, 1) NOT NULL,
        //    [protocolo_senttinela] INT             DEFAULT ((0)) NOT NULL,
        //    [nome_arquivo]         NVARCHAR (100)  DEFAULT ('SEM ARQUIVO') NOT NULL,
        //    [data_geracao]         DATETIME        DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //    [resumo_incidente]     NVARCHAR (MAX)  DEFAULT ('SEM RESUMO') NOT NULL,
        //    [resultado_analise]    NVARCHAR (MAX)  DEFAULT ('RESULTADO NAO INFORMADO') NOT NULL,
        //    [endereco_laudo] NVARCHAR(MAX) NULL, 
        //    CONSTRAINT [PK_w_laudos] PRIMARY KEY CLUSTERED ([id] ASC)
        //);

        //CREATE TABLE [dbo].[w_laudos_evidencias] (
        //    [id_senttinela]         INT             NOT NULL,
        //    [evidencia]        NVARCHAR (MAX)  DEFAULT ('SEM EVIDENCIA') NOT NULL,
        //    [imagem_evidencia] VARBINARY (MAX) NULL 
        //);

        //GO

        //CREATE INDEX [id_laudo] ON [dbo].[w_laudos_evidencias] ([id_senttinela])

        private int _id { get; set; }

        private int _protocolo_senttinela { get; set; }
        private string _nome_arquivo { get; set; }//tabela principal
        private string _endereco_laudo { get; set; } //tabela principal
        private DateTime _data_geracao { get; set; }//tabela principal
        private string _resumo_incidente { get; set; } //tabela principal
        private string _resultado_analise { get; set; } //tabela principal


        //private List<string> _evidencia {get; set;} //tabela auxiliar
        //private List<Bitmap> _imagem_evidencia { get; set; } //tabela auxiliar

        #endregion

        #region Construtores

        public laudo() { }

        public laudo(int _protocoloSenttinela, string _nomeArquivo, string _enderecoLaudo, DateTime _dataGeracao, string _reusmoIncidente,
                            string _resultadoAnalise) // List<string> _evidenciaCaptura, List<Bitmap> _imageEvidencia )
        {
            _protocolo_senttinela = _protocoloSenttinela;
            _nome_arquivo = _nomeArquivo;
            _data_geracao = _dataGeracao;
            _resumo_incidente = _reusmoIncidente;
            _resultado_analise = _resultadoAnalise;
            _endereco_laudo = _enderecoLaudo;
            //_evidencia = _evidenciaCaptura;
            //_imagem_evidencia = _imageEvidencia;
        }

        #endregion

        #region Camada DAL - Dados

        private bool _registrarLaudo(laudo obj) {
            validacao = false;
            try {

                sql = "Insert into w_laudos (";
                sql += "protocolo_senttinela, ";
                sql += "nome_arquivo, ";
                sql += "data_geracao, ";
                sql += "resumo_incidente, ";
                sql += "resultado_analise ";
                sql += ") values ( ";
                sql += objCon.valorSql(obj._protocolo_senttinela) + ", ";
                sql += objCon.valorSql(obj._nome_arquivo) + ", ";
                sql += objCon.valorSql(obj._data_geracao) + ", ";
                sql += objCon.valorSql(obj._resumo_incidente) + ", ";
                sql += objCon.valorSql(obj._resultado_analise) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno);


                ////Incluir evidencias e imagens na tabela auxiliar [w_laudo_evidencias]
                //if (validacao && _evidencia.Count >= 0)
                //{
                //    foreach (string ev in _evidencia)
                //    {
                //        // toda evidencia deve ter uma imagem, caso uma evidencia não tenha imagem deve ter a imagem padrão em branco
                //        // salvando cada evidencia
                //        // utilizando o index da descricao para localizar a imagem correspondente no list das imagens
                //        validacao = _registrarEvidencia(obj._protocolo_senttinela, ev, obj._imagem_evidencia[obj._evidencia.IndexOf(ev.ToString())]);
                //    }                    
                //}

                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LAUDO - INCLUIR LAUDO (DAL)");
                return false;
            }
        }

        

        private bool _registrarEvidencia(int _id_senttinela, string _descricaoEvidencia, Bitmap _imagemEvidencia) {
            validacao = false;
            try {
                MemoryStream ms = new MemoryStream();
                _imagemEvidencia.Save(ms, ImageFormat.Bmp);
                byte[] imagem = ms.ToArray();

                sql = "Insert into w_laudos_evidencias set ( ";
                sql += "id_sentinella, ";
                sql += "evidencia, ";
                sql += "imagem_evidencia ";
                sql += ") values ( ";
                sql += objCon.valorSql(_id_senttinela) + ", ";
                sql += objCon.valorSql(_descricaoEvidencia) + ", ";
                sql += "@imagem) ";
                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LAUDO - INCLUIR EVIDENCIA (DAL)");
                return false;
            }
        }

        #endregion

        #region Camada de Negocio - BLL
        public bool registrarLaudo(laudo obj) {
            try {
                validacao = _registrarLaudo(obj);
                if (validacao) {
                    //Biblioteca de geração já possui mensagem de aviso
                }
                return validacao;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LAUDO - CRIAR LAUDO (BLL)");
                return false;
            }
        }
        #endregion


        #region MODELOS DE E-MAILS

        public string bradescoSimples(int _protocoloSentinella) {

            impAssociado user = new impAssociado();
            categorizacoes cat = new categorizacoes();
            cat = cat.getRegistroPorID(_protocoloSentinella);
            user = user.getPorCPF(cat.Cpf);

            //validando se houve captura de informações e evitando erros
            if (user.Nom_Usuario == null) {
                return "";
            }

            string email = "<b>E-mail Coordenador:</b> " + user._gestor2_email + Environment.NewLine +
                            "<b>E-mail Supervisor:</b> " + user._gestor1_email + Environment.NewLine +
                            "<b>Protocolo Sentinella:</b> " + _protocoloSentinella + Environment.NewLine +
                            Environment.NewLine + Environment.NewLine +
                            "Classificação: Interno - Manifestação Ouvidoria Algar - Protocolo [#]" +
                            Environment.NewLine + Environment.NewLine +
                            "<b><font color = 'red'>" +
                            "Atenção: O acesso ao conteúdo desta mensagem está autorizado, exclusivamente ao(s) seu(s) destinatário(s), não sendo autorizado o seu compartilhamento." +
                            "</font></b>" +
                            Environment.NewLine + Environment.NewLine +
                            "Caro coordenador e supervisor, " +
                            Environment.NewLine + Environment.NewLine +
                            "Através de auditoria realizada pela área de Segurança da Informação foi identificado que o associado(a), abaixo classificado, violou a Política e Diretrizes do SGSI. Foi identificado que o associado utilizou o acesso do sistema do Bradesco Cartões – Service View para acessar cartões emitidos em seu próprio CPF." +
                            Environment.NewLine + Environment.NewLine +
                            "Ressaltamos conforme Termo de Confidencialidade que todos os associados(a) não deverá  realizar qualquer alteração ou manutenção, de natureza financeira ou não, para benefício próprio ou de terceiros, no sistema da EMPRESA ou do próprio cliente." +
                            Environment.NewLine + Environment.NewLine +
                            "<b>Associado(a):</b> " + user.Nom_Usuario + Environment.NewLine +
                            "<b>Matrícula:</b> " + user.Cod_Matricula + Environment.NewLine +
                            "<b>Data de Admissão:</b> " + user.Dt_Admissao + Environment.NewLine +
                            "<b>Cargo:</b> " + user.Nom_Cargo + Environment.NewLine +
                            "<b>Supervisao Imediato:</b> " + user._gestor1 + Environment.NewLine +
                            "<b>Coordenador:</b> " + user._gestor2 + Environment.NewLine +
                            Environment.NewLine + Environment.NewLine +
                            "<b>Plano de Ação:</b> " + "Recomendamos aplicação da medida disciplinar e registro no sistema Sinergy e enviar as evidências respondendo a este e-mail para encerramento da manifestação. O prazo de devolutiva é de 72 horas úteis." +
                            Environment.NewLine + Environment.NewLine +
                            "<b>Evidência:</b> " + "Em anexo." + Environment.NewLine +
                            Environment.NewLine + Environment.NewLine +
                            "Qualquer dúvida e ou esclarecimento, por favor responder a este e ou acionar os canais abaixo." +
                            Environment.NewLine + Environment.NewLine +
                            "Tel.: ​0800 034 2525 opção 1​" + Environment.NewLine +
                            "WhatsApp/Telegram: (11) 95130-1247" + Environment.NewLine +
                            "Atendimento: segunda a sexta no período das 09h às 18h" + Environment.NewLine +
                            Environment.NewLine + Environment.NewLine +
                            "<b>Ouvidoria | Ombudsman</b>" + Environment.NewLine +
                            "<font color = 'blue'>'Ouvir faz parte da nossa essência'</font>";

                            return email;
        }

        #endregion

    }
}
