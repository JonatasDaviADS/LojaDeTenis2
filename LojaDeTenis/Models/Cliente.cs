using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        // lembre-se o campo required é obrigatório e exibe a mensagem vazia
        // stringlength define limites de caractres
        // emailaddress valida o formato do e-mail
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 100 caracteres ")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }

        // Relacionamento
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
