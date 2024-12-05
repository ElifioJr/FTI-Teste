using MySql.Data.MySqlClient;
using System.Data;

namespace Teste_API.Data;

public class Contexto
{
    private readonly string _stringConexao;
    private static int? _timeout = null;
    public IDbTransaction? Transaction { get; set; }

    public Contexto()
    {
        _stringConexao = $"Server=127.0.0.1;Database=teste;User Id=root;Password=Flyngturtle741-;";
    }

    public IDbConnection _conectaBanco()
    {
        try
        {
            return new MySqlConnection(_stringConexao);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

public static class DapperContext
{
    public static void AbrirConexao(this IDbConnection conexao)
    {
        if (conexao != null && conexao.State != ConnectionState.Open)
            conexao.Open();
    }

    public static void FecharConexao(this IDbConnection conexao)
    {
        if (conexao != null && conexao.State != ConnectionState.Executing)
            conexao.Close();
    }

}
