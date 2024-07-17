using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoGBIControleUsuarios.Domain.Entities;

public abstract class Entity // Deverá ser herdada. Não poderá ser instanciada. Será base para as demais.
{
    public int Id { get; protected set; } // Id somente poderá ser atribuído por classes derivadas.
    
    public DateTime DataHoraCriacao { get; protected set; } = DateTime.Now;
}
