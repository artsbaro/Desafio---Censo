using Censo.Domain.Enums;
using Censo.Domain.Types;
using System.Collections.Generic;
using System.Linq;

namespace Censo.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public Genero Genero { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Etnia Etnia { get; set; }
        public Filiacao Filiacao { get; set; }
        public IEnumerable<Pessoa> Filhos { get; set; }
        public string Regiao { get; set; }

        public bool HasChildren
        {
            get
            {
                if (Filhos == null)
                    return false;

                if (Filhos.Count() > 0)
                    return true;

                return false;
                
                //return Filhos?.ToList().Count > 0;
            }
        }

        public Pessoa()
        {
            Filiacao = new Filiacao();
        }

        public void SetParent(Pessoa entity)
        {
            Filiacao.Mae = entity.Genero?.Id == (byte)EnumGenero.Feminino ? entity : null;
            Filiacao.Pai = entity.Genero?.Id == (byte)EnumGenero.Masculino ? entity : null;
        }
    }
}
