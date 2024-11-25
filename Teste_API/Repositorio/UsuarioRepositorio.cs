using Dapper;
using Dapper.Contrib.Extensions;
using Teste_API.Data;
using Teste_API.Entidade;

namespace Teste_API.Repositorio;

public class UsuarioRepositorio
{
    Contexto data = new Contexto();

    public Usuario Cadastro(Usuario usuario)
    {
        using( var connection = data._conectaBanco())
        {
            connection.Open();
            connection.Execute($"""
                INSERT INTO teste.usuario (nome,email,sexo,idade,senha)
                VALUES ('{usuario.nome}','{usuario.email}','{usuario.sexo}','{usuario.idade}','{usuario.senha}')   
               """);
            connection.Close();

            return usuario;
        }
    }

    public IEnumerable<Usuario> ListaBanco()
    {
        List<Usuario> novaLista = new List<Usuario>();

        using(var connection = data._conectaBanco())
        {
            connection.Open();
            var listaUsuarios =
                connection.Query<Usuario>($"""
                SELECT * FROM teste.usuario
               """);
            connection.Close();

           

            return listaUsuarios;
        }
    }

    public bool Excluir(int Id)
    {
        try
        {
            using (var connection = data._conectaBanco())
            {
                connection.Open();
                var excluirId = connection.Query($"""
                DELETE FROM teste.usuario WHERE idusuario = {Id}
               """);
                connection.Close();
                return true;
            }

        }
        catch (Exception)
        {

            return false;
        }
    }

    public Usuario Atualizar(Usuario usuario, int Id)
    {
        using (var connection = data._conectaBanco())
        {
            connection.Open();
            connection.Execute($"""
               UPDATE teste.usuario
               SET nome = '{usuario.nome}', email = '{usuario.email}', sexo = '{usuario.sexo}', idade = '{usuario.idade}', senha = '{usuario.senha}'
               WHERE idusuario = {Id}   
               """);
            connection.Close();

            return usuario;
        }
    }
}
