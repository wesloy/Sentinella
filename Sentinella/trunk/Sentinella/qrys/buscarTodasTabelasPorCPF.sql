DECLARE @cpf varchar(15) = '7797504628'

--select * from w_base where cpf = @cpf
--select * from w_funcionarios where cpf = @cpf
--select * from w_dadosCadastrais where cpf = @cpf
select * from w_cartoes where cpf = @cpf
--select * from w_faturas where cpf = @cpf
--select * from w_autorizacoes where cpf = @cpf

--captura dados dos cartões
select conta.*, cartao.data_Emissao from 
(select * from w_cartoes where tipoCartao = 'CONTA' or tipoCartao = 'ADICIONAL') conta 
left join 
(select cpf, bin, data_Emissao from w_cartoes where tipoCartao = 'TITULAR') cartao 
on conta.cpf = cartao.cpf and conta.bin = cartao.bin 
where conta.cpf = @cpf