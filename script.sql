create database ToyEcommDb;
use ToyEcommDb;

create table produtos(
Id int primary key auto_increment,
Nome varchar(50),
Descricao varchar(100),
Preco decimal(10,2),
ImageUrl varchar(255),
Estoque int
);

create table pedido(
Id int primary key auto_increment ,
DataPedido datetime,
Total decimal(10,2),
Status varchar(50),
Endereco varchar(100),
FormaPagamento varchar(100),
Frete decimal (10,2)
);


create table itemPedido(
Id int primary key auto_increment ,
PedidoId int,
ProdutoId int,
Quantidade int,
PrecoUnitario decimal(10,2)
);

Select id, nome, descricao, preco, imageUrl, Estoque from produtos;

insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Beyblade BigBang Pegasus", "Beyblade de alta qualidade, original", 37.99, "beyblade.jpg", 50);
insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Pelúcia Kirby", "Pelúcia do personagem Kirby", 15.99, "kirby.jpg", 100);
insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Boneco do Artrópode do Ben 10", "Brinquedo do Alien Artrópode da série animada Ben 10", 25.99, "artropode.jpg", 50);
insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Amiibo Kazuya Mishima", "Amiibo do Kazuya Mishima da sérei de jogos Tekken", 249.99, "kazuya.jpg", 30);
insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Omanjuu Tetora Nagumo", "Omanju do personagem Tetora Nagumo de Ensemble Stars!!", 49.99, "Tetora.jpg", 50);
insert into produtos (nome, descricao, preco, imageUrl, Estoque) values ("Action Figure Knight (Hollow Knight)", "Action figure de alta qualidade do personagem Knight de Hollow Knight", 499.99, "Knight.jpg", 25);