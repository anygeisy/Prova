using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppiAula1.Models;

namespace WebApiProva1.Controllers
{
    public class CidadaoController : ApiController
    {
        // GET: api/Cidadao
        public List<Cidadao> Get()
        {
            Cidadao cidadao = new Cidadao();
            return cidadao.listaCidadao();
        }

        // GET: api/Cidadao/5
        public Cidadao Get(string Gnome)
        {
            Cidadao cidadao = new Cidadao();
            return cidadao.listaCidadao().Where(x => x.Gnome == Gnome).FirstOrDefault();
        }

        // POST: api/Cidadao
        public List<Cidadao> Post(Cidadao cidadao)
        {
            Cidadao _cidadao = new Cidadao();
            _cidadao.Inserir(cidadao);
            return _cidadao.listaCidadao();
        }

        // PUT: api/Cidadao/5
        public List<Cidadao> Put(int Gid, Cidadao cidadao)
        {
            Cidadao _cidadao = new Cidadao();
            _cidadao.Atualizar(Gid, cidadao);
            return _cidadao.listaCidadao();
        }

        // DELETE: api/Cidadao/5
        public void Delete(int Gid)
        {
            Cidadao _cidadao = new Cidadao();
            _cidadao.Deletar(Gid);
        }
    }
}
