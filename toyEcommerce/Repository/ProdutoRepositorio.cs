using toyEcommerce.Models;
using MySql.Data.MySqlClient;
using Dapper;
    
namespace toyEcommerce.Repositorio {
    public class ProdutoRepositorio
    {
        //Criando a string de conexão
        private readonly string _connectionString;

        //Criando um método construtor e fazendo uma instância do connectionString
        public ProdutoRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Produto>> TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select id, nome, descricao, preco, imageUrl, Estoque from produtos";
            return await connection.QueryAsync<Produto>(sql);
        }

        public async Task<Produto?> ProdutosPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT id, nome, descricao, preco, imageUrl, Estoque FROM produtos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
        }
    }
}