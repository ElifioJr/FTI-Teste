using Microsoft.AspNetCore.Mvc;
using Teste_API.Entidade;
using Teste_API.Servico;

namespace Teste_API.Controllers
{
    [Route("controller/")]
    public class UsuarioController : Controller
    {
        UsuarioServico service = new UsuarioServico();

        [HttpPost("Cadastro")]
        public Usuario Cadastro([FromBody] InputUsuario usuario)
        {
            var cadastro = service.Cadastro(usuario);
            return cadastro;
        }

        [HttpGet("Listagem")]
        public List<Usuario> Listagem()
        {
            var lista = service.Listagem();
            return lista;
        }

        [HttpDelete("Deletar")]
        public bool Delete(int Id)
        {
            var exclusao = service.ExcluirId(Id);
            return exclusao;
        }

        [HttpPut("Atualizar")]
        public Usuario Atualizar([FromBody] InputUsuario usuario, int Id)
        {
            var att = service.Atualizar(usuario, Id);
            return att;
        }


    }
}
