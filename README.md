RF01 - O sistema deve possuir um cadastro/login de usuário com Email, Usuario, Senha, Foto, DataNasc. <br>
RF02 - O usuário pode criar um Fórum(titulo, descricao, dataCriado).<br>
RF03 - O usuário pode ver os Fóruns que ele é membro.<br>
RF04 - Pode ver seu feed com posts de vários fóruns.<br>
RF05 - O usuário pode procurar por Fóruns existentes.<br>
RF06 - O usuário pode tornar-se membro de qualquer Fórum.<br>
RF07 - Usuários com devida permissão podem:<br>
	RF07.1 - Ver posts.<br>
	RF07.2 - Postar(titulo, mensagem, anexo).<br>
	RF07.3 - Dar Like (+1).<br>
	RF07.4 - Dar deslike (-1).<br>
	RF07.5 - Remover posts.<br>
	RF07.6 - Remover membros.<br>
	RF07.7 - Editar posts.<br>
	RF07.8 - Promover membros (mudar seu cargo)<br>
	RF07.9 - Criar/Editar cargos.<br>
	RF07.10 - Deletar o Fórum.<br>
RF08 - Sair de um fórum (deixar de ser membro).<br>
RF09 - Visitar a página de um fórum.<br>
RNF01 - O sistema não pode ser muito feio.<br>
RNF02 - O sistema não pode ser muito inseguro.<br>
RNF03 - O sistema deve usar Angular :(, C# :) e Sql :|.<br>
RNF04 - O sistema não deve ser lento demais.<br>
RNF05 - Deve ter um nome criativo e red pill.<br>



create database redeSocial<br>


create table UserTable<br>
(<br>
	id int identity(1,1) primary key,<br>
	Name varchar(100) not null,<br>
	cpf varchar(11) not null,<br>
	UserName varchar(25) not null,<br>
	BornDate date,<br>
	AssignDate DATE NOT NULL DEFAULT GETDATE(),<br>
	password varchar(100) not null, <br>
)<br>



https://consolelog.com.br/modal-animations-angular/
