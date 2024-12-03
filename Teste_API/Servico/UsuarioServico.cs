using Teste_API.Entidade;
using Teste_API.Repositorio;

namespace Teste_API.Servico;

public class UsuarioServico
{
    UsuarioRepositorio repos = new UsuarioRepositorio();

    public Usuario Cadastro(InputUsuario usuario)
    {
        Usuario user = new Usuario();
        user.idusuario = usuario.idusuario;
        user.nome = usuario.nome;
        user.email = usuario.email;
        user.sexo = usuario.sexo;
        user.idade = usuario.idade;
        user.senha = usuario.senha;

        var usuarioCadastrado = repos.Cadastro(user);
        return usuarioCadastrado;
    }

    public List<Usuario> Listagem()
    {
        var lista = repos.ListaBanco();
        return lista.ToList();
    }

    public bool ExcluirId(int Id)
    {
        var excluir = repos.Excluir(Id);
        return excluir;
    }

    public Usuario Atualizar(InputUsuario usuario, int Id)
    {
        Usuario user = new Usuario();
        user.idusuario = Id;
        user.nome = usuario.nome;
        user.email = usuario.email;
        user.sexo = usuario.sexo;
        user.idade = usuario.idade;
        user.senha = usuario.senha;

        var usuarioAtualizado = repos.Atualizar(user, Id);
        return usuarioAtualizado;
    }


}
