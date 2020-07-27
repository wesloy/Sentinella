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

        public string[] bradescoSimples(int _protocoloSentinella) {

            impAssociado user = new impAssociado();
            categorizacoes cat = new categorizacoes();
            cat = cat.getRegistroPorID(_protocoloSentinella);
            user = user.getPorCPFSupImediado(cat.Cpf);

            //validando se houve captura de informações e evitando erros
            if (user.Nom_Usuario == null) {
                return null;
            }

            string titulo = "Report Segurança da Informação - " + user.Nom_Usuario + " - Cód 00";

            string corpo = "<b>E-mail Coordenador:</b> " + user._gestor2_email + Environment.NewLine +
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
                            "Através de auditoria realizada pela área de Segurança da Informação foi identificado que o associado(a) " + user.Nom_Usuario +
                            ", matrícula: " + user.Cod_Matricula + ", violou a Política e Diretrizes do SGSI. Foi identificado que o associado utilizou o acesso do sistema do Bradesco Cartões – Service View para acessar cartões emitidos em seu próprio CPF." +
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
                            Environment.NewLine + Environment.NewLine; 

            string assinatura = "Qualquer dúvida e ou esclarecimento, por favor responder a este e ou acionar os canais abaixo." +
                    Environment.NewLine + Environment.NewLine +
                    "Tel.: ​0800 034 2525 opção 1​" + Environment.NewLine +
                    "WhatsApp/Telegram: (11) 95130-1247" + Environment.NewLine +
                    "Atendimento: segunda a sexta no período das 09h às 18h" + Environment.NewLine +
                    Environment.NewLine + Environment.NewLine +
                    "<b>Ouvidoria | Ombudsman</b>" + Environment.NewLine +
                    "<font color = 'blue'>'Ouvir faz parte da nossa essência'</font>";


            string[] email = new string[3];
            email[0] = titulo;
            email[1] = corpo;
            email[2] = assinatura;

            return email;
        }

        public string[] dlp(int _protocoloSentinella) {

            impAssociado user = new impAssociado();
            categorizacoes cat = new categorizacoes();
            cat = cat.getRegistroPorID(_protocoloSentinella);
            user = user.getPorCPFSupImediado(cat.Cpf);

            //validando se houve captura de informações e evitando erros
            if (user.Nom_Usuario == null) {
                return null;
            }

            string titulo = "Report Segurança da Informação - " + user.Nom_Usuario + " - Cód 00";

            string corpo = "<b>E-mail Coordenador:</b> " + user._gestor2_email + Environment.NewLine +
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
                            "Através de auditoria realizada pela área de Segurança da Informação foi identificado que o associado(a) " + user.Nom_Usuario +
                            ", matrícula: " + user.Cod_Matricula + ", foi identificado que o mesmo no seu login de rede corporativa, salvou CPF/Número de cartão, violando a Política de Diretrizes de DLP." +
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
                            "<b>Política: DIRETRIZES DE DLP</b> " + Environment.NewLine +
                            "Data de Criação/Alteração: 12/06/2019 Versão: 01" +
                            Environment.NewLine + Environment.NewLine +
                            "4 - DESCRIÇÃO" + Environment.NewLine +
                            "4.1 - Objetivo da política de DLP" +
                            Environment.NewLine + Environment.NewLine +
                            "Manter a conformidade com os padrões de negócio e regulamentações nacionais e internacionais. A Algar Tech protege as informações confidenciais e evita a divulgação acidental. Exemplos de informações confidenciais que são protegidas contra vazamento de informações incluem dados financeiros ou informações de identificação pessoal, como números de cartão de crédito, números de seguro social ou registros de saúde. Com uma política DLP (prevenção contra perda de dados), a área de segurança da informação pode identificar, monitorar e proteger automaticamente informações confidenciais por todo o ambiente tecnológico." +
                            Environment.NewLine + Environment.NewLine +
                            "Diretrizes da política DLP:" +
                            Environment.NewLine + Environment.NewLine +
                            "· Identificar informações confidenciais em locais, como o Exchange Online, o SharePoint Online e o OneDrive for Business. Com o objetivo de identificar qualquer documento que contenha um número de cartão de crédito que esteja armazenado em qualquer site do OneDrive for Business ou pesquisar apenas os sites do OneDrive de associados específicos;" +
                            Environment.NewLine + Environment.NewLine +
                            "· Impedir o compartilhamento acidental de informações confidenciais. Com o objetivo de identificar qualquer documento ou e-mail que contenha um registro de saúde compartilhado com pessoas fora da sua organização e, em seguida, bloquear automaticamente o acesso a esse documento ou bloquear o envio do e-mail;" +
                            Environment.NewLine + Environment.NewLine +
                            "<b>Política: CONTROLE DE ACESSO LÓGICO</b> " + Environment.NewLine +
                            "Data de Criação/Alteração: 31/05/2019 Versão: 21" +
                            Environment.NewLine + Environment.NewLine +
                            "4.1. - Generalidades 4.1.1 – Nenhum acesso pode ser compartilhado, sendo o associado dono do usuário, responsável por manter a confidencialidade de suas senhas de logon, usuário de rede, arquivos de trabalho e demais aplicativos da Algar Tech. Os acessos são de uso pessoal e intransferível." +
                            Environment.NewLine + Environment.NewLine +
                            "4.1.3 – O usuário não deve registrar seu usuário e senha de rede ou aplicativos em papel, arquivo avulsos no file Server, desktop ou qualquer outro meio que possa ser copiado ou furtado para acesso indevido de terceiros;" +
                            Environment.NewLine + Environment.NewLine +
                            "4.1.10 – Páginas de internet estão liberadas de acordo com as necessidades de cada área, no entanto estão bloqueados sites com os seguintes conteúdos: Jogos, música, vídeos, redes sociais, downloads, conteúdo adulto, conteúdo hacker, pedofilia, violência ou qualquer outro conteúdo que venha a ferir as políticas e diretrizes de Segurança da Informação da organização. " +
                            Environment.NewLine + Environment.NewLine;



            string assinatura = "Qualquer dúvida e ou esclarecimento, por favor responder a este e ou acionar os canais abaixo." +
                                Environment.NewLine + Environment.NewLine +
                                "Tel.: ​0800 034 2525 opção 1​" + Environment.NewLine +
                                "WhatsApp/Telegram: (11) 95130-1247" + Environment.NewLine +
                                "Atendimento: segunda a sexta no período das 09h às 18h" + Environment.NewLine +
                                Environment.NewLine + Environment.NewLine +
                                "<b>Ouvidoria | Ombudsman</b>" + Environment.NewLine +
                                "<font color = 'blue'>'Ouvir faz parte da nossa essência'</font>";


            string[] email = new string[3];
            email[0] = titulo;
            email[1] = corpo;
            email[2] = assinatura;

            return email;
        }

        public string[] tamnun(int _protocoloSentinella) {

            impAssociado user = new impAssociado();
            categorizacoes cat = new categorizacoes();
            cat = cat.getRegistroPorID(_protocoloSentinella);
            user = user.getPorCPFSupImediado(cat.Cpf);

            //validando se houve captura de informações e evitando erros
            if (user.Nom_Usuario == null) {
                return null;
            }
            string titulo = "Report Segurança da Informação - " + user.Nom_Usuario + " - Cód 00";

            string corpo = "<b>E-mail Coordenador:</b> " + user._gestor2_email + Environment.NewLine +
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
                            "Através de auditoria realizada pela área de Segurança da Informação foi identificado que o associado(a) " + user.Nom_Usuario +
                            ", matrícula: " + user.Cod_Matricula + ", tem efetuado acesso(s) indevido(s) a site(s) da internet, violando a Política de Controle de acesso lógico - Violação das Políticas e Diretrizes do SGSI." +
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
                            "<b>Política: CONTROLE DE ACESSO LÓGICO</b> " + Environment.NewLine +
                            "Data de Criação/Alteração: 31/05/2019 Versão: 21" +
                            Environment.NewLine + Environment.NewLine +
                            "4.1.10 – Páginas de internet estão liberadas de acordo com as necessidades de cada área, no entanto estão bloqueados sites com os seguintes conteúdos: Jogos, música, vídeos, redes sociais, downloads, conteúdo adulto, conteúdo hacker, pedofilia, violência ou qualquer outro conteúdo que venha a ferir as políticas e diretrizes de Segurança da Informação da organização. " +

                            Environment.NewLine + Environment.NewLine +
                            "<b>Política: DIRETRIZES DE DLP</b> " + Environment.NewLine +
                            "Data de Criação/Alteração: 12/06/2019 Versão: 01" +
                            Environment.NewLine + Environment.NewLine +
                            "4 - DESCRIÇÃO" + Environment.NewLine +
                            "4.1 - Objetivo da política de DLP" +
                            Environment.NewLine + Environment.NewLine +
                            "Manter a conformidade com os padrões de negócio e regulamentações nacionais e internacionais. A Algar Tech protege as informações confidenciais e evita a divulgação acidental. Exemplos de informações confidenciais que são protegidas contra vazamento de informações incluem dados financeiros ou informações de identificação pessoal, como números de cartão de crédito, números de seguro social ou registros de saúde. Com uma política DLP (prevenção contra perda de dados), a área de segurança da informação pode identificar, monitorar e proteger automaticamente informações confidenciais por todo o ambiente tecnológico." +
                            Environment.NewLine + Environment.NewLine +
                             "<b>7.1 – Pessoas</b> " + Environment.NewLine +
                            "<b>7.1.1 – Associados, Fornecedores e Terceiros Algar Tech</b>" + Environment.NewLine +
                            "Todos os associados, jovem aprendiz, estagiários, prestadores de serviços, fornecedores, contratados, visitante, parceiros, startup´s e clientes no ambiente Algar Tech, devem ter conhecimento do Código de Conduta do grupo Algar e do treinamento de Conscientização em Segurança da Informação e ser coerente com os mesmos;" +
                            Environment.NewLine + Environment.NewLine +
                            "<b>7.6 - Sistemas e Aplicativos</b>" + Environment.NewLine +
                            "a) Todos os softwares instalados em máquinas de propriedade ou a serviço da Algar Tech devem possuir licença de uso previamente adquiridas, devendo a área usuária registrar  solicitação ao Service Desk para instalação, autorização e uso;" + Environment.NewLine +
                            "c) Não será permitida a instalação de software shareware, freeware ou equivalentes que não esteja previsto na lista de soluções homologadas disponível na intranet Algar Tech&gt;Utilidades;" +
                            Environment.NewLine + Environment.NewLine +
                            "<b>8 – Violação das Políticas e Diretrizes do SGSI</b>" + Environment.NewLine +
                            "8.1 - As violações de segurança devem ser informadas à área de Segurança da Informação,por meio do Service Desk. Toda violação ou desvio deve ser investigado para a determinação das medidas necessárias, visando à correção da falha ou reestruturação de processos;" + Environment.NewLine +
                            "8.2 – São consideradas violações de segurança:" + Environment.NewLine +
                            "- Uso ilegal de software;" + Environment.NewLine +
                            "- Compartilhamento de: Conteúdo adulto, discriminatório, ofensivo, difamatório, abusivo, pornográfico, obsceno, violento e os demais que venham a causar, incitar ou promover atitudes que impliquem em violação de privacidade, propriedades intelectual e industrial." + Environment.NewLine +
                            "- Demais violações previstas no Código de Conduta do Grupo Algar, Política de Segurança da Informação do Grupo Algar e legislações vigentes." + Environment.NewLine +
                              "8.3– Serão consideradas e passíveis de investigação, aplicação da“Política de Gestão das Consequências” e/ou aplicação de medidas determinadas em legislação ou contrato vigente, violação de segurança que ocorra nos seguintes aspectos:Em posse de ativo e/ou em ambiente tecnológico Algar Tech; Em posse de ativo Algar Tech e em ambiente externo;" + Environment.NewLine +
                              "8.4 - Os princípios de segurança estabelecidos na presente política possuem total aderência da presidência e diretoria da Algar Tech e devem ser observados por todos na execução de suas funções;" + Environment.NewLine +
                              "8.5 – O não atendimento às diretrizes desta política ou das demais políticas e diretrizes da organização estão sujeitas à aplicação da gestão disciplinar conforme previsto no Procedimento – Registros de Plano de Ação e Aplicação da Gestão Disciplinar, disponível para consulta na intranet Algar Tech / Diretório Google Drive (temporário) &gt;Políticas e Diretrizes e Política – Gestão de Consequências do grupo Algar." + Environment.NewLine + Environment.NewLine +

                              "<b>9 – Auditoria</b>" + Environment.NewLine + Environment.NewLine +
                              "9.1 - Todos os associados, jovem aprendiz, estagiários, prestadores de serviços, fornecedores, contratados, parceiros, visitante, startup´s e clientes que utilizam o ambiente  tecnológico da Algar Tech, estão sujeitos a auditoria de rede, telefonia e utilização das aplicações;" + Environment.NewLine +
                              "9.2 - Os procedimentos de auditoria e monitoramento serão realizados periodicamente pela  área de segurança da informação ou empresa contratada, com o objetivo de observar o cumprimento das diretrizes estabelecidas nesta política pelos usuários e com vistas a gestão de performance da rede;" + Environment.NewLine +
                              "9.3 - Havendo evidência de atividades que possam comprometer a segurança da rede, será permitido a área de segurança da informação auditar e monitorar as atividades de um usuário, além de inspecionar seus arquivos e registros de acesso, a bem do interesse da Algar Tech, sendo o fato imediatamente comunicado à Alta Direção." + Environment.NewLine + Environment.NewLine;



            string assinatura = "Qualquer dúvida e ou esclarecimento, por favor responder a este e ou acionar os canais abaixo." +
                                Environment.NewLine + Environment.NewLine +
                                "Tel.: ​0800 034 2525 opção 1​" + Environment.NewLine +
                                "WhatsApp/Telegram: (11) 95130-1247" + Environment.NewLine +
                                "Atendimento: segunda a sexta no período das 09h às 18h" + Environment.NewLine +
                                Environment.NewLine + Environment.NewLine +
                                "<b>Ouvidoria | Ombudsman</b>" + Environment.NewLine +
                                "<font color = 'blue'>'Ouvir faz parte da nossa essência'</font>";


            string[] email = new string[3];
            email[0] = titulo;
            email[1] = corpo;
            email[2] = assinatura;

            return email;
        }

        #endregion

    }
}
