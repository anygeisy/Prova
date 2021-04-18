using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebAppiAula1.Models
{
    public class Cidadao
    {
        public int Gid { get; set; }
        public string Gnome { get; set; }
        public string Gtelefone { get; set; }
        public string Gemail { get; set; }
        public int Gidade { get; set; }

        public List<Cidadao> listaCidadao()
        {

            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaCidadao = JsonConvert.DeserializeObject<List<Cidadao>>(json);
            return listaCidadao;

        }
       
        public bool ReescreverArquivo(List<Cidadao> listaCidadao)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaCidadao, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            return true;

        }

        public Cidadao Inserir(Cidadao Cidadao)
        {
            var ListaCidadao = this.listaCidadao();
            var maxId = ListaCidadao.Max(cidadao => cidadao.Gid);
            Cidadao.Gid = maxId + 1;
            ListaCidadao.Add(Cidadao);
            ReescreverArquivo(ListaCidadao);
            return Cidadao;
        }
        
        public Cidadao Atualizar(int Gid, Cidadao Cidadao)
        {
            var ListaCidadao = this.listaCidadao();
            var itemIndex = ListaCidadao.FindIndex(p => p.Gid == Gid);
            if (itemIndex >= 0)
            {
                Cidadao.Gid = Gid;
                ListaCidadao[itemIndex] = Cidadao;

            }
            else
            {
                return null;

            }
            ReescreverArquivo(ListaCidadao);
            return Cidadao;
        }
        
        public bool Deletar(int Gid)
        {
            var ListaCidadao = this.listaCidadao();
            var itemIndex = ListaCidadao.FindIndex(p => p.Gid == Gid);
            if (itemIndex >= 0)
            {
                ListaCidadao.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(ListaCidadao);
            return true;
        }
    }
}