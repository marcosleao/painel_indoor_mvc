using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Entities
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public BaseEntity() { }

        public virtual TKey Id { get; set; }

        //public Guid? CreatedBy { get; set; }

        //public DateTime? CreatedOn { get; set; }

        //public Guid? UpdatedBy { get; set; }

        //public DateTime? UpdatedOn { get; set; }

        //public int IdSituacao { get; set; }

        //public bool Excluido { get; set; }

        //public void Excluir() => Excluido = true;
    }
}
