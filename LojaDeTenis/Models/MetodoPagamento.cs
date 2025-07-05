using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public enum MetodoPagamento
    {
        [Display(Name = "Cartão de Crédito")]
        CartaoCredito,

        [Display(Name = "Cartão de Débito")]
        CartaoDebito,

        Pix,

        Boleto,

        [Display(Name = "Transferência Bancária")]
        TransferenciaBancaria,

        Dinheiro
    }
}
